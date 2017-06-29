using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCare.Util
{
    public static class ObjectExtensions
    {
        // <summary>
        /// The string representation of null.
        /// </summary>
        private static readonly string Null = "null";

        /// <summary>
        /// The string representation of exception.
        /// </summary>
        private static readonly string Exception = "Exception";

        /// <summary>
        /// To json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The Json of any object.</returns>
        public static string ToJson(this object value)
        {
            if (value == null) return Null;

            try
            {
                string json = JsonConvert.SerializeObject(value, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                return json;
            }
            catch (Exception exception)
            {
                //log exception but dont throw one
                return Exception;
            }
        }
    }
}
