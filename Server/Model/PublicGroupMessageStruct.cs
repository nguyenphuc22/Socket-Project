using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Project_CNPM.Model
{
    class PublicGroupMessageStruct : ChatStruct
    {
        public override byte[] pack()
        {
            throw new NotImplementedException();
        }

        public override ArrayList readData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }

        public override ChatStruct unpack(byte[] buff)
        {
            throw new NotImplementedException();
        }

        public override void writeData(SQLiteConnection connectionData)
        {
            throw new NotImplementedException();
        }
    }
}
