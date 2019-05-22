using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using solid.practices.Core.Interfaces;

namespace solid.practices
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromString(string policyString)
        {
            return JsonConvert.DeserializeObject<Policy>(policyString,new StringEnumConverter());
        }
    }
}
