using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace MyNotebook.Models
{
    public class NetworkServer
    {
        public string Ip { get; private set; }
        public int Port { get; private set; }

        IPEndPoint endPoint;
        Socket socket;

        public NetworkServer(int port)
        {
            string host = Dns.GetHostName();
            IPAddress _ip = Dns.GetHostByName(host).AddressList[0];

            Ip = _ip.ToString();
            Port = port;

            endPoint = new IPEndPoint(IPAddress.Parse(Ip), port); // штука с помощью которой слушает
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // слушает

            socket.Bind(endPoint); // связываяем socket и endPoint
        }

        public byte[] Listen(byte[] feedback)
        {
            socket.Listen(5);

            Socket listener = socket.Accept(); // сюда подключается клиент
            byte[] buffer = new byte[256];
            int size = 0;
            List<byte> data = new List<byte>();

            do
            {
                size = listener.Receive(buffer);
                Array.Resize(ref buffer, size);
                data.AddRange(buffer);
            } while (listener.Available > 0);

            // data - то, что мы получили от клиента
            // listener.Send(); - можно отправить ответ

            listener.Send(feedback);

            listener.Shutdown(SocketShutdown.Both); // выключение

            return data.ToArray();
        }
    }
}
