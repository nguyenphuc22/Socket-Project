using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Server.Model
{
    class RequestHistoryMessageStruct : ChatStruct
    {
        string sendUserName;
        string recUserName;

        public RequestHistoryMessageStruct()
        {
            this.recUserName = "";
            this.recUserName = "";
        }

        public RequestHistoryMessageStruct(string sendUserName, string recUserName)
        {
            this.sendUserName = sendUserName;
            this.recUserName = recUserName;
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestHistoryMessage)));
            if (this.recUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.recUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(this.recUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (this.sendUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.sendUserName)));
                data.AddRange(Encoding.UTF8.GetBytes(this.sendUserName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            ArrayList data = new ArrayList();
            string query;
            ArrayList array;
            SQLiteCommand cmd;
            DataTable dt;
            SQLiteDataAdapter adapter;
            if(this.recUserName.Contains("Group:"))
            {
                query = String.Format("SELECT * FROM GroupMessage Where nameGroup = '{0}'",this.recUserName);
                array = new ArrayList();
                cmd = new SQLiteCommand(query, connectionData);

                dt = new DataTable();

                adapter = new SQLiteDataAdapter(cmd);
                // data type table
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string message;
                    
                    message = row["sender"].ToString() + ":" + row["message"].ToString();
                    
                    data.Add(message);
                }
                return data;
            }

            query = String.Format("SELECT * FROM PrivateBox Where (userName1 = '{0}' or userName1='{1}') and (userName2 ='{1}' or userName2='{0}') ",
                this.sendUserName, this.recUserName);
            array = new ArrayList();
            cmd = new SQLiteCommand(query, connectionData);

            dt = new DataTable();

            adapter = new SQLiteDataAdapter(cmd);
            // data type table
            adapter.Fill(dt);

            // Columns không trả lại object. nên không get list được.
            //var a = dt.Columns["NameGroup"];
            // Lấy như mảng hai chiều bình thường. b = {Working,phucvr}
            //var b = dt.Rows[0]["Name Columns"];
            foreach (DataRow row in dt.Rows)
            {
                array.Add(row["idBox"]);
            }
            // neu khong tim thay ai thi array se return lai voi mang bang 0

            for (int i = 0; i < array.Count; i++)
            {
                query = String.Format("SELECT * FROM PrivateMessage Where idBox = {0} ORDER BY time ", array[i]);

                cmd = new SQLiteCommand(query, connectionData);

                dt = new DataTable();

                adapter = new SQLiteDataAdapter(cmd);
                // data type table
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string message;

                    message = row["sender"] + ":" + row["message"].ToString();

                    data.Add(message);
                }

            }

           

            return data;
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int userNameLength, passWordLength;

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (userNameLength > 0)
                this.recUserName = Encoding.UTF8.GetString(buff, offset, userNameLength);

            offset += userNameLength; //Update offset

            passWordLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (passWordLength > 0)
                this.sendUserName = Encoding.UTF8.GetString(buff, offset, passWordLength);

            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}

