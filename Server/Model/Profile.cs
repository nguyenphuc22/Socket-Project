using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Model
{
    class Profile
    {
        byte[] ava;
        string fullName;
        string phoneNum;
        string mail;
        public Profile(byte[] a, string name, string phone, string m)
        {
            ava = a;
            fullName = name;
            phoneNum = phone;
            mail = m;
        }
        public Profile()
        {
            ava = null;
            fullName = "";
            phoneNum = "";
            mail = "";
        }
    }
}
