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
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResquestSearchStruct)));
            if (userName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(userName)));
                data.AddRange(Encoding.UTF8.GetBytes(userName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (this.search != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.search)));
                data.AddRange(Encoding.UTF8.GetBytes(this.search));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
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

       
    }
}
