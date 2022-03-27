using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ORMDapper
{
    public static class AppConnection
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
    }
}
