using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestLogout : ChatStruct
    {
        string userName;

        public RequestLogout()
        {
            this.userName = "";
        }
        public RequestLogout(string userName)
        {
            this.userName = userName;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.LogoutNotificationStruct)));
            
            if (userName != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(userName)));
                data.AddRange(Encoding.UTF8.GetBytes(userName));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        
        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int userNameLength;

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset

            if (userNameLength > 0)
                userName = Encoding.UTF8.GetString(buff, offset, userNameLength);



            return this;
        }

        
    }
}
