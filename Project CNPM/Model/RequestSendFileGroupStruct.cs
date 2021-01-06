using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestSendFileGroupStruct : ChatStruct
    {
        string sendUserName;
        string recGroupName;
        string filePath;
        string fileName;
        byte[] fileSize;

        public string getrecGroupName()
        {
            return this.recGroupName;
        }
        public RequestSendFileGroupStruct()
        {
            this.fileName = "";
            this.filePath = "";
            this.sendUserName = "";
            this.recGroupName = "";
            this.fileSize = new byte[0];
        }
        public RequestSendFileGroupStruct(string sendusername, string recusername, string filepath, byte[] filesize)
        {
            this.sendUserName = sendusername;
            this.filePath = filepath;
            this.recGroupName = recusername;
            this.fileSize = filesize;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestSendFileGroupStruct)));
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


            this.fileSize = File.ReadAllBytes(filePath);

            if (fileSize != null)
            {

                data.AddRange(BitConverter.GetBytes((fileSize.GetLength(0))));
                data.AddRange(fileSize);

            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }


        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int sendUserNameLength, recUserNameLength, filepathLength, fileSizeLength;

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

            //get file name
            string[] splitedPath = this.filePath.Split(@"\");
            this.fileName = splitedPath[splitedPath.Length - 1];
            offset += filepathLength;

            fileSizeLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (fileSizeLength > 0)
            {
                this.fileSize = new byte[fileSizeLength];
                Array.Copy(buff, offset, fileSize, 0, fileSizeLength);
            }
            return this;
        }
    }
}
