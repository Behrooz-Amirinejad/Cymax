using Cymax.Web.Core.ModelBindings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cymax.Test
{
    public class ContextTest
    {
        [Theory]
        [InlineData("Yes", true)]
        [InlineData("yes", true)]
        [InlineData("No", false)]
        [InlineData("no", false)]
        public async Task BindModelAsync_returns_success_with_with_expected_value(string modelValue, bool expectedResult)
        {
            // Arrange
            var modelBinder = new YesNoBooleanModelBinder();
            var bindingContext = BuildBindingContexts(modelValue);

            // Act
            await modelBinder.BindModelAsync(bindingContext);
            var model = bindingContext.Result.Model as bool?;

            // Assert

            Assert.Equal(expectedResult, model);
        }

        [Fact]
        public async Task BindModelAsync_does_not_bind_if_model_value_is_not_yes_or_no()
        {
            // Arrange
            var modelBinder = new YesNoBooleanModelBinder();
            var bindingContext = BuildBindingContexts("invalid");

            // Act
            await modelBinder.BindModelAsync(bindingContext);

            // Assert
            var model = bindingContext.Result.Model as bool?;

            Assert.False(model);
        }

        private ModelBindingContext BuildBindingContext(string modelValue)
        {
            const string ModelName = "test";
            var bindingContext = new DefaultModelBindingContext
            {
                ModelName = ModelName,
            };

            var bindingSource = new BindingSource("", "", false, false);
            var queryCollection = new QueryCollection(new Dictionary<string, StringValues>
                {
            { ModelName, new StringValues(modelValue) }
                });
            bindingContext.ValueProvider = new QueryStringValueProvider(bindingSource, queryCollection, null);

            //var stream = bindingContext.HttpContext.Request.Body; ;

            return bindingContext;
        }

        private ModelBindingContext BuildBindingContexts(string modelValue)

        {



            //var httpContext = new DefaultHttpContext();
            //v
            //httpContext.Request.Body = stream;
            //httpContext.Request.ContentLength = stream.Length;
            //var bindingContext = new DefaultModelBindingContext();
            //.HttpContext = httpContext;

            string body = @"<xml>
                    	    <source>Toronto</source>
                    	    <destination>Montreal</destination>
                    	    <packages>
                    	    	<p>1</p>
                    	    	<p>22</p>
                    	    	<p>30</p>
                    	    </packages>
                        </xml>";

            var requestData = Encoding.UTF8.GetBytes(body);
            var stream = new MemoryStream(requestData);
            var requestFake = new HttpRequestFeature();
            requestFake.Body = stream;


            var features = new FeatureCollection();
            features.Set<IHttpRequestFeature>(requestFake);
            var fakeHttpContext = new DefaultHttpContext(features);
            fakeHttpContext.Request.Headers.Add("ApplicationHeader", "Values");
            var bindingContexts = new DefaultModelBindingContext
            {
                ModelName = "CustomQueryExpr",
                ActionContext = new ActionContext()
                {
                    HttpContext = fakeHttpContext,
                },
            };





            return bindingContexts;

        }

        private void Test_Header()

        {
            //var actionFilter = new AddDebugInfoToResponse();
            var requiredHeader = "Test";
            //var actionFilter = new RequireCustomHeader(requiredHeader);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers.Add("headerValue", "Value");
            var actionContext = new ActionContext(httpContext,
                new RouteData(),
                new ActionDescriptor(),
                new ModelStateDictionary());
            var actionExecutingContext = new ActionExecutingContext(actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                controller: null);

            //act
            //actionFilter.OnActionExecuting(actionExecutingContext);
        }

    }
}
