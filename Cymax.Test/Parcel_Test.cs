using AutoMapper;
using Cymax.Web.BusinessService.Parcel;
using Cymax.Web.Controllers;
using Cymax.Web.DataAccess;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.Feeder;
using Cymax.Web.Models;
using Moq;
using System;
using System.Collections.Generic;
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
    }
}
