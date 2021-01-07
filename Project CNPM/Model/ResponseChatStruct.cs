using System;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseChatStruct : ChatStruct
    {

        string sendUserName;
        string recUserName;
        string message;

        public string getrecUserName()
        {
            return this.recUserName;
        }
        public string getMessage()
        {
            return this.sendUserName + ":" + this.message;
        }



        public ResponseChatStruct()
        {
            this.sendUserName = "";
            this.recUserName = "";
            this.message = "";
        }
        public ResponseChatStruct(string sendusername, string recusername, string message)
        {
            this.sendUserName = sendusername;
            this.recUserName = recusername;
            this.message = message;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseChatStruct)));
            if (sendUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(sendUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(sendUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (recUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(recUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(recUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (message != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(message)));
                data.AddRange(Encoding.UTF8.GetBytes(message));
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

            recUserNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (recUserNameLength > 0)
                recUserName = Encoding.UTF8.GetString(buff, offset, recUserNameLength);

            offset += recUserNameLength;

            messageLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (messageLength > 0)
                message = Encoding.UTF8.GetString(buff, offset, messageLength);

            return this;
        }
    }
}
