using System;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestChangePass:ChatStruct
    {
        string userName;
        string passWord;
        string newPassWord;
        string reNewPassWord;
        public RequestChangePass()
        {
            this.userName = "";
            this.passWord = "";
            this.newPassWord = "";
            this.reNewPassWord = "";
        }
        public RequestChangePass(string userName, string passWord, string newpassword, string renewpassword)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.newPassWord = newpassword;
            this.reNewPassWord = renewpassword;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestChangePass)));
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
            if (newPassWord != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(newPassWord)));
                data.AddRange(Encoding.UTF8.GetBytes(newPassWord));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (reNewPassWord != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(reNewPassWord)));
                data.AddRange(Encoding.UTF8.GetBytes(reNewPassWord));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int userNameLength, passWordLength, newPassWordLength, reNewPassWordLength;

            userNameLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (userNameLength > 0)
                userName = Encoding.UTF8.GetString(buff, offset, userNameLength);

            offset += userNameLength; //Update offset

            passWordLength = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (passWordLength > 0)
                passWord = Encoding.UTF8.GetString(buff, offset, passWordLength);

            offset += passWordLength;

            newPassWordLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if(newPassWordLength>0)
                newPassWord = Encoding.UTF8.GetString(buff, offset, newPassWordLength);

            offset += newPassWordLength;

            reNewPassWordLength = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (reNewPassWordLength > 0)
                reNewPassWord = Encoding.UTF8.GetString(buff, offset, reNewPassWordLength);

            return this;
        }
    }
}
