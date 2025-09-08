using AutoMapper;
using CAMS_API.CAMS_API.Core.Interfaces.Service_Interfaces;
using CAMS_API.Interface;
using CAMS_API.Interface.IUnitOfWork;
using CAMS_API.Models.DTO;
using CAMS_API.Models.DTO.AssetRequestSignatoryDTO;
using CAMS_API.Models.Entities;

namespace CAMS_API.CAMS_API.Infrastructure.Services
{
    public class AssetRequestSignatoryServiceRepository(IUnitOfWork uow, IMapper mapper, IAccountRepository accountRepository) : IAssetRequestSignatoryServiceRepository
    {
        private readonly IUnitOfWork uow = uow;
        private readonly IMapper mapper = mapper;
        private readonly IAccountRepository accountRepository = accountRepository;

        public async Task<ServiceResultDTO<AssetRequestSignatoryModel>> PatchPendingRequestAsync(AssetRequestSignatoryModel model)
        {
            var accountID = await accountRepository.GetAccountIDAsync();

            var assetRequest = await uow.AssetRequestSignatories.GetAssetRequestWithSignatoriesAsync(model.AssetRequestID);
            if (assetRequest is null)
                return ServiceResultDTO<AssetRequestSignatoryModel>.Fail("Asset request not found.");

            var signatory = GetSignatoriesByRequestAsync(assetRequest, accountID);
            if (signatory is null)
                return ServiceResultDTO<AssetRequestSignatoryModel>.Fail("Signatories not found for this asset request.");

            if (!model.IsSigned.HasValue)
                return ServiceResultDTO<AssetRequestSignatoryModel>.Fail("IsSigned value is required.");

            UpdateSignatoryStatus(signatory, model.IsSigned.Value);

            string resultMessage = await HandleApprovalAsync(assetRequest, model.IsSigned.Value);

            await uow.CompleteAsync();
            return ServiceResultDTO<AssetRequestSignatoryModel>.Ok(resultMessage, null);

        }

        private AssetRequestSignatory? GetSignatoriesByRequestAsync(AssetRequestHeader assetRequest, int accountID)
        {
            var signatory = assetRequest.AssetRequestSignatories.FirstOrDefault(ars => ars.SignatoryID == accountID);
            return signatory;
        }

        private void UpdateSignatoryStatus(AssetRequestSignatory signatory, bool isSigned)
        {
            signatory.IsSigned = isSigned;
            signatory.DateSigned = isSigned ? DateTime.UtcNow : null;
        }

        private async Task<string> HandleApprovalAsync(AssetRequestHeader assetRequest, bool isSigned)
        {
            if (!isSigned)
            {
                assetRequest.Status = "Rejected";
                return "Asset request rejected.";
            }

            bool allApproved = assetRequest.AssetRequestSignatories.All(ars => ars.IsSigned == true);

            if (allApproved)
            {
                assetRequest.Status = "Approved";
                await DeductInventoryAsync(assetRequest);
                return "Asset request approved and inventory updated.";
            }

            assetRequest.Status = "Pending";
            return "Asset request partially approved.";
        }

        private async Task DeductInventoryAsync(AssetRequestHeader assetRequest)
        {
            var assetQuantities = assetRequest.AssetRequestDetails
                .GroupBy(d => d.AssetID)
                .Select(g => new { AssetID = g.Key, TotalQuantity = g.Sum(d => d.Quantity) });

            foreach (var item in assetQuantities)
            {
                var inventory = await uow.Inventories.GetInventoryByAssetIDAsync(item.AssetID);
                if (inventory is null)
                    throw new KeyNotFoundException($"Inventory not found for Asset ID {item.AssetID}");

                if (inventory.Quantity < item.TotalQuantity)
                    throw new InvalidOperationException($"Insufficient inventory for Asset ID {item.AssetID}");

                inventory.Quantity -= item.TotalQuantity;
            }
        }


    }
}
