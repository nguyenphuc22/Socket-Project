﻿using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Server.Model
{
    class ResponseHistoryMesssageStruct : ChatStruct
    {
        ArrayList messArr;

        public ResponseHistoryMesssageStruct()
        {
            this.messArr = new ArrayList();
        }

        public ResponseHistoryMesssageStruct(ArrayList mesArr)
        {
            this.messArr = new ArrayList(mesArr);
        }

        public override byte[] pack()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(Convert.ToInt32(MessageType.ResponseHistoryMesssage)));

            data.AddRange(BitConverter.GetBytes(this.messArr.Count));

            foreach (string userName in this.messArr)
            {
                data.AddRange(BitConverter.GetBytes(Encoding.UTF8.GetByteCount(userName.ToString())));
                data.AddRange(Encoding.UTF8.GetBytes(userName.ToString()));
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
            int sizeArr, nameUserSize;

            sizeArr = BitConverter.ToInt32(buff, offset);
            offset += 4; //Update Offset

            for (int i = 0; i < sizeArr; i++)
            {
                nameUserSize = BitConverter.ToInt32(buff, offset);
                offset += 4; //Update Offset
                if (nameUserSize > 0)
                    this.messArr.Add(Encoding.UTF8.GetString(buff, offset, nameUserSize));

                offset += nameUserSize; //Update offset
            }

            return this;
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}
