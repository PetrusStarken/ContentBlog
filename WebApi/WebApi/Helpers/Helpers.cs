using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
    public static class Helpers
    {
        public static string GetIp(this HttpContextBase context)
        {
            if (context == null || context.Request == null)
                return string.Empty;

            return context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                   ?? context.Request.UserHostAddress;
        }
    }
}