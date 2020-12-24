using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestLoginStruct : ChatStruct
    {
        string userName;
        string passWord;
        public RequestLoginStruct()
        {
            this.userName = "";
            this.passWord = "";
        }
        public RequestLoginStruct(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.Add(Convert.ToByte(Convert.ToInt32(MessageType.RequestLoginStruct)));
            if (userName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(userName)));
                data.AddRange(Encoding.UTF8.GetBytes(userName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (passWord != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(passWord)));
                data.AddRange(Encoding.UTF8.GetBytes(passWord));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            string query = "SELECT * FROM UserData Where userName = '" + this.userName + "'";
            ArrayList data = new ArrayList();
            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                data.Add(dt.Columns["userName"].ToString());
                data.Add(dt.Columns["passWord"].ToString());
                return data;
            }
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int userNameLength, passWordLength;

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (userNameLength > 0)
                userName = Encoding.UTF8.GetString(buff, offset, userNameLength);

            offset += userNameLength; //Update offset

            passWordLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (passWordLength > 0)
                passWord = Encoding.UTF8.GetString(buff, offset, passWordLength);

            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }

        public bool isPassword(string passWord)
        {
            if (this.passWord == passWord)
                return true;
            return false;
        }
    }
}
