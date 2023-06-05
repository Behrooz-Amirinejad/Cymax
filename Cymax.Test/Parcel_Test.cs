using AutoMapper;
using Cymax.Web.BusinessService.Parcel;
using Cymax.Web.Controllers;
using Cymax.Web.Core.ModelBindings;
using Cymax.Web.DataAccess;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.Feeder;
using Cymax.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cymax.Test
{
    public class Parcel_Test
    {
        private readonly IRepository<ParcelModel> _parcelRepo;



        [Fact]
        public async Task PcelSelect_Test()
        {
            // Arrage
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<IRepository<ParcelModel>> mockRepo = new Mock<IRepository<ParcelModel>>();
            var mockSets = new Mock<List<ParcelModel>>();

            mockRepo.Setup(t => t.Gets())
                    .ReturnsAsync(mockSets.Object);

            var business = new ParcelBusinessService(mockRepo.Object,
                                                     mockMapper.Object);

            //act
            var result = await business.GetLowerstPrice(It.IsAny<ParcelInputModel>());// new ParcelInputModel() { From = "aa", To = "hh" });

            //var item = It.IsAny<ParcelModel>();

            Assert.NotNull(result);
            Assert.IsType<ParcelOutputModel>(result);
            //Assert.Equal(result.Value, 5);


        }

        [Fact]
        public async Task Model_Binging_Test()
        {
            string body = @"<xml>
                    	    <source>Toronto</source>
                    	    <destination>Montreal</destination>
                    	    <packages>
                    	    	<p>1</p>
                    	    	<p>22</p>
                    	    	<p>30</p>
                    	    </packages>
                        </xml>";

            var bindingContext = new DefaultModelBindingContext();

            var bindingSource = new BindingSource("", "", false, false);
            var routeValueDictionary = new RouteValueDictionary
        {
            {"IsSingleWay", true},
            {"JourneyType", "Single"}
        };
            bindingContext.ValueProvider = new RouteValueProvider(bindingSource, routeValueDictionary);

            var binder = new XmlModelBinder();
            binder.BindModelAsync(bindingContext);

            Assert.True(bindingContext.Result.IsModelSet);
            //Assert.Equal(JourneyTypes.Single, bindingContext.Result.Model);

        }
    }
}
