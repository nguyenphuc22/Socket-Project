using Server.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestLoadProfile : ChatStruct
    {
        string userName;
        
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestLoadProfile)));

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.userName)));
            data.AddRange(Encoding.UTF8.GetBytes(this.userName));

            return data.ToArray();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            ArrayList profile = new ArrayList();
            string query = String.Format("SELECT * from UserData where UserName = '{0}' ", this.userName);
            SQLiteCommand cmd = new SQLiteCommand(query,connectionData);
            DataTable dtUser = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dtUser);

            foreach(DataRow row in dtUser.Rows)
            {
                byte[] ava = new byte[0];
                ava = Convert.FromBase64String(row["Ava"].ToString());

                ResponseLoadProfile p = new ResponseLoadProfile(ava, row["fullName"].ToString(), row["phoneNum"].ToString(), row["mail"].ToString());
                profile.Add(p);
            }

            return profile;

        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4;
            int sizeuserName;

            sizeuserName = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (sizeuserName != 0)
            {
                this.userName = Encoding.UTF8.GetString(buff, offset, sizeuserName);
            }
            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}
