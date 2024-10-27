using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    public class MenuInput
    {
        public string MenuInputStr { get; set; }
        public int MenuOutputInt { get; set; }

        public MenuInput(string menuInputStr, int menuOutputInt)
        {
            MenuInputStr = menuInputStr;
            MenuOutputInt = menuOutputInt;
        }
    }
}