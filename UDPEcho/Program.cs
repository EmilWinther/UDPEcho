using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPEcho
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize
            UdpClient socket  = new UdpClient();
            socket.Client.Bind(new IPEndPoint(IPAddress.Any, 65000));

            
            while (true) //Makes me able to keep echoing
            {
                //Receive data
                IPEndPoint from = null;
                byte[] data = socket.Receive(ref from);
                string dataString = Encoding.UTF8.GetString(data);
                Console.WriteLine("Received from client: " + dataString);

                dataString = "Emil" + dataString;
                byte[] toBeSend = Encoding.UTF8.GetBytes(dataString);

                //Echo back data
                socket.Send(toBeSend, toBeSend.Length, from);
            }
        }
    }
}
