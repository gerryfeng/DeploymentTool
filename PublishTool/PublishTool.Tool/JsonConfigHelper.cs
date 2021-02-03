using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PublishTool.Tool
{
    public class JsonConfigHelper
    {
        public JObject jObject = null;
        public string this[string key]
        {

            get
            {
                string str = "";
                if (jObject != null)
                {
                    str = GetValue(key);
                }
                return str;
            }
        }
        public JsonConfigHelper(string path)
        {
            jObject = new JObject();
            using (System.IO.StreamReader file = new System.IO.StreamReader(path, Encoding.Default))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    jObject = JObject.Load(reader);
                }
            };
        }
        public T GetValue<T>(string key) where T : class
        {
            return JsonConvert.DeserializeObject<T>(jObject.SelectToken(key).ToString());
        }

        public string GetValue(string key)
        {
            return Regex.Replace((jObject.SelectToken(key).ToString()), @"\s", "");
        }
    }
}
