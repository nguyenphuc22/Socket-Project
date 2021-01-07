﻿using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Server.Model
{
    class RequestOutGroup: ChatStruct
    {
        string groupName;
        string userName;
        public RequestOutGroup()
        {
            this.userName = "";
            this.groupName = "";
            
        }
        public RequestOutGroup(string groupName, string userName)
        {
            this.userName = userName;
            this.groupName = groupName;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestOutGroup)));
            if (groupName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(groupName)));
                data.AddRange(Encoding.UTF8.GetBytes(groupName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (userName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(userName)));
                data.AddRange(Encoding.UTF8.GetBytes(userName));
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
            int userNameLength, groupNameLength;

            groupNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (groupNameLength > 0)
                userName = Encoding.UTF8.GetString(buff, offset, groupNameLength);

            offset += groupNameLength; //Update offset

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (userNameLength > 0)
                userName = Encoding.UTF8.GetString(buff, offset, userNameLength);



            return this;
        }

 
        public override void writeData(SQLiteConnection connectionData)
        {
            string query = String.Format("DELETE FROM GroupChat where NameGroup='{0}' and UserName='{1}'",this.groupName,this.userName) ;
            SQLiteCommand cmd = new SQLiteCommand(query, connectionData);
            cmd.ExecuteNonQuery();
        }
    }
}
}
