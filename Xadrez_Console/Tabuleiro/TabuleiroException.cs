﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    class TabuleiroException :Exception
    {
        public TabuleiroException(string msg) : base(msg)
        {

        }
    }
}
