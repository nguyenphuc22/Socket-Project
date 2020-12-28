using System;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestHistoryMessageStruct : ChatStruct
    {
        string sendUserName;
        string recUserName;

        public RequestHistoryMessageStruct()
        {
            this.recUserName = "";
            this.recUserName = "";
        }

        public RequestHistoryMessageStruct(string sendUserName,string recUserName)
        {
            this.sendUserName = sendUserName;
            this.recUserName = recUserName;
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestLoginStruct)));
            if (this.recUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.recUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(this.recUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (this.sendUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.sendUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(this.sendUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int userNameLength, passWordLength;

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (userNameLength > 0)
                this.recUserName = Encoding.UTF8.GetString(buff, offset, userNameLength);

            offset += userNameLength; //Update offset

            passWordLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (passWordLength > 0)
                this.sendUserName = Encoding.UTF8.GetString(buff, offset, passWordLength);

            return this;
        }
    }
}
