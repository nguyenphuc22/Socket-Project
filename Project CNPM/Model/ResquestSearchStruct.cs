using System;
using System.Collections;
using System.Collections.Generic;
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
            if (search != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(search)));
                data.AddRange(Encoding.UTF8.GetBytes(search));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            return data.ToArray();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            throw new NotImplementedException();
        }
    }
}
