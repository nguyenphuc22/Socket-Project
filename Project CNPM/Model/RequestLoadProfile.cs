using System;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestLoadProfile : ChatStruct
    {
        string userName;
        
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.RequestLoadProfile)));

            data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.userName)));
            data.AddRange(Encoding.UTF8.GetBytes(this.userName));

            return data.ToArray();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4;
            int sizeuserName;

            sizeuserName = BitConverter.ToInt32(buff, offset);
            offset += 4;
            if (sizeuserName != 0)
            {
                this.userName = Encoding.UTF8.GetString(buff, offset, sizeuserName);
            }
            return this;
        }
    }
}
