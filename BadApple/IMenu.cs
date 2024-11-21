using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadApple
{
    internal interface IMenu
    {
        bool HandleOption(string option);
    }
}
