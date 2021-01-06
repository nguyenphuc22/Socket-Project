using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseRecFileGroup : ChatStruct
    {
        string fileName;
        byte[] fileSize;

        public ResponseRecFileGroup()
        {
            this.fileName = "";
            this.fileSize = new byte[0];
        }
        public ResponseRecFileGroup(string filename, byte[] filesize)
        {

            this.fileName = filename;
            this.fileSize = filesize;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseRecFileGroup)));

            if (fileName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(fileName)));
                data.AddRange(Encoding.UTF8.GetBytes(fileName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));



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
            int filenameLength, fileSizeLength;
            filenameLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (filenameLength != 0)
                this.fileName = Encoding.UTF8.GetString(buff, offset, filenameLength);
            offset += filenameLength;

            fileSizeLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (fileSizeLength > 0)
            {
                this.fileSize = new byte[fileSizeLength];
                Array.Copy(buff, offset, fileSize, 0, fileSizeLength);
            }
            return this;
        }
        public void writeData(string path)
        {
            if (Directory.Exists(path))
            {
                File.WriteAllBytes(path + @"\" + this.fileName, this.fileSize);
            }
            else
            {
                Directory.CreateDirectory(path);
                File.WriteAllBytes(path + @"\" + this.fileName, this.fileSize); ;
            }

        }
    }
}
