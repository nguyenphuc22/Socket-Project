using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
//I'LL DO THIS TASK LATER ^^!
namespace Project_CNPM.Model
{
    class ResponseSendFileStruct : ChatStruct
    {
        string sendUserName;
        string recUserName;
        string fileName;
        
        byte[] fileSize;
        public string getRecUserName()
        {
            return this.recUserName;
        }
        public string getFileName()
        {
            return this.fileName;
        }

        public ResponseSendFileStruct()
        {
            this.fileName = "";
            this.sendUserName = "";
            this.recUserName = "";
            this.fileSize = new byte[0];
        }
        public ResponseSendFileStruct(string sendusername, string recusername, string filename, byte[] filesize)
        {
            this.sendUserName = sendusername;
            this.recUserName = recusername;
            this.fileName = filename;
            this.fileSize = filesize;
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
            if (recUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(recUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(recUserName));
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


            this.fileSize = File.ReadAllBytes( fileName);

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
                recUserName = Encoding.UTF8.GetString(buff, offset, recUserNameLength);

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
            File.WriteAllBytes(path+@"\"+this.fileName, this.fileSize);
        }
    }
}
