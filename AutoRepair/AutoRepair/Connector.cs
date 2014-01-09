using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;



namespace AutoRepair
{
    class Connector
    {

        private static volatile Connector instance = null;

        private Socket s;
 
	    private Connector() 
        {
            string host;
            int port = 3381;

            host = Dns.GetHostName();
            

        }

        public bool ConnectSocket(string server, int port)
        {
            this.s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry("localhost");

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid 
            // an exception that occurs when the host IP Address is not compatible with the address family 
            // (typical in the IPv6 case). 
            foreach (IPAddress address in hostEntry.AddressList)
            {
                try
                {
                    IPEndPoint ipe = new IPEndPoint(address, port);
                    Socket tempSocket =
                        new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    tempSocket.Connect(ipe);

                    if (tempSocket.Connected)
                    {
                        s = tempSocket;
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }

                catch
                {
                    return false;
                }

            }
            return false;
        }

        public bool Send(String message)
        {
            if (s.Send(GetBytes(message)) != 0)
            {
                return true;
            }
            return false;
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);//.Unicode.GetBytes(str);
            return bytes;
        }

	    public static Connector getInstance() 
        {
		    if (instance == null) 
            {
                instance = new Connector();
            }
        return instance;
	    }

    }
}
