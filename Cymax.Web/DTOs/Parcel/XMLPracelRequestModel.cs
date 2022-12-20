using Cymax.Web.Core.ModelBindings;
using Microsoft.AspNetCore.Mvc;

namespace Cymax.Web.DTOs.Parcel;
[ModelBinder(BinderType = typeof(XmlModelBinder))]
public class XMLPracelRequestModel
{
    public string Source { get; set; }
    public string Destination { get; set; }
    public int[] Packages { get; set; }
}
