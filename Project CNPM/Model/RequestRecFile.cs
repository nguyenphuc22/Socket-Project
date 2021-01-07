using System;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestRecFile : ChatStruct
    {




        string sendUserName;
        string path;

        public string getPath()
        {
            return this.path;
        }
        public RequestRecFile()
        {
            this.sendUserName = "";
            this.path = "";
        }
        public RequestRecFile(string sendusername, string path)
        {
            this.sendUserName = sendusername;
            this.path = path;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestRecFile)));
            if (sendUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(sendUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(sendUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));

            if (path != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(path)));
                data.AddRange(Encoding.UTF8.GetBytes(path));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int sendUserNameLength, recUserNameLength, messageLength;

            sendUserNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (sendUserNameLength > 0)
                sendUserName = Encoding.UTF8.GetString(buff, offset, sendUserNameLength);

            offset += sendUserNameLength; //Update offset

            messageLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (messageLength > 0)
                path = Encoding.UTF8.GetString(buff, offset, messageLength);

            return this;
        }

       
    }
}
