﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseSignupStruct : ChatStruct
    {
        bool isSucc;
        string msg;



        public ResponseSignupStruct()
        {

        }

        public ResponseSignupStruct(bool isSucc, string msg)
        {
            this.isSucc = isSucc;
            this.msg = msg;
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseSignupStruct)));
            data.AddRange(BitConverter.GetBytes(isSucc));
            if (this.msg != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.msg)));
                data.AddRange(Encoding.UTF8.GetBytes(this.msg));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));

            return data.ToArray();
        }



        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int sizeMsg;

            this.isSucc = BitConverter.ToBoolean(buff, offset);
            offset += 1; //Update Offset

            sizeMsg = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (sizeMsg > 0)
                this.msg = Encoding.UTF8.GetString(buff, offset, sizeMsg);


            return this;
        }

        public string getMsg()
        {
            if (isSucc)
            {
                return "Succ:" + this.msg;
            }
            else
            {
                return "Error:" + this.msg;
            }
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}
