using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestChatStruct : ChatStruct
    {

        string sendUserName;
        string recUserName;
        string message;

        public string getRecUserName()
        {
            return this.recUserName;
        }

        public RequestChatStruct()
        {
            this.sendUserName = "";
            this.recUserName = "";
            this.message = "";
        }
        public RequestChatStruct(string sendusername, string recusername, string message)
        {
            this.sendUserName = sendusername;
            this.recUserName = recusername;
            this.message = message;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestChatStruct)));
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
            if (message != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(message)));
                data.AddRange(Encoding.UTF8.GetBytes(message));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            string query = String.Format("SELECT * FROM PrivateBox Where (userName1 = '{0}' or userName1='{1}') and (userName2 ='{1}' or userName2='{0}') ", 
                this.sendUserName,this.recUserName);
            ArrayList array = new ArrayList();
            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            adapter.Fill(dt);

            if(dt.Rows.Count == 0)
            {
                string writeQuery = String.Format("INSERT INTO PrivateBox (userName1, userName2) values ('{0}','{1}')", this.sendUserName, this.recUserName);
                cmd = new SQLiteCommand(writeQuery, connectionData);
                cmd.ExecuteNonQuery();

                query = String.Format("SELECT * FROM PrivateBox Where (userName1 = '{0}' or userName2='{1}) and (userName2 ='{1}' or userName2='{0}) ",
                this.sendUserName, this.recUserName);
                array = new ArrayList();
                cmd = new SQLiteCommand(query, connectionData);
                dt = new DataTable();
                adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                array.Add(row["idBox"]);
            }
            
            return array;
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int sendUserNameLength, recUserNameLength, messageLength;

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

            messageLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (messageLength > 0)
                message = Encoding.UTF8.GetString(buff, offset, messageLength);

            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            ArrayList idbox = this.readData(connectionData);
            DateTime time = DateTime.Now;
            if (idbox.Count == 0)
                return;
            string query = String.Format("INSERT INTO PrivateMessage (idBox, sender, time,message) values ({0},'{1}', '{2}', '{3}')",
                idbox[0], this.sendUserName, time.ToString(), this.message);
            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);
            cmd.ExecuteNonQuery();
            
        }
    }
}
