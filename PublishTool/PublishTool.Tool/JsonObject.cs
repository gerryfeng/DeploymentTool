using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishTool.Tool
{
    public delegate void SetProperties(JsonObject Property);

    /// <summary>
    /// Json 对象
    /// </summary>
    public class JsonObject
    {
        public Dictionary<string, JsonProperty> m_properties;

        public JsonObject()
        {
            this.m_properties = null;
        }
        public JsonObject(SetProperties callback)
        {
            callback?.Invoke(this);
        }
        /// <summary>
        /// 判断是否为null
        /// </summary>
        /// <returns></returns>
        public bool IsNull()
        {
            return this.m_properties == null;
        }

        /// <summary>
        /// json字符串格式化
        /// </summary>
        /// <param name="jsonString"></param>
        public void Parse(ref string jsonString)
        {
            int len = jsonString.Length;
            if (String.IsNullOrEmpty(jsonString) || jsonString.Substring(0, 1) != "{" || jsonString.Substring(jsonString.Length - 1, 1) != "}")
            {
                throw new ArgumentException("传入文本不符合 Json 格式。" + jsonString);
            }
            Stack<Char> stack = new Stack<char>();
            Stack<Char> stackType = new Stack<char>();
            StringBuilder sb = new StringBuilder();
            Char cur;
            bool convert = false;
            bool isValue = false;
            bool isStringValue = false;
            JsonProperty last = null;
            for (int i = 1; i <= len - 2; i++)
            {
                cur = jsonString[i];

                // 过滤多余的空白类字符
                if (!isValue && Char.IsWhiteSpace(cur) && stack.Count == 0 && stackType.Count == 0)
                {
                    ;
                }
                // Json 属性名称开始
                else if (!isValue && cur == '\"' && !convert && stack.Count == 0)
                {
                    sb.Length = 0;
                    stack.Push(cur);
                }
                // Json 属性名称结束
                else if (!isValue && cur == '\"' && !convert && stack.Count > 0 && stack.Peek() == cur)
                {
                    stack.Pop();
                }
                // Json 下级对象或数组开始
                else if (isValue && !isStringValue && (cur == '[' || cur == '{') && stack.Count == 0)
                {
                    stackType.Push(cur == '[' ? ']' : '}');
                    sb.Append(cur);
                }
                // Json 下级对象或数组结束
                else if (isValue && !isStringValue && (cur == ']' || cur == '}') && stack.Count == 0 && stackType.Peek() == cur)
                {
                    stackType.Pop();
                    sb.Append(cur);
                }
                // Json 属性值开始
                else if (!isValue && cur == ':' && stack.Count == 0 && stackType.Count == 0)
                {
                    last = new JsonProperty();
                    this[sb.ToString()] = last;
                    isValue = true;
                    sb.Length = 0;
                }
                // Json 属性引号开始
                else if (isValue && !isStringValue && cur == '\"')
                {
                    isStringValue = true;
                    sb.Append(cur);
                }
                // Json 属性引号结束
                else if (isValue && isStringValue && cur == '\"')
                {
                    isStringValue = false;
                    sb.Append(cur);
                }
                // Json 属性值结束
                else if (isValue && !isStringValue && cur == ',' && stack.Count == 0 && stackType.Count == 0)
                {
                    if (last != null)
                    {
                        String temp = sb.ToString();
                        last.Parse(ref temp);
                    }
                    isValue = false;
                    sb.Length = 0;
                }
                // Json 属性名称或属性值记录
                else
                {
                    sb.Append(cur);
                }
            }
            if (sb.Length > 0 && last != null && last.Type == JsonType.Null)
            {
                String temp = sb.ToString();
                last.Parse(ref temp);
            }
        }
        /// <summary>
        /// 将json字符串转化为json对象
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static JsonObject Parse(string jsonString)
        {
            JsonObject jo = new JsonObject();
            jo.Parse(ref jsonString);
            return jo;
        }
        /// <summary>
        /// 获取键值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public JsonProperty this[string propertyName]
        {
            get
            {
                if (this.m_properties == null)
                    this.m_properties = new Dictionary<string, JsonProperty>(StringComparer.OrdinalIgnoreCase);

                if (this.m_properties.ContainsKey(propertyName))
                    return this.m_properties[propertyName];

                JsonProperty newjp = new JsonProperty();
                this.m_properties.Add(propertyName, newjp);

                return newjp;
            }
            set
            {
                if (this.m_properties == null)
                    this.m_properties = new Dictionary<string, JsonProperty>(StringComparer.OrdinalIgnoreCase);

                if (this.m_properties.ContainsKey(propertyName))
                    this.m_properties[propertyName] = (value != null ? value : JsonProperty.Null);
                else
                    this.m_properties.Add(propertyName, value != null ? value : JsonProperty.Null);
            }
        }
        public virtual T Properties<T>(string propertyName) where T : class
        {
            JsonProperty p = this[propertyName];
            if (p != null)
            {
                return p.GetValue<T>();
            }
            return default(T);
        }
        /// <summary>
        /// 获取建值的集合
        /// </summary>
        /// <returns></returns>
        public string[] GetPropertyNames()
        {
            if (this.m_properties == null)
                return new string[] { };

            string[] keys = new string[] { };
            if (this.m_properties.Count > 0)
            {
                keys = new string[this.m_properties.Count];
                this.m_properties.Keys.CopyTo(keys, 0);
            }

            return keys;
        }
        /// <summary>
        /// 判断是否存在对应的key
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool HasProperty(string propertyName)
        {
            if (this.m_properties != null && this.m_properties.ContainsKey(propertyName))
                return true;

            return false;
        }
        /// <summary>
        /// 移除键值对
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public JsonProperty RemoveProperty(string propertyName)
        {
            if (this.m_properties != null && this.m_properties.ContainsKey(propertyName))
            {
                JsonProperty p = this.m_properties[propertyName];
                this.m_properties.Remove(propertyName);
                return p;
            }
            return null;
        }
        /// <summary>
        /// 将json对象转化为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToString("");
        }
        public virtual string ToString(string format)
        {
            if (this.IsNull())
            {
                return "{}";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (string key in this.m_properties.Keys)
                {
                    sb.Append(",");
                    sb.Append("\"").Append(key).Append("\"").Append(":");
                    sb.Append(this.m_properties[key].ToString(format));
                }

                if (this.m_properties.Count > 0)
                {
                    sb.Remove(0, 1);
                }

                sb.Insert(0, "{");
                sb.Append("}");

                return sb.ToString();
            }
        }
    }

    /// <summary>
    /// Json 对象属性类型
    /// </summary>
    public enum JsonType
    {
        String,
        Object,
        Array,
        Number,
        Bool,
        Null
    }

    /// <summary>
    /// Json 对象属性
    /// </summary>
    public class JsonProperty : IEnumerable<JsonProperty>
    {
        private JsonType m_type;
        private string m_string;
        private JsonObject m_object;
        private List<JsonProperty> m_array;
        private bool m_bool;
        private double m_number;

        public JsonProperty()
        {
            this.m_type = JsonType.Null;
            this.m_string = null;
            this.m_object = null;
            this.m_array = null;
        }
        /// <summary>
        /// JsonProperty格式化
        /// </summary>
        /// <param name="value"></param>
        public JsonProperty(Object value)
        {
            this.SetValue(value);
        }

        /// <summary>
        /// jsonString格式化
        /// </summary>
        /// <param name="jsonString"></param>
        public void Parse(ref string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                this.SetValue(null);
            }
            else
            {
                jsonString = jsonString.Trim();

                string first = jsonString.Substring(0, 1);
                string last = jsonString.Substring(jsonString.Length - 1, 1);

                if (first == "[" && last == "]")
                {
                    this.SetValue(ParseArray(ref jsonString));
                }
                else if (first == "{" && last == "}")
                {
                    this.SetValue(JsonObject.Parse(jsonString));
                }
                else if ((first == "'" || first == "\"") && first == last)
                {
                    this.SetValue(ParseString(ref jsonString));
                }
                else if (jsonString == "true" || jsonString == "false")
                {
                    this.SetValue(jsonString == "true" ? true : false);
                }
                else if (jsonString == "null")
                {
                    this.SetValue(null);
                }
                else
                {
                    double d = 0;
                    if (double.TryParse(jsonString, out d))
                    {
                        this.SetValue(d);
                    }
                    else
                    {
                        this.SetValue(jsonString);
                    }
                }
            }
        }
        /// <summary>
        /// jsonString转化为 JsonProperty
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static JsonProperty Parse(string jsonString)
        {
            JsonProperty jsonProperty = new JsonProperty();
            jsonProperty.Parse(ref jsonString);
            return jsonProperty;
        }
        public static List<JsonProperty> ParseArray(ref string jsonString)
        {
            List<JsonProperty> list = new List<JsonProperty>();
            int len = jsonString.Length;
            StringBuilder sb = new StringBuilder();
            Stack<Char> stack = new Stack<char>();
            Stack<Char> stackChild = new Stack<char>();
            Stack<Char> stackType = new Stack<Char>();
            bool conver = false;
            Char cur;

            for (int i = 1; i <= len - 2; i++)
            {
                cur = jsonString[i];

                // 过滤多余的空格类字符
                if (Char.IsWhiteSpace(cur) && stack.Count == 0 && stackType.Count == 0)
                {
                    ;
                }
                // Json 字符串成员开始
                else if (cur == '\"' && stack.Count == 0 && !conver && stackType.Count == 0)
                {
                    sb.Length = 0;
                    sb.Append(cur);
                    stack.Push(cur);
                }
                // Json 转义开始
                else if (cur == '\\' && stack.Count > 0 && !conver)
                {
                    sb.Append(cur);
                    conver = true;
                }
                // Json 转义结束
                else if (conver == true)
                {
                    conver = false;

                    if (cur == 'u')
                    {
                        sb.Append(new char[] { cur, jsonString[i + 1], jsonString[i + 2], jsonString[i + 3] });
                        i += 4;
                    }
                    else
                    {
                        sb.Append(cur);
                    }
                }
                // Json 字符串成员结束
                else if (cur == '\"' && !conver && stack.Count > 0 && stack.Peek() == cur && stackType.Count == 0)
                {
                    sb.Append(cur);
                    list.Add(Parse(sb.ToString()));
                    stack.Pop();
                }
                // Json 数组成员中出现引号
                else if (cur == '\"' && stack.Count == 0 && stackType.Count > 0 && stackChild.Count == 0)
                {
                    sb.Append(cur);
                    stackChild.Push(cur);
                }
                // Json 数组成员中引号结束
                else if (cur == '\"' && stack.Count == 0 && stackType.Count > 0 && stackChild.Count > 0)
                {
                    sb.Append(cur);
                    stackChild.Pop();
                }
                // Json 对象或数组开始
                else if ((cur == '[' || cur == '{') && stack.Count == 0 && stackChild.Count == 0)
                {
                    if (stackType.Count == 0)
                        sb.Length = 0;

                    sb.Append(cur);
                    stackType.Push((cur == '[' ? ']' : '}'));
                }
                // Json 对象或数组结束
                else if ((cur == ']' || cur == '}') && stack.Count == 0 && stackType.Count > 0 && stackType.Peek() == cur && stackChild.Count == 0)
                {
                    sb.Append(cur);
                    stackType.Pop();

                    if (stackType.Count == 0)
                    {
                        list.Add(Parse(sb.ToString()));
                        sb.Length = 0;
                    }
                }
                // Json 数组成员结束
                else if (cur == ',' && stack.Count == 0 && stackType.Count == 0)
                {
                    if (sb.Length > 0)
                    {
                        list.Add(Parse(sb.ToString()));
                        sb.Length = 0;
                    }
                }
                else
                {
                    sb.Append(cur);
                }
            }

            if (stack.Count > 0 || stackType.Count > 0)
            {
                list.Clear();
                throw new ArgumentException("无法解析Json Array对象!");
            }
            else if (sb.Length > 0)
            {
                // 解析最后一个成员
                list.Add(Parse(sb.ToString()));
            }

            return list;
        }
        public static string ParseString(ref string jsonString)
        {
            int len = jsonString.Length;
            StringBuilder sb = new StringBuilder();
            bool conver = false;
            char cur;
            for (int i = 1; i <= len - 2; i++)
            {
                cur = jsonString[i];
                if (cur == '\\' && !conver)
                {
                    conver = true;
                }
                else if (conver == true)
                {
                    conver = false;
                    if (cur == '\\' || cur == '\"' || cur == '\'' || cur == '/')
                    {
                        sb.Append(cur);
                    }
                    else
                    {
                        if (cur == 'u')
                        {
                            String temp = new String(new char[] { cur, jsonString[i + 1], jsonString[i + 2], jsonString[i + 3] });
                            sb.Append((char)Convert.ToInt32(temp, 16));
                            i += 4;
                        }
                        else
                        {
                            switch (cur)
                            {
                                case 'b':
                                    sb.Append('\b');
                                    break;
                                case 'f':
                                    sb.Append('\f');
                                    break;
                                case 'n':
                                    sb.Append('\n');
                                    break;
                                case 'r':
                                    sb.Append('\r');
                                    break;
                                case 't':
                                    sb.Append('\t');
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    sb.Append(cur);
                }
            }
            return sb.ToString();
        }

        public static implicit operator JsonProperty(string value)
        {
            return new JsonProperty(value);
        }
        public static implicit operator JsonProperty(double value)
        {
            return new JsonProperty(value);
        }
        public static implicit operator JsonProperty(Int64 value)
        {
            return new JsonProperty(value);
        }
        public static implicit operator JsonProperty(bool value)
        {
            return new JsonProperty(value);
        }
        public static implicit operator JsonProperty(JsonObject value)
        {
            return new JsonProperty(value);
        }
        public static implicit operator JsonProperty(JsonProperty[] value)
        {
            return new JsonProperty(value);
        }
        public static implicit operator JsonProperty(List<JsonProperty> value)
        {
            return new JsonProperty(value);
        }

        public static implicit operator double(JsonProperty value)
        {
            return value.Number;
        }
        public static implicit operator Int64(JsonProperty value)
        {
            return (Int64)value.Number;
        }
        public static implicit operator Int32(JsonProperty value)
        {
            return (Int32)value.Number;
        }
        public static implicit operator JsonObject(JsonProperty value)
        {
            return value.Object;
        }
        public static implicit operator string(JsonProperty value)
        {
            return value.String;
        }
        public static implicit operator bool(JsonProperty value)
        {
            return value.Bool;
        }
        public static implicit operator List<JsonProperty>(JsonProperty value)
        {
            return value.Array;
        }

        public JsonProperty Add(Object value)
        {
            if (this.m_type != JsonType.Null && this.m_type != JsonType.Array)
            {
                throw new NotSupportedException("Json 属性不是 Array 类型，无法添加元素。");
            }

            if (this.m_array == null)
            {
                this.m_array = new List<JsonProperty>();
            }

            JsonProperty jp = null;
            if (value is JsonProperty)
            {
                jp = value as JsonProperty;
            }
            else
            {
                jp = new JsonProperty(value);
            }

            this.m_array.Add(jp);
            this.m_type = JsonType.Array;

            return jp;
        }
        public void Clear()
        {
            this.m_type = JsonType.Null;
            this.m_string = string.Empty;
            this.m_object = null;
            if (this.m_array != null)
            {
                this.m_array.Clear();
                this.m_array = null;
            }
        }
        public virtual int Count
        {
            get
            {
                int c = 0;
                if (this.m_type == JsonType.Array)
                {
                    if (this.m_array != null)
                    {
                        c = this.m_array.Count;
                    }
                }
                else
                {
                    c = 1;
                }
                return c;
            }
        }

        public JsonType Type
        {
            get { return this.m_type; }
            set { this.m_type = value; }
        }
        public bool IsNull
        {
            get
            {
                return m_type == JsonType.Null;
            }
        }
        public bool IsJsonObject
        {
            get
            {
                return m_type == JsonType.Object;
            }
        }
        public bool IsString
        {
            get
            {
                return m_type == JsonType.String;
            }
        }
        public bool IsNumber
        {
            get
            {
                return m_type == JsonType.Number;
            }
        }
        public bool IsBool
        {
            get
            {
                return m_type == JsonType.Bool;
            }
        }
        public bool IsArray
        {
            get
            {
                return m_type == JsonType.Array;
            }
        }

        public JsonProperty this[int index]
        {
            get
            {
                JsonProperty r = null;
                if (this.m_type == JsonType.Array)
                {
                    if (this.m_array != null && (this.m_array.Count - 1) >= index)
                    {
                        r = this.m_array[index];
                    }
                }
                else if (index == 0)
                {
                    return this;
                }
                return r;
            }
        }
        public JsonProperty this[string propertyName]
        {
            get
            {
                switch (this.m_type)
                {
                    case JsonType.Null:
                        SetValue(new JsonObject());
                        return this.m_object[propertyName];
                    case JsonType.Object:
                        return this.m_object[propertyName];
                    case JsonType.String:
                    case JsonType.Array:
                    case JsonType.Number:
                    case JsonType.Bool:
                    default:
                        return new JsonProperty();
                }
            }
            set
            {
                switch (this.m_type)
                {
                    case JsonType.Null:
                        SetValue(new JsonObject());
                        this.m_object[propertyName] = value;
                        break;
                    case JsonType.Object:
                        this.m_object[propertyName] = value;
                        break;
                    case JsonType.String:
                    case JsonType.Array:
                    case JsonType.Number:
                    case JsonType.Bool:
                    default:
                        throw new NotSupportedException("Json 属性不是空或对象类型。");
                }
            }
        }

        public bool HasProperty(string propertyName)
        {
            if (this.m_type != JsonType.Object)
                return false;

            return this.m_object.HasProperty(propertyName);
        }

        public Object GetValue()
        {
            if (this.m_type == JsonType.String)
            {
                return this.m_string;
            }
            else if (this.m_type == JsonType.Object)
            {
                return this.m_object;
            }
            else if (this.m_type == JsonType.Array)
            {
                return this.m_array;
            }
            else if (this.m_type == JsonType.Bool)
            {
                return this.m_bool;
            }
            else if (this.m_type == JsonType.Number)
            {
                return this.m_number;
            }
            else
            {
                return null;
            }
        }
        public virtual T GetValue<T>() where T : class
        {
            return (GetValue() as T);
        }
        public virtual void SetValue(object value)
        {
            Clear();

            if (value is string)
            {
                double d = 0;
                if (double.TryParse(value.ToString(), out d) && value.ToString().Substring(0, 1) != "0")
                {
                    this.m_number = d;
                    this.m_type = JsonType.Number;
                }
                else
                {
                    this.m_type = JsonType.String;
                    this.m_string = (string)value;
                }
            }
            else if (value is JsonProperty[])
            {
                this.m_array = new List<JsonProperty>((JsonProperty[])value);
                this.m_type = JsonType.Array;
            }
            else if (value is List<JsonProperty>)
            {
                this.m_array = (List<JsonProperty>)value;
                this.m_type = JsonType.Array;
            }
            else if (value is JsonObject)
            {
                this.m_object = (JsonObject)value;
                this.m_type = JsonType.Object;
            }
            else if (value is bool)
            {
                this.m_bool = (bool)value;
                this.m_type = JsonType.Bool;
            }
            else if (value == null)
            {
                this.m_type = JsonType.Null;
            }
            else
            {
                double d = 0;
                if (double.TryParse(value.ToString(), out d))
                {
                    this.m_number = d;
                    this.m_type = JsonType.Number;
                }
                else
                {
                    throw new ArgumentException("错误的参数类型。");
                }
            }
        }

        public static readonly JsonProperty Null = new JsonProperty();
        public JsonObject Object
        {
            get
            {
                if (this.m_type == JsonType.Object)
                    return this.m_object;

                return null;
            }
        }
        public string String
        {
            get
            {
                if (this.m_type == JsonType.String)
                {
                    return this.m_string;
                }
                else if (this.m_type == JsonType.Number)
                {
                    return this.m_number.ToString();
                }

                return null;
            }
        }
        public double Number
        {
            get
            {
                if (this.m_type != JsonType.Number)
                    return double.NaN;

                return this.m_number;
            }
        }
        public bool Bool
        {
            get
            {
                if (this.m_type != JsonType.Bool)
                    return false;

                return this.m_bool;
            }
        }
        public List<JsonProperty> Array
        {
            get
            {
                if (this.m_type != JsonType.Array)
                    return null;

                return this.m_array;
            }
        }

        public override string ToString()
        {
            return this.ToString("");
        }
        public virtual string ToString(String format)
        {
            StringBuilder sb = new StringBuilder();
            if (this.m_type == JsonType.String)
            {
                sb.Append("\"").Append(this.m_string).Append("\"");
                return sb.ToString();
            }
            else if (this.m_type == JsonType.Bool)
            {
                return this.m_bool ? "true" : "false";
            }
            else if (this.m_type == JsonType.Number)
            {
                return this.m_number.ToString();
            }
            else if (this.m_type == JsonType.Null)
            {
                return "null";
            }
            else if (this.m_type == JsonType.Object)
            {
                return this.m_object.ToString();
            }
            else
            {
                if (this.m_array == null || this.m_array.Count == 0)
                {
                    sb.Append("[]");
                }
                else
                {
                    sb.Append("[");
                    if (this.m_array.Count > 0)
                    {
                        foreach (JsonProperty p in this.m_array)
                        {
                            sb.Append(p.ToString());
                            sb.Append(",");
                        }
                        sb.Length -= 1;
                    }
                    sb.Append("]");
                }
                return sb.ToString();
            }
        }

        public IEnumerator<JsonProperty> GetEnumerator()
        {
            if (m_type != JsonType.Array)
                return null;

            return m_array.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (m_type != JsonType.Array)
                return null;

            return m_array.GetEnumerator();
        }
    }
}
