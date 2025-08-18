using CAMS_API.Models.Entities;

namespace CAMS_API.Interface
{
    public interface IDocumentSignatoryRepository
    {
        Task<IEnumerable<DocumentSignatory>> GetDocumentSignatoryAsync(int departmentID);
    }
}
