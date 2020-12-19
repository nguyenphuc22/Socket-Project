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
    }
}
