﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Task4Currency
{
    public interface IReadable
    {
        void Read(StreamReader sr);
    }
}
