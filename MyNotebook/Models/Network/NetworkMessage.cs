using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyNotebook.Models.Network
{
    [Serializable]
    public class NetworkMessage
    {
        public NetworkMessageType NetworkMessageType { get; private set; }
        public string UTF8String { get; private set; }
        public Test Test { get; private set; }

        public NetworkMessage()
        {
        }

        public NetworkMessage(NetworkMessageType networkMessageType, string uTF8String)
        {
            NetworkMessageType = networkMessageType;
            UTF8String = uTF8String ?? throw new ArgumentNullException(nameof(uTF8String));
        }

        public NetworkMessage(NetworkMessageType networkMessageType, string uTF8String, Test test) : this(networkMessageType, uTF8String)
        {
            Test = test ?? throw new ArgumentNullException(nameof(test));
        }

        public byte[] ToByteArray()
        {
            NetworkMessage obj = this;

            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        public static NetworkMessage FromByteArray(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj as NetworkMessage;
        }
    }
}
