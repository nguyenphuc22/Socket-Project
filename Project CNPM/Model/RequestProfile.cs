﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestProfile : ChatStruct
    {
        byte[] ava;
        string fullName;
        string phoneNum;
        string mail;

        public RequestProfile()
        {
            ava = new byte[0];
            fullName = "";
            phoneNum = "";
            mail = "";
        }

        public RequestProfile(byte[] img,string name, string fone,string email)
        {
            ava = img;
            fullName = name;
            phoneNum = fone;
            mail = email;
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestChangePass)));

            data.AddRange(BitConverter.GetBytes((ava.GetLength(0))));
            data.AddRange(ava);

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.fullName)));
            data.AddRange(Encoding.UTF8.GetBytes(this.fullName));

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.phoneNum)));
            data.AddRange(Encoding.UTF8.GetBytes(this.phoneNum));

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.mail)));
            data.AddRange(Encoding.UTF8.GetBytes(this.mail));


            return data.ToArray();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4;
            int sizeAva, sizeName, sizeFone, sizeMail;

            sizeAva = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (sizeAva >0)
            {
                this.ava = new byte[sizeAva];
                Array.Copy(buff, offset, this.ava, 0, sizeAva);
            }
            offset += sizeAva;

            sizeName = BitConverter.ToInt32(buff, offset);
            if (sizeName != 0)
            {
                this.fullName = Encoding.UTF8.GetString(buff, offset, sizeName);
            }
            offset += sizeName;

            sizeFone = BitConverter.ToInt32(buff, offset);
            if (sizeFone != 0)
                this.phoneNum = Encoding.UTF8.GetString(buff, offset, sizeFone);
            offset += sizeFone;

            sizeMail = BitConverter.ToInt32(buff, offset);
            if (sizeMail != 0)
                this.mail = Encoding.UTF8.GetString(buff, offset, sizeMail);

            return this;
        }
    }
}