using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM.Model
{
    class RequestCreateGroupStruct : ChatStruct
    {
        string nameGroup;
        ArrayList groupUserName;

        public RequestCreateGroupStruct()
        {
            this.groupUserName = new ArrayList();
        }

        public RequestCreateGroupStruct(string nameGroup, ArrayList groupUserName)
        {
            this.nameGroup = nameGroup;
            this.groupUserName = new ArrayList(groupUserName);
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.Add(Convert.ToByte(Convert.ToInt32(MessageType.ResposeCreateGroupStruct)));
            if (this.nameGroup != null)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.nameGroup)));
                data.AddRange(Encoding.UTF8.GetBytes(nameGroup));
            }
            else
                data.AddRange(BitConverter.GetBytes(0));
            if (groupUserName != null)
            {
                data.AddRange(BitConverter.GetBytes(this.groupUserName.Count));
                for (int i = 0; i < groupUserName.Count; i++)
                {
                    data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(this.groupUserName[i].ToString())));
                    data.AddRange(Encoding.UTF8.GetBytes(groupUserName[i].ToString()));
                }
            }
            else
                data.AddRange(BitConverter.GetBytes(0));

            return data.ToArray();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int sizeArr, sizeNameGroup, sizeUserName;

            sizeNameGroup = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset
            if (sizeNameGroup > 0)
                this.nameGroup = Encoding.UTF8.GetString(buff, offset, sizeNameGroup);

            offset += sizeNameGroup; //Update offset

            sizeArr = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update offset
            if (sizeArr > 0)
            {
                for (int i = 0; i < sizeArr; i++)
                {
                    sizeUserName = BitConverter.ToInt32(buff, offset);
                    if (sizeUserName > 0)
                    {
                        offset += 4; //Update offset
                        this.groupUserName.Add(Encoding.UTF8.GetString(buff, offset, sizeUserName));
                    }

                }
            }
            return this;
        }

        public override ArrayList readData()
        {
            throw new NotImplementedException();
        }

        

        public override void writeData(ArrayList buff)
        {
            throw new NotImplementedException();
        }
    }
}
