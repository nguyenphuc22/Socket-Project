using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseRecFile : ChatStruct
    {
        string fileName;
        byte[] fileSize;

        public ResponseRecFile()
        {
            this.fileName = "";
            this.fileSize = new byte[0];
        }
        public ResponseRecFile(string filename, byte[] filesize)
        {

            this.fileName = filename;
            this.fileSize = filesize;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseRecFile)));

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

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
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

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}
