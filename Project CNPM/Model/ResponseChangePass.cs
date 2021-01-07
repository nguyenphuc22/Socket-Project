using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseChangePass : ChatStruct
    {

        string msg;
        public ResponseChangePass()
        {
            msg = "";
        }
        public string getMsg()
        {
            return msg;
        }
        public ResponseChangePass(string msg)
        {

            this.msg = msg;
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseChangePass)));
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


            sizeMsg = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (sizeMsg > 0)
                this.msg = Encoding.UTF8.GetString(buff, offset, sizeMsg);


            return this;
        }

        
    }
}
