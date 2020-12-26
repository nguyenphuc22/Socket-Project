using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
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
        public ResquestSearchStruct(string userName, string search)
        {
            this.userName = userName;
            this.search = search;
        }
        public override byte[] pack()
        {
            throw new NotImplementedException();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            ArrayList array = new ArrayList();

            string queryUser = String.Format("SELECT * FROM UserData Where userName = '{0}'", this.userName);
            SQLiteCommand cmdUser = new SQLiteCommand(queryUser, connectionData);

            DataTable dtUser = new DataTable();

            SQLiteDataAdapter adapterUser = new SQLiteDataAdapter(cmdUser);
            // data type table
            adapterUser.Fill(dtUser);

            foreach (DataRow row in dtUser.Rows)
            {
                array.Add(row.ToString());
            }

            string queryGroup = String.Format("SELECT DISTINCT * FROM GroupChat Where NameGroup = '{0}'", this.search);
            SQLiteCommand cmdGroup = new SQLiteCommand(queryGroup, connectionData);

            DataTable dtGroup = new DataTable();

            SQLiteDataAdapter adapterGroup = new SQLiteDataAdapter(cmdGroup);
            // data type table
            adapterGroup.Fill(dtGroup);

            foreach (DataRow row in dtGroup.Rows)
            {
                array.Add(row.ToString());
            }

            return array;
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int userNameLength, searchLength;

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (userNameLength > 0)
                userName = Encoding.UTF8.GetString(buff, offset, userNameLength);

            offset += userNameLength; //Update offset

            searchLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (searchLength > 0)
                search = Encoding.UTF8.GetString(buff, offset, searchLength);

            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}
