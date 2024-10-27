using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{

   

    internal class MenuInputValidationClass
    {
        

        public static void MenuInputValidation( string menuInputStr, int menuOutputInt)
        {

            if (!string.IsNullOrEmpty(menuInputStr))
            {
                bool menuOutputBool = int.TryParse(menuInputStr, out menuOutputInt);
            }
            else { }
        }   
    }
}
