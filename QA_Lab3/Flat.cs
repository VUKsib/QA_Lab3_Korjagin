using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Lab3
{
    /// <summary>
    /// <brief>Базовый класс "Комната"</brif>
    /// <details>Данный класс нужен для хранения и обработки информации об одной комнате</details>
    /// </summary>
    public class Room
    {
        protected double area; // площадь
        protected int amount; // кол - во проживающих
        /// <summary>
        /// Конструктор класса Room, инициализирующий переменные
        /// </summary>
        /// <param name="s">площадь</param>
        /// <param name="a">количество проживающих</param>
        public void Init(double s, int a)
        {
            area = s;
            amount = a;
        }
        /// <summary>
        /// Отображает данные о комнате на экране
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Площадь комнаты: " + area + "\nКоличество проживающих людей: " + amount + "\n");
        }
        /// <summary>
        /// Считает площадь на человека
        /// </summary>
        /// <returns></returns>
        public double Man()
        {
            return area / amount;
        }
        /// <summary>
        /// Доступ к полю площадь 
        /// </summary>
        /// <returns>area - площадь</returns>
        public double totalS()
        {
            return area;
        }
        /// <summary>
        /// Доступ к полю кол-во проживающих 
        /// </summary>
        /// <returns>amount - кол-во проживающих</returns>
        public int totalA()
        {
            return amount;
        }
    }
    /// <summary>
    /// <brief>Производный класс "Проживающие"</brief>
    /// <author>Korjagin_VU</author> 
    /// <version>1.9</version> 
    /// <date>April 2023</date>
    /// <warning>Данный класс создан в учебных целях</warning> 
    /// Обычный дочерний класс, который отнаследован от ранее созданного класса Room
    /// </summary>
    class Room_resident : Room
    {
        private int adult; // взрослые
        private int child; // дети
        /// <summary>
        /// Конструктор класса Room_resident, инициализирующий переменные
        /// </summary>
        /// <param name="s">площадь</param>
        /// <param name="a">общее кол-во проживающих</param>
        /// <param name="ad">кол-во взрослых</param>
        /// <param name="ch">кол-во детей</param>
        public void Init(double s, int a, int ad, int ch)
        {
            base.Init(s, a);
            adult = ad;
            child = ch;
        }
        /// <summary>
        /// Отображает данные о взрослых и детях на экране
        /// </summary>
        public void Display()
        {
            base.Display();
            Console.WriteLine("	Количество взрослых: " + adult + "\n	Количество детей: " + child + "\n");
        }
        /// <summary>
        /// Считает площадь на человека с разделением на детей и взрослых
        /// </summary>
        /// <returns></returns>
        public double Man()
        {
            amount = adult + child * 2;
            return area / amount;
        }
        /// <summary>
        /// Доступ к полю площадь 
        /// </summary>
        /// <returns>area - площадь</returns>
        public double totalS()
        {
            return area;
        }
        /// <summary>
        /// Доступ к полю кол-во проживающих с разделением на детей и взрослых
        /// </summary>
        /// <returns>amount - кол-во проживающих</returns>
        /// Формула для вычисления количества проживающих, при условии, что кол-во детей умножается на 2:
        /// \f$ amount = adult + child \times 2 \f$
        /// 
        public int totalA()
        {
            return adult + child * 2;
        }
    }
    /// <summary>
    /// <brief>Класс "Квартира"</brief>
    /// <details>Содержит информацию о комната, проживающих в них и их площади.
    /// Также информацию об общей площади и средней площади на человека с учетом общей площади</details>
    /// </summary>
    public class Flat
    {
        private char[] name;
        private Room TypeR1 = new Room();
        private Room_resident TypeR2 = new Room_resident();
        private double TotalAreaDop = 0;
        /// <summary>
        /// Конструктор Flat, принимает параметры типа Room и его производного
        /// </summary>
        /// <param name="nf">Номер квартиры</param>
        /// <param name="s1">площадь первой комнаты</param>
        /// ![Image](C:/Users/slava/Downloads/room1.jpg)
        /// <param name="s2">площадь второй комнаты</param>
        /// ![Image](C:/Users/slava/Downloads/room2.jpg)
        /// <param name="a1">общ кол-во проживающих 1 комнаты</param>
        /// <param name="a2">общ кол-во проживающих 2 комнаты</param>
        /// <param name="ad2">кол-во взрослых 2 комнаты</param>
        /// <param name="ch2">кол-во детей 2 комнаты</param>
        /// <param name="TotalAreaDop1">площадь доп помещений</param>
        public void Init(char[] nf, double s1, double s2, int a1, int a2, int ad2, int ch2, double TotalAreaDop1)
        {
            name = nf;
            TypeR1.Init(s1, a1);
            TypeR2.Init(s2, a2, ad2, ch2);
            TotalAreaDop = TotalAreaDop1;
        }
        /// <summary>
        /// Отображает на экране информацию о квартире
        /// </summary>
        public void Display()
        {
            Console.WriteLine("\nОбозначение квартиры: ");
            foreach (char ch in name)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
            Console.WriteLine();
            TypeR1.Display();
            TypeR2.Display();
            Console.WriteLine("Общая площадь дополнительных помещений (кухня, кладовка): " + TotalAreaDop);
        }
        /// <summary>
        /// Вычисляет среднюю площадь на человека
        /// </summary>
        /// <returns>Площадь на человека с учетом площади доп помещений</returns>
        public double avrArea()
        {
            double TotalArea = TypeR1.totalS() + TypeR2.totalS(); 
            int TotalAmount = TypeR1.totalA() + TypeR2.totalA(); 
            return (TotalArea + TotalAreaDop) / TotalAmount;
        }
    }
}