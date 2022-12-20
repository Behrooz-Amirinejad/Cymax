using Cymax.Web.DTOs.Parcel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml;
using System.Xml.Linq;

namespace Cymax.Web.Core.ModelBindings;

public class XmlModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {

        if (bindingContext == null)
            throw new ArgumentNullException(nameof(bindingContext));
        string xmlValue = string.Empty;
        var sr = new StreamReader(bindingContext.HttpContext.Request.Body);
            xmlValue = await sr.ReadToEndAsync();

        XDocument xdoc = new XDocument();
        xdoc = XDocument.Parse(xmlValue);

        var xmlRequest = new XMLPracelRequestModel()
        {
            Source = xdoc.Root.Element("source").Value,
            Destination = xdoc.Root.Element("destination").Value
        };


        var list = new List<int>();

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlValue);
        XmlNodeList idNodes = doc.SelectNodes("xml/packages/p");
        foreach (XmlNode node in idNodes)
            list.Add(Convert.ToInt32(node.InnerText));

        xmlRequest.Packages = list.ToArray();

        bindingContext.Result = ModelBindingResult.Success(xmlRequest);

        //return bindingContext;
    }

   
}
