using Cymax.Web.DataAccess;

namespace Cymax.Web.Models
{
    public class ParcelModel : BaseEntity
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public int[] Size { get; set; }
        public int Price { get; set; }
        public int DeliveryHours { get; set; }
    }
}
