using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_OOP
{
    // Gå tillbaka till menyn-klass
    public class ExitToMenuClass
    {
        // Gå tillbaka till menyn-metod
        public static void ExitToMenu() 
        {
            // Presenterar för användaren att man måste trycka på en tanget för att återvända till menyn
            Console.WriteLine("Tryck på en knapp för att gå tillbaka till menyn.");
            // Väntar på att användaren ska trycka på en tangent
            Console.ReadKey();
        }

    }
}
