using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseLoadProfile : ChatStruct
    {
        byte[] ava;
        string fullName;
        string phoneNum;
        string mail;
        public ResponseLoadProfile(byte[] a, string name, string phone, string m)
        {
            ava = a;
            fullName = name;
            phoneNum = phone;
            mail = m;
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseLoadProfile)));

            

            data.AddRange(BitConverter.GetBytes((ava.GetLength(0))));
            data.AddRange(ava);

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.fullName)));
            data.AddRange(Encoding.UTF8.GetBytes(this.fullName));

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.phoneNum)));
            data.AddRange(Encoding.UTF8.GetBytes(this.phoneNum));

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.mail)));
            data.AddRange(Encoding.UTF8.GetBytes(this.mail));


            return data.ToArray();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4;
            int  sizeAva, sizeName, sizeFone, sizeMail;

            
            sizeAva = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (sizeAva > 0)
            {
                this.ava = new byte[sizeAva];
                Array.Copy(buff, offset, this.ava, 0, sizeAva);
            }
            offset += sizeAva;

            sizeName = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (sizeName != 0)
            {
                this.fullName = Encoding.UTF8.GetString(buff, offset, sizeName);
            }
            offset += sizeName;

            sizeFone = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (sizeFone != 0)
                this.phoneNum = Encoding.UTF8.GetString(buff, offset, sizeFone);
            offset += sizeFone;

            sizeMail = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (sizeMail != 0)
                this.mail = Encoding.UTF8.GetString(buff, offset, sizeMail);

            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}
