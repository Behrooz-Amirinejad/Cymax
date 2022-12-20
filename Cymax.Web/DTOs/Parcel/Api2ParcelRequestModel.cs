namespace Cymax.Web.DTOs.Parcel
{
    public class Api2ParcelRequestModel
    {
        public string consignee { get; set; }
        public string consignor { get; set; }
        public int[] Cartons { get; set; } = { 0, 0, 0 };
    }
}
