using AutoMapper;
using Cymax.Web.BusinessService.Parcel;
using Cymax.Web.Core.ActionFilters;
using Cymax.Web.Core.ModelBindings;
using Cymax.Web.DTOs.Parcel;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cymax.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ResultAttibutes]
    public class ParcelController : ControllerBase
    {
        private readonly IParcelBusinessContract _parcelBusinessService;
        private readonly IMapper _mapper;

        public ParcelController(IParcelBusinessContract parcelBusinessContract, 
                                IMapper mapper)
        {
            this._parcelBusinessService = parcelBusinessContract;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("GetTotalInJson1")]
        [Mapping(typeof(Api1ViewModel))]
        public async Task<IActionResult> Get([FromBody] Api1ParcelRequestModel requestModel)
        {
            var inputModel = _mapper.Map<ParcelInputModel>(requestModel);

            return Ok(await _parcelBusinessService.GetLowerstPrice(inputModel));
        }

        [HttpPost]
        [Route("GetTotalInJson2")]

        [Mapping(typeof(Api2ViewModel))]
        public async Task<IActionResult> Get([FromBody] Api2ParcelRequestModel requestModel)
        {
            var inputModel = _mapper.Map<ParcelInputModel>(requestModel);

            return Ok(await _parcelBusinessService.GetLowerstPrice(inputModel));
        }

        [HttpPost]
        [Route("GetTotalXml")]
        [Mapping(typeof(XmlViewModel))]
        public async Task<IActionResult> GetXml(XMLPracelRequestModel xmlRequest)
        {
            var inputModel = _mapper.Map<ParcelInputModel>(xmlRequest);

            JsonSerializer.Serialize()
            return Ok(await _parcelBusinessService.GetLowerstPrice(inputModel));
        }


    }
}
