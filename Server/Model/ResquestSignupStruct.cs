using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
{
    class ResquestSignupStruct : ChatStruct
    {
        string userName;
        string passWord;
        public ResquestSignupStruct()
        {
            this.userName = "";
            this.passWord = "";
        }



        public ResquestSignupStruct(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResquestSignupStruct)));
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
        public override ArrayList readData(SQLiteConnection connectionData)
        {
            string query = String.Format("SELECT * FROM UserData Where userName = '{0}'", this.userName);
            ArrayList array = new ArrayList();
            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                array.Add(row.ToString());
            }
            return array;
        }
        public override void writeData(SQLiteConnection connectionData)
        {



            string query = "INSERT into UserData(userName, passWord) VALUES(' "+this.userName+" ' , ' "+ this.passWord+ " ' )";
            SQLiteCommand cmd = new SQLiteCommand(connectionData);
            cmd.CommandText = "INSERT into UserData(userName, passWord) VALUES(@userName,@passWord)";
            cmd.Parameters.AddWithValue("@userName", this.userName);
            cmd.Parameters.AddWithValue("@passWord", this.passWord);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }

        }
    }
}

