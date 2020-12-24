using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//I'LL DO THIS TASK LATER ^^!
namespace Project_CNPM.Model
{
    class ResquestSignupStruct : ChatStruct
    {
        string userName;
        string passWord;
        
        public ResquestSignupStruct(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        public override byte[] pack()
        {
            throw new NotImplementedException();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            throw new NotImplementedException();
        }
    }
}
