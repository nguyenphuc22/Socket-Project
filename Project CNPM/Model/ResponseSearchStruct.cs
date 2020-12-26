using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseSearchStruct : ChatStruct
    {
        string userName;
        string groupName;
        public ResponseSearchStruct()
        {
            this.userName = "";
            this.groupName = "";
        }
        public ResponseSearchStruct(string userName, string groupName)
        {
            this.userName = userName;
            this.groupName = groupName;
        }
        public override byte[] pack()
        {
            throw new NotImplementedException();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int userNameLength, groupNameLength;

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (userNameLength > 0)
                userName = Encoding.UTF8.GetString(buff, offset, userNameLength);

            offset += userNameLength; //Update offset

            groupNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (groupNameLength > 0)
                groupName = Encoding.UTF8.GetString(buff, offset, groupNameLength);

            return this;
        }
    }
}
