using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Server.Model
{
    class RequestProfile: ChatStruct
    {
        string userName;
        byte[] ava;
        string fullName;
        string phoneNum;
        string mail;

        public RequestProfile()
        {
            userName = "";
            ava = new byte[0];
            fullName = "";
            phoneNum = "";
            mail = "";
        }

        public RequestProfile(string username,byte[] img, string name, string fone, string email)
        {
            userName = username;
            ava = img;
            fullName = name;
            phoneNum = fone;
            mail = email;
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestProfile)));

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.userName)));
            data.AddRange(Encoding.UTF8.GetBytes(this.userName));


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
            int sizeuserName,sizeAva, sizeName, sizeFone, sizeMail;

            sizeuserName = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (sizeuserName != 0)
            {
                this.userName = Encoding.UTF8.GetString(buff, offset, sizeuserName);
            }
            offset += sizeuserName;


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
            string a = Convert.ToBase64String(ava);
            string query = String.Format("Update UserData Set Ava='{0}', fullName='{1}',phoneNum='{2}',mail='{3}' where userName='{4}'",a,this.fullName,this.phoneNum,this.mail,this.userName);
            SQLiteCommand cmd = new SQLiteCommand(query,connectionData);
            cmd.ExecuteNonQuery();
        }
    }
}
