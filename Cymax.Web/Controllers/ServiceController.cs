﻿using Cymax.Web.BusinessService.Services;
using Cymax.Web.Core.ModelBindings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cymax.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService _service;
        private string value = "Amazon";
        public ServiceController(Func<string, IService> serviceResolver, IHttpContextAccessor contextAccessor)
        {
            _service = serviceResolver(value);
        }

        [HttpGet]
        public IActionResult GetContextValue()
        {
            return Ok(_service.ServiceName(this.value));
        }

        [HttpGet]
        public IActionResult GetCotnext([ModelBinder(BinderType = typeof(YesNoBooleanModelBinder))] bool isValid)
        {
            return Ok();
        }
    }
}
