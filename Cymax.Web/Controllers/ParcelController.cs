using AutoMapper;
using Cymax.Web.BusinessService.Parcel;
using Cymax.Web.Core.ActionFilters;
using Cymax.Web.Core.ModelBindings;
using Cymax.Web.DTOs.Parcel;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.MSBuild;
using System.Reflection;
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
        private readonly ILogger<ParcelController> _logger;

        public ParcelController(IParcelBusinessContract parcelBusinessContract,
                                IMapper mapper,
                                ILogger<ParcelController> logger)
        {
            this._parcelBusinessService = parcelBusinessContract;
            this._mapper = mapper;
            this._logger = logger;
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

            return Ok( await _parcelBusinessService.GetLowerstPrice(inputModel));
        }

        [HttpPost]
        [Route("GetTotalXml")]
        [Mapping(typeof(XmlViewModel))]
        public async Task<IActionResult> GetXml(XMLPracelRequestModel xmlRequest)
        {
            var inputModel = _mapper.Map<ParcelInputModel>(xmlRequest);

            //JsonSerializer.Serialize();
            return Ok(await _parcelBusinessService.GetLowerstPrice(inputModel));
        }

        [HttpGet]
        [Route("GetAssembelies")]
        public IActionResult GetAssembly()
        {
            //var assemList = AppDomain.CurrentDomain.GetAssemblies()
            //                                   //.Where(x => x.FullName.Contains("Cymax.Domain"))
            //                                   .ToList();
            //
            //assemList.ForEach(assem =>
            //{
            //    _logger.LogError("-->", assem.FullName ?? "Can not convertName");
            //});

            var assemList = Assembly.Load("Cymax.Domain")
                                              .GetTypes()
                                              .ToList();
            return Ok(assemList);
        }


        [HttpGet]
        [Route("GetAssembelyes")]
        public IActionResult GetAssemblyes()
        {
            var entry = Assembly.GetEntryAssembly();

            var assemList = entry
               // This will get B and C with type: `AssemblyName`
               .GetReferencedAssemblies()
               // Load assembly B and C.
               .Select(t => Assembly.Load(t))
               // Get all class in B and C.
               .SelectMany(t => t.GetTypes())
               .Where(x => x.FullName.Contains("Cymax"))
               .ToList();

            var assemLists = Assembly.GetEntryAssembly()
                                                   //.Where(x => x.FullName.Contains("Cymanx"))
                                                   .GetReferencedAssemblies()
                                                   .ToList();

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName);


            //assemList.ForEach(assem =>
            //{
            //    try
            //    {
            //    }
            //    catch (Exception ex)
            //    {
            //
            //        throw;
            //    }
            //});


            //var workspace = MSBuildWorkspace.Create();
            //var solution = workspace.OpenSolutionAsync(path).Result;
            //var projects = solution.Projects;
            //foreach (var project in projects)
            //{
            //    _logger.LogError("==>", project.Name);
            //}

            return Ok(assemList);
        }


    }
}
