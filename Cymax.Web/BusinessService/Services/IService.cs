namespace Cymax.Web.BusinessService.Services
{
    public interface IService
    {
        string ServiceName(string aName);
    }


    public class FirstService : IService
    {
        public string ServiceName(string aName) => $"Microsoft {aName}";

    }

    public class SecondService : IService
    {
        public string ServiceName(string aName) => $"Amazon service {aName}";
    }

    public class ThirsService : IService
    {
        public string ServiceName(string aName) => $" eBay Shopping {aName}";
    }
}
