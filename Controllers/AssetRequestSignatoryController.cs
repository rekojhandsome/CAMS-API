using AutoMapper;
using CAMS_API.CAMS_API.Core.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Interface;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO.AssetRequestHeaderDTO;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Runtime.InteropServices;

namespace CAMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetRequestSignatoryController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IAccountRepository accountRepository;

        public AssetRequestSignatoryController(IUnitOfWork uow, IMapper mapper, IAccountRepository accountRepository)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetRequestSignatoryModel>>> GetAssetRequestSignatories()
        {
            var assetRequestSignatories = await uow.AssetRequestSignatories.GetAssetRequestSignatoriesAsync();

            var assetRequestSignatoryModels = mapper.Map<IEnumerable<AssetRequestSignatoryModel>>(assetRequestSignatories);

            return Ok(assetRequestSignatoryModels);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<AssetRequestSignatoryModel>> CreateAssetRequestSignatory([FromBody] AssetRequestSignatoryModel model)
        {
            var assetRequestSignatory = mapper.Map<AssetRequestSignatoryModel, AssetRequestSignatory>(model);

            await uow.AssetRequestSignatories.CreateAssetRequestSignatoryAsync(assetRequestSignatory);
            await uow.CompleteAsync();

            var assetRequestSignatoryModel = mapper.Map<AssetRequestSignatoryModel>(assetRequestSignatory);

            return Ok(assetRequestSignatoryModel);
        }

        [Authorize]
        [HttpGet("signatories")]
        public async Task<ActionResult<IEnumerable<AssetRequestHeaderResponseModel>>> GetSignatoriesByAssetRequest()
        {
            var signatoryID = await accountRepository.GetAccountIDAsync();

            var signatory = await uow.Employees.GetEmployeeProfile(signatoryID);

            var signatories = await uow.AssetRequestSignatories.GetSignatoriesForPendingAssetRequestAsync(signatory.EmployeeID, signatory.DepartmentID);

            var signatoriesModel = mapper.Map<IEnumerable<AssetRequestHeaderResponseModel>>(signatories);

            return Ok(signatoriesModel);
        }
        [Authorize]
        [HttpPatch]
        public async Task<ActionResult> PatchSignatoriesByAssetRequest([FromBody] PatchAssetRequestSignatoryModel model)
        {
            var accountID = await accountRepository.GetAccountIDAsync();

            var assetRequest = await uow.AssetRequestSignatories.GetAssetRequestWithSignatoriesAsync(model.AssetRequestID);

            if (assetRequest is null)
                return NotFound("Asset request not found.");

            var signatory = assetRequest.AssetRequestSignatories
                .FirstOrDefault(s => s.SignatoryID == accountID);

            if (signatory is null)
                return NotFound("Signatory not found for this asset request.");

            // Update the signatory's IsSigned status
            signatory.IsSigned = model.IsSigned;

            // If signed, set the DateSigned to current date and time
            signatory.DateSigned = model.IsSigned == true ? DateTime.UtcNow : null;

            string resultMessage = string.Empty;

            if (model.IsSigned == false)
            {
                assetRequest.Status = "Rejected";
                resultMessage = "Asset request rejected.";
            }
            else
            {
                bool allApproved = assetRequest.AssetRequestSignatories.All(ars => ars.IsSigned == true);

                if (allApproved)
                {
                    assetRequest.Status = "Approved";
                    resultMessage = "Asset request approved.";

                    // Group by AssetID and sum the quantities
                    var assetQuantities = assetRequest.AssetRequestDetails
                        .GroupBy(d => d.AssetID)
                        .Select(g => new { AssetID = g.Key, TotalQuantity = g.Sum(d => d.Quantity) });

                    foreach (var item in assetQuantities)
                    {
                        var inventory = await uow.Inventories.GetInventoryByAssetIDAsync(item.AssetID);
                        if (inventory is null) return NotFound($"Inventory item not found for Asset ID {item.AssetID}.");

                        if (inventory.Quantity < item.TotalQuantity)
                            return BadRequest($"Insufficient inventory for Asset ID {item.AssetID}.");

                        // Deduct and force EF to track update
                        inventory.Quantity -= item.TotalQuantity;
                        //uow.dbContext.Entry(inventory).State = EntityState.Modified;

                        Console.WriteLine($"Updating AssetID {item.AssetID} - New Qty: {inventory.Quantity}");
                    }
                    resultMessage = "Asset request approved and inventory updated.";
                }
                else
                {
                    resultMessage = "Asset request partially approved.";
                }
            }

            await uow.CompleteAsync();
            return Ok(new { message = resultMessage });
        }


    }
}
