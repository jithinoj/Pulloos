using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ADMS.Common
{
    public static class JsonResultHelper
    {
        public static JsonResult CreateJsonResult(List<KeyValuePair<string, string>> dictionary)
        {
            var jsonBuilder = new StringBuilder();

            var jsonResult = new JsonResult();

            jsonBuilder.Append("{");

            foreach (var item in dictionary)
            {
                jsonBuilder.Append("\"" + item.Key + "\" : \"" + item.Value + "\",");
            }

            string result = jsonBuilder.ToString().TrimEnd(',');

            result += "}";

            jsonResult.Data = result;

            return jsonResult;
        }
    }
}