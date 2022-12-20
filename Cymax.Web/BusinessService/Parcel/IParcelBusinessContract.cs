using Cymax.Web.DTOs.ParcelBusinessModels;

namespace Cymax.Web.BusinessService.Parcel
{
    public interface IParcelBusinessContract
    {
        Task<ParcelOutputModel> GetLowerstPrice(ParcelInputModel input);
    }
}
