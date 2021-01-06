using System;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseSendFileGroupStruct : ChatStruct
    {
        string sendUserName;
        string recGroupName;
        string filePath;

        public string getUserName()
        {
            return this.sendUserName;
        }

        public string getrecUserName()
        {
            return this.recGroupName;
        }
        public ResponseSendFileGroupStruct()
        {

            this.filePath = "";
            this.sendUserName = "";
            this.recGroupName = "";

        }
        public ResponseSendFileGroupStruct(string sendusername, string recGroupName, string filepath)
        {
            this.sendUserName = sendusername;
            this.filePath = filepath;
            this.recGroupName = recGroupName;


        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseSendFileStruct)));
            if (sendUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(sendUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(sendUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (recGroupName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(recGroupName)));
                data.AddRange(Encoding.UTF8.GetBytes(recGroupName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (filePath != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(filePath)));
                data.AddRange(Encoding.UTF8.GetBytes(filePath));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));



            return data.ToArray();
        }

        
        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int sendUserNameLength, recUserNameLength, filepathLength;

            sendUserNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (sendUserNameLength > 0)
                sendUserName = Encoding.UTF8.GetString(buff, offset, sendUserNameLength);

            offset += sendUserNameLength; //Update offset

            recUserNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (recUserNameLength > 0)
                recGroupName = Encoding.UTF8.GetString(buff, offset, recUserNameLength);

            offset += recUserNameLength;

            filepathLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (filepathLength > 0)
                this.filePath = Encoding.UTF8.GetString(buff, offset, filepathLength);

            return this;
        }
        // Remember to change the path( where you store the data0


        
    }
}
