using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Project_CNPM.Model
{
    interface ChatStruct
    {
        byte[] pack();
        ChatStruct unpack(byte[] buff);
        void writeData(ArrayList buff);
        ArrayList readData();
    }
}
