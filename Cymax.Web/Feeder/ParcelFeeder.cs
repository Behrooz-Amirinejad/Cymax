using Bogus;
using Cymax.Web.Models;

namespace Cymax.Web.Feeder
{
    public static class ParcelFeeder
    {
        public static List<ParcelModel> GetParcelList()
        {


            return new List<ParcelModel>()
            {
                new ParcelModel(){ Departure = "aa"  , Destination = "hh" , Size = new int[]{10,60,330 } , DeliveryHours = 2 ,  Price =  15},
                new ParcelModel(){ Departure = "bb"  , Destination = "pp" , Size = new int[]{20,50,340 } , DeliveryHours = 3 ,  Price =  10},
                new ParcelModel(){ Departure = "cc"  , Destination = "nn" , Size = new int[]{30,40,350 } , DeliveryHours = 13 , Price =  10},
                new ParcelModel(){ Departure = "dd"  , Destination = "mm" , Size = new int[]{40,30,360 } , DeliveryHours = 12 , Price =  101},
                new ParcelModel(){ Departure = "ff"  , Destination = "xx" , Size = new int[]{50,20,370 } , DeliveryHours = 12 , Price =  70},
                new ParcelModel(){ Departure = "aa"  , Destination = "hh" , Size = new int[]{60,10,380 } , DeliveryHours = 10 , Price =  5 },

            };

        }

        public static List<ParcelModel> GetFakeParcelList()
        {
            var fakeList = new List<ParcelModel>();

            var parcelFake = new Faker<ParcelModel>();

            parcelFake.RuleFor(x => x.Departure, x => x.Lorem.Text());
            parcelFake.RuleFor(x => x.Destination, x => x.Lorem.Random.Word());
            //parcelFake.RuleFor(x => x.Size, x => x.Lorem.Random.ArrayElement<int>(int[3]{ }));
            parcelFake.RuleFor(x => x.DeliveryHours, x => x.Random.Number());
            parcelFake.RuleFor(x => x.Price, x => x.Random.Number(100, 5000));


            for (int i = 0; i < 30; i++)
            {
                fakeList.Add(parcelFake.Generate());
            }

            return fakeList;
        }
    }
}
