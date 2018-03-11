using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverLocationPlotter.Infrastructure
{
    public static class SqlConnect
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["AmbRes_Online"].ConnectionString;

        }
    }
}