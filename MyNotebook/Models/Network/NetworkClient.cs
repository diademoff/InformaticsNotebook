using MyNotebook.Models.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace MyNotebook.Models
{
    public class NetworkClient
    {
        public string Ip { get; private set; }
        public int Port { get; private set; }

        IPEndPoint endPoint;
        Socket socket;
        public NetworkClient(string ip, int port)
        {
            Ip = ip;
            Port = port;

            endPoint = new IPEndPoint(IPAddress.Parse(ip), port); // штука с помощью которой слушает
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //слушает
        }

        ~NetworkClient()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            catch { }
        }

        public NetworkMessage Send(NetworkMessage sendData)
        {
            try
            {
                socket.Connect(endPoint);
            }
            catch { }
            socket.Send(sendData.ToByteArray());

            byte[] buffer = new byte[256];
            int size = 0;
            List<byte> data = new List<byte>();

            do
            {
                size = socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                data.AddRange(buffer);
            } while (socket.Available > 0);

            socket.Shutdown(SocketShutdown.Both);

            try
            {
                return NetworkMessage.FromByteArray(data.ToArray());
            }
            catch
            {
                return new NetworkMessage();
            }
        }
    }
}
