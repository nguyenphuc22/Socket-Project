using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Project_CNPM.Model
{
    interface ChatStruct
    {
        ArrayList pack();
        ChatStruct unpack(ArrayList buff);
    }
}
