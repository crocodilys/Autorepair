using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRipeir
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string host;
            int port = 3381;

            host = Dns.GetHostName();

            if (Server.getInstance().ConnectSocket(host, port))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Auth());
            } else 
            {
                MessageBox.Show("Server sleep=)");
            }
        }
    }
}
