using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace solid.practices
{
    public class JsonPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());
        }
    }
}
