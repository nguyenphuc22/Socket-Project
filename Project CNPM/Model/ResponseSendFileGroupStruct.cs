using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseSendFileGroupStruct : ChatStruct
    {
        string sendUserName;
        string recGroupName;
        string fileName;

        byte[] fileSize;
        public string getRecGroupName()
        {
            return "Group:" +    this.recGroupName;
        }

        public string getFileName()
        {
            return this.fileName;
        }

        public ResponseSendFileGroupStruct()
        {
            this.fileName = "";
            this.sendUserName = "";
            this.recGroupName = "";
            this.fileSize = new byte[0];
        }
        public ResponseSendFileGroupStruct(string sendusername, string recGroupName, string filename, byte[] filesize)
        {
            this.sendUserName = sendusername;
            this.recGroupName = recGroupName;
            this.fileName = filename;
            this.fileSize = filesize;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseSendFileGroupStruct)));
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
            if (fileName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(fileName)));
                data.AddRange(Encoding.UTF8.GetBytes(fileName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));


            this.fileSize = File.ReadAllBytes(fileName);

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
            int sendUserNameLength, recUserNameLength, fileNameLength, fileSizeLength;

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

            fileNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (fileNameLength > 0)
                fileName = Encoding.UTF8.GetString(buff, offset, fileNameLength);

            offset += fileNameLength;

            fileSizeLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (fileSizeLength > 0)
            {
                this.fileSize = new byte[fileSizeLength];
                Array.Copy(buff, offset, fileSize, 0, fileSizeLength);
            }
            return this;
        }
        public void Download(string path)
        {
            File.WriteAllBytes(path + @"\" + this.fileName, this.fileSize);
        }

    }
}
