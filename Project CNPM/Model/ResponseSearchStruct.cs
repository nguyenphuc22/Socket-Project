using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class ResponseSearchStruct : ChatStruct
    {
        ArrayList userArr;
        string nameGroup;

        public ResponseSearchStruct()
        {
            userArr = new ArrayList();
            nameGroup = "Nick";
        }
        public ResponseSearchStruct(ArrayList userArr, string nameGroup)
        {
            this.userArr = new ArrayList(userArr);
            this.nameGroup = nameGroup;
        }
        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResposeSearchStruct)));

            if (this.nameGroup != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.nameGroup)));
                data.AddRange(Encoding.UTF8.GetBytes(this.nameGroup));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));

            data.AddRange(BitConverter.GetBytes(this.userArr.Count));

            foreach (string userName in userArr)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(userName.ToString())));
                data.AddRange(Encoding.UTF8.GetBytes(userName.ToString()));
            }


            return data.ToArray();
        }



        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int nameGroupInt, sizeArr, nameUserSize;

            nameGroupInt = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (nameGroupInt > 0)
                this.nameGroup = Encoding.UTF8.GetString(buff, offset, nameGroupInt);

            offset += nameGroupInt; //Update offset

            sizeArr = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset

            for (int i = 0; i < sizeArr; i++)
            {
                nameUserSize = BitConverter.ToInt32(buff, offset);
                offset += 4; //Update Offset
                if (nameUserSize > 0)
                    this.userArr.Add(Encoding.UTF8.GetString(buff, offset, nameUserSize));

                offset += nameUserSize; //Update offset
            }

            return this;
        }

    }
}
