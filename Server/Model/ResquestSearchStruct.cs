
using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Server.Model
{
    class ResquestSearchStruct : ChatStruct
    {
        string userName;
        string search;
        public ResquestSearchStruct()
        {
            this.userName = "";
            this.search = "";
        }
        public ResquestSearchStruct(string search, string userName)
        {
            this.userName = userName;
            this.search = search;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResquestSearchStruct)));

            if (this.search != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.search)));
                data.AddRange(Encoding.UTF8.GetBytes(this.search));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));

            if (this.userName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.userName)));
                data.AddRange(Encoding.UTF8.GetBytes(this.userName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));

            return data.ToArray();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            ArrayList recentMsg = new ArrayList();
            string queryUser;
            if (this.search != "all")
            {
                queryUser = String.Format("SELECT * FROM UserData Where userName like '{0}%'"
                                 , this.search);

            }
            else
            {
                queryUser = String.Format("SELECT * FROM UserData");
            }

            SQLiteCommand cmdUser = new SQLiteCommand(queryUser, connectionData);

            DataTable dtUser = new DataTable();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmdUser);
            // data type table
            adapter.Fill(dtUser);

            foreach (DataRow row in dtUser.Rows)
            {
                byte[] i = new byte[0];
                /*i = Convert.FromBase64String(row["Ava"].ToString());*/

                RecentMessage r = new RecentMessage(row["userName"].ToString(), " ", i);
                recentMsg.Add(r);
            }







            /* if(this.search != "all")
             {
                 queryUser = String.Format("SELECT DISTINCT nameGroup FROM GroupChat Where NameGroup like '{0}%' and UserName = '{1}'"
                , this.search,this.userName);
             } else
             {
                 queryUser = String.Format("SELECT * FROM GroupChat");
             }

             cmdUser = new SQLiteCommand(queryUser, connectionData);

             dtUser = new DataTable();

             adapter = new SQLiteDataAdapter(cmdUser);
             // data type table
             adapter.Fill(dtUser);

             foreach (DataRow row in dtUser.Rows)
             {
                 recent.Add("Group:"+row["NameGroup"].ToString());
             }
            */

            queryUser = String.Format("select userName,message,Ava, pb.idBox " +
               "FROM PrivateMessage pm,PrivateBox pb, UserData ud " +
               "where(pb.userName1 = '{0}' or pb.userName2 = '{0}')and pm.idBox = pb.idBox and " +
               "pm.time = (SELECT max(pm1.time) FROM PrivateMessage pm1 Where pm.idBox = pm1.idBox) " +
               "and(ud.userName != '{0}' and(ud.userName = pb.userName1 or ud.userName = pb.userName2))", this.userName);
            cmdUser = new SQLiteCommand(queryUser, connectionData);

            dtUser = new DataTable();

            adapter = new SQLiteDataAdapter(cmdUser);
            // data type table
            adapter.Fill(dtUser);
            ArrayList arrBoxMsg = new ArrayList();
            foreach (DataRow row in dtUser.Rows)
            {
                byte[] i = new byte[0];
                i = Convert.FromBase64String(row["Ava"].ToString());

                RecentMessage recent = new RecentMessage(row["userName"].ToString(), row["message"].ToString(), i);
                arrBoxMsg.Add(recent);
            }
            for (int i = 0; i < recentMsg.Count; i++)
            {
                for (int j = 0; j < arrBoxMsg.Count; j++)
                {
                    if (((RecentMessage)arrBoxMsg[j]).userName == ((RecentMessage)recentMsg[i]).userName)
                    {
                        ((RecentMessage)recentMsg[i]).lastMessage = ((RecentMessage)arrBoxMsg[j]).lastMessage;
                        arrBoxMsg.RemoveAt(j);
                        continue;
                    }
                }
            }

            return recentMsg;
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int searchLength, userNameLength;

            searchLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (searchLength > 0)
                search = Encoding.UTF8.GetString(buff, offset, searchLength);

            offset += searchLength; //Update offset

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (userNameLength > 0)
                this.userName = Encoding.UTF8.GetString(buff, offset, userNameLength);

            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }

}
