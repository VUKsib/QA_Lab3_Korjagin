using QA_Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Lab3
{
    /// <summary>
    /// Класс исполнитель
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Room rr1 = new Room();
            Room_resident rr2 = new Room_resident();
            Room_resident rr3 = new Room_resident();
            rr1.Init(10, 1);
            rr2.Init(15, 4, 3, 1);
            rr3.Init(10, 3, 3, 0);
            Console.WriteLine("Средняя площадь на человека без разделения на взрослых и детей: \n" + rr1.Man());
            Console.WriteLine("Средняя площадь с разделением на детей и взрослых: \n" + rr2.Man() + "\n" + rr3.Man());

            Flat fl = new Flat();
            char[] nf = "Квартира №100".ToCharArray();
            fl.Init(nf, 10, 15, 2, 4, 3, 1, 4);
            fl.Display();
            Console.WriteLine("\nСредняя площадь на одного человека по 2 комнатам: " + fl.avrArea());
            Console.Read();
        }
    }
}

