using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server
{
    class Routes
    {
        public static string  GetRoutes(string parameters)
        {

            parameters = parameters.Replace("\0", string.Empty);

            if(Regex.IsMatch(parameters, @"^auth?.*"))
            {
                Match match = Regex.Match(parameters, @"login=(.*)&password=(.*)");
                string name = "";
                string password = "";
                if (match.Success)
                {
                    name = match.Groups[1].Value;
                    password = match.Groups[2].Value;
                }
                
                int i = 0;
            }
            
            return "page 404"; 
        }
    }
}
