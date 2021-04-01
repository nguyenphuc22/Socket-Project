using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Server.Model
{

    class ResponseSearchStruct : ChatStruct
    {
        ArrayList arrRecentMsg;

        public ResponseSearchStruct()
        {
            this.arrRecentMsg = new ArrayList();
        }

        public ResponseSearchStruct(ArrayList mesArr)
        {
            this.arrRecentMsg = new ArrayList(mesArr);
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResposeSearchStruct)));

            data.AddRange(BitConverter.GetBytes(this.arrRecentMsg.Count));

            foreach (RecentMessage recent in this.arrRecentMsg)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(recent.userName.ToString())));
                data.AddRange(Encoding.UTF8.GetBytes(recent.userName.ToString()));

                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(recent.lastMessage.ToString())));
                data.AddRange(Encoding.UTF8.GetBytes(recent.lastMessage.ToString()));

                data.AddRange(BitConverter.GetBytes((recent.image.GetLength(0))));
                data.AddRange(recent.image);
            }


            return data.ToArray();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            int offset = 4; //Skip messageType
            int sizeArr, userNameSize, lastMessageSize, imageSize;

            sizeArr = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset

            for (int i = 0; i < sizeArr; i++)
            {
                RecentMessage recent = new RecentMessage();
                userNameSize = BitConverter.ToInt32(buff, offset);
                offset += 4; //Update Offset
                if (userNameSize > 0)
                    recent.userName = Encoding.UTF8.GetString(buff, offset, userNameSize);

                offset += userNameSize; //Update offset

                lastMessageSize = BitConverter.ToInt32(buff, offset);
                offset += 4;
                if (lastMessageSize > 0)
                    recent.lastMessage = Encoding.UTF8.GetString(buff, offset, lastMessageSize);

                offset += lastMessageSize;

                imageSize = BitConverter.ToInt32(buff, offset);
                offset += 4;
                if (imageSize > 0)
                {
                    recent.image = new byte[imageSize];
                    Array.Copy(buff, offset, recent.image, 0, imageSize);
                }
                arrRecentMsg.Add(recent);
                offset += imageSize;
            }

            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}

