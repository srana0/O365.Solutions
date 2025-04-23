using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fidelity.DocCentral.RESTWebAPI
{
    public class SelectExpandWrapper<TElement>
    {
        public PropertyContainer Container { get; set; }
    }
    internal abstract class PropertyContainer
    {
        public Dictionary<string, object> ToDictionary(bool includeAutoSelected = true);
    }
}