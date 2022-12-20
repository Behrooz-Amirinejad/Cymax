namespace Cymax.Web.DTOs.Parcel
{
    public class Api1ParcelRequestModel
    {
        public string ContactAddress { get; set; }
        public string WarehouseAddress  { get; set; }
        public int[] Dimentions { get; set; } = { 0, 0, 0 };
    }
}
