using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Recursion
{
    public class FlatternDictionary
    {
        public static void FlatternDictionaryDemo()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>() {
                { "Key1", "1"},
                { "Key2" , new  Dictionary<string, object>(){ { "a", "2" }, { "b", "3" },{ "","5"} } },
                { "" , "4" }
            };
            FlattenDictionary(dict);
        }
        public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (dict == null || dict.Count == 0) return result;
            return result;
        }

        public static void Helper(Dictionary<string, string> result, Dictionary<string, object> dict, string parentKey)
        {
            foreach (var key in dict.Keys)
            {
                object parentValue = dict[key];
                if (parentValue.GetType() == dict.GetType())
                {
                    if (string.IsNullOrEmpty(parentKey))
                        Helper(result, (Dictionary<string, object>)parentValue, key);
                    else
                        Helper(result, (Dictionary<string, object>)parentValue, parentKey + "." + key);
                }
                else
                {
                    if (string.IsNullOrEmpty(parentKey))
                        result.Add(key, Convert.ToString(parentValue));
                    else
                    {
                        if (string.IsNullOrEmpty(key))
                            result.Add(parentKey, Convert.ToString(parentValue));
                        else
                            result.Add(parentKey + "." + key, Convert.ToString(parentValue));

                    }
                }
            }
        }
    }
}
