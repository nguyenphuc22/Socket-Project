
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
//I'LL DO THIS TASK LATER ^^!
namespace Project_CNPM.Model
{
    class RequestSendFileStruct : ChatStruct
    {





        string sendUserName;
        string recUserName;
        string filePath;
        string fileName;
        byte[] fileSize;

        public string getrecUserName()
        {
            return this.recUserName;
        }
        public RequestSendFileStruct()
        {
            this.fileName = "";
            this.filePath = "";
            this.sendUserName = "";
            this.recUserName = "";
            this.fileSize = new byte[0];
        }
        public RequestSendFileStruct(string sendusername, string recusername, string filepath, byte[] filesize)
        {
            this.sendUserName = sendusername;
            this.filePath = filepath;
            this.recUserName = recusername;
            this.fileSize = filesize;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestSendFileStruct)));
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
                recUserName = Encoding.UTF8.GetString(buff, offset, recUserNameLength);

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
        public bool checkFileSize()
        {
            return (this.fileSize.Length <= (1024 * 1024 * 25));
        }
    }
}
