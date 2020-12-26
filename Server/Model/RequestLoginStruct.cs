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
<<<<<<< HEAD

=======
>>>>>>> 112280c120a5bbf61d6604a20cac7482b3f2f4a2
        string userName;
        string passWord;
        public RequestLoginStruct()
        {
<<<<<<< HEAD

=======
            this.userName = "";
            this.passWord = "";
>>>>>>> 112280c120a5bbf61d6604a20cac7482b3f2f4a2
        }
        public RequestLoginStruct(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
<<<<<<< HEAD
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestLoginStruct)));
=======
            data.Add(Convert.ToByte(Convert.ToInt32(MessageType.RequestLoginStruct)));
>>>>>>> 112280c120a5bbf61d6604a20cac7482b3f2f4a2
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
<<<<<<< HEAD
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
=======
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
>>>>>>> 112280c120a5bbf61d6604a20cac7482b3f2f4a2
        }



        public override ArrayList readData(SQLiteConnection connectionData)
        {
<<<<<<< HEAD
            string query = String.Format( "SELECT * FROM UserData Where userName = '{0}' and passWord = '{1}' ", this.userName , this.passWord);
            ArrayList array = new ArrayList();

            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);

            DataTable dt = new DataTable();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            // data type table
            adapter.Fill(dt);
            // Columns không trả lại object. nên không get list được.
            //var a = dt.Columns["NameGroup"];
            // Lấy như mảng hai chiều bình thường. b = {Working,phucvr}
            //var b = dt.Rows[0]["Name Columns"];
            foreach(DataRow row in dt.Rows)
            {
                array.Add(row.ToString());
            }
            // neu khong tim thay ai thi array se return lai voi mang bang 0
            return array;
=======
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
>>>>>>> 112280c120a5bbf61d6604a20cac7482b3f2f4a2
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public bool isCorrect(string userName,string passWord)
        {
            if(this.userName == userName && this.passWord == passWord)
            {
                return true;
            }
=======
        public bool isPassword(string passWord)
        {
            if (this.passWord == passWord)
                return true;
>>>>>>> 112280c120a5bbf61d6604a20cac7482b3f2f4a2
            return false;
        }
    }
}
