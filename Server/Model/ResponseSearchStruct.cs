using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Server.Model
{
    
    class ResponseSearchStruct : ChatStruct
    {
        bool isInUserData;
        bool isInGroupChat;
        string userName;
        string groupName;
        public ResponseSearchStruct()
        {
            this.isInUserData = false;
            this.isInGroupChat = false;
            this.userName = "";
            this.groupName = "";
        }
        public ResponseSearchStruct(bool isInUserData, bool isInGroupChat, string userName, string groupName)
        {
            this.isInUserData = isInUserData;
            this.isInGroupChat = isInGroupChat;
            this.userName = userName;
            this.groupName = groupName;
        }
        public override byte[] pack()
        {
            throw new NotImplementedException();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int userNameLength;

            this.isInUserData = BitConverter.ToBoolean(buff, offset);
            offset += 1; //Update Offset

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
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
