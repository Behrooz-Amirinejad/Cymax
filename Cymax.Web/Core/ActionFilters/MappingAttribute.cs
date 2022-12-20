namespace Cymax.Web.Core.ActionFilters
{
    public class MappingAttribute : Attribute
    {
        private readonly Type _mappingType;

        public MappingAttribute(Type mappingType)
        {
            this._mappingType = mappingType;
        }

        public Type MappingType => _mappingType; 
    }
}
