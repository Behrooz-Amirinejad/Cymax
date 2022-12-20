using AutoMapper;
using Cymax.Web.DataAccess;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.Feeder;
using Cymax.Web.Models;

namespace Cymax.Web.BusinessService.Parcel
{
    public class ParcelBusinessService : IParcelBusinessContract
    {
        private readonly IRepository<ParcelModel> _parcelRepo;
        private readonly IMapper mapper;

        public ParcelBusinessService(IRepository<ParcelModel> parcelRepo, IMapper mapper)
        {
            this._parcelRepo = parcelRepo;
            this.mapper = mapper;
        }

        public async Task<ParcelOutputModel> GetLowerstPrice(ParcelInputModel input)
        {
            var optionList = await _parcelRepo.Gets();
            var lowerstPriceOption = optionList.Where(x => x.Departure == input.From && x.Destination == input.To)
                                               .OrderBy(x => x.Price)
                                               .FirstOrDefault();

            return new ParcelOutputModel() { Value = lowerstPriceOption?.Price  ?? 0 }; ;


        }

        public async Task<ViewModels.Api1ViewModel> GetTotalForThisParceAsync()
        {
            var itm = await _parcelRepo.GetSingle(new ParcelModel());
            if (itm == null)
                return new ViewModels.Api1ViewModel();
            var retVal = mapper.Map<ViewModels.Api1ViewModel>(itm);
            return retVal;
        }
        
    }
}
