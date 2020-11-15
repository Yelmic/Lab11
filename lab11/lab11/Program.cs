using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.Concurrent;

namespace lab11
{
    public partial class Phone
    {
        private string surname;
        private string name;
        private string adress;
        public string Surname{get { return this.surname; }set { this.surname = value; }}
        public string Name{get { return this.name; }set { this.name = value; } }
        public string Adress { get { return this.adress; } set { this.adress = value; } }
        public Phone(string Name, string Surname, string Adress)
        {
            name = Name;
            surname = Surname;
            adress = Adress;
        }
    }
    public class Rectangular
    {
        public int per = 0;
        public int a;
        public int b;
        public Rectangular(int A, int B) { a = A;  b = B; }
        public int Per()
        {
            per = a*2+b*2;
            return per;
        }
    }
    public class Square
    {
        public int per = 0;
        public int side;
        public Square(int Side) { side = Side; }
        public int Per()
        {
            per = side * 4;
            return per;
        }
    }
    public class Rhombus
    {
        public int per = 0;
        public int side;
        public Rhombus(int Side) { side = Side; }
        public int Per()
        {
            per = side * 4;
            return per;
        }
    }
    public class Arbitrary
    {
        public int per = 0;
        public int a;
        public int b;
        public int c;
        public int d;
        public Arbitrary(int A, int B, int C, int D) { a = A; b = B; c = C; d = D; }
        public int Per()
        {
            per = a + b + c + d;
            return per;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] months =
            {
                "December",
                "January",
                "Febrary",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November"
            };
            string[] expt =
            {
                "March",
                "April",
                "May",
                "September",
                "October",
                "November"
            };
            //запрос по длине строки
            var n = 5;
            IEnumerable<string> str = months.Where(p=>p.Length==n);
            foreach (string s in str)
                Console.WriteLine("Month with length 5 "+ s);
            //запрос по летним и зимним месяцам
            IEnumerable<string> winter_summer = months.Except<string>(expt);
            foreach(string s in winter_summer)
                Console.WriteLine(s+"\n");
            //запрос на алфавитный порядок
            IEnumerable<string> alf = months.OrderBy(s => s);
                 foreach (string s in alf)
                Console.WriteLine(s);
            //запрос на u  и не менее 4 букв
            Console.WriteLine();
            IEnumerable<string> uuuu = from p in months
                         where p.Length >= 4 & p.Contains("u")
                         select p;
            foreach (string s in uuuu)
                Console.WriteLine(s);
            Console.WriteLine();


            //2 task!!!!!!!!!

            List<Phone> phone = new List<Phone>
            {
                new Phone("Elena", "Mikhnovetz", "October st."),
                new Phone("Ivan", "Ivanov", "Pripyat st."),
                new Phone("Petr", "Petrov", "Street st.")
            };
            IEnumerable<Phone> phone1 = from s in phone orderby s.Surname select s;

            foreach (Phone s in phone1)
            {
                Console.WriteLine(s.Surname);
            }


            //3 task!!!!!!
            int count_rect = 0;
            int count_arb = 0;
            int count_rhomb = 0;
            int count_sq = 0;
            ArrayList arr = new ArrayList();//по количеству четырехугольников
            arr.Add(new Rectangular(9, 8));
            arr.Add(new Rhombus(5));
            arr.Add(new Arbitrary(1, 2, 3, 4));
            arr.Add(new Square(4));
            arr.Add(new Rectangular(2, 1));
            arr.Add(new Square(9));
            arr.Add(new Square(3));
            arr.Add(new Rhombus(1));
            arr.Add(new Rhombus(7));
            arr.Add(new Arbitrary(9, 11, 2, 4));
            var rect = arr.OfType<Rectangular>();
            foreach (var s in rect)
            {
                count_rect++;
            }
            Console.WriteLine("Rectangular: "+count_rect);
            var arb = arr.OfType<Arbitrary>();
            foreach (var s in arb)
            {
                count_arb++;
            }
            Console.WriteLine("Arbitrary: "+count_arb);
            var rh = arr.OfType<Rhombus>();
            foreach (var s in rh)
            {
                count_rhomb++;
            }
            Console.WriteLine("Rhombus: " + count_rhomb);
            var sq = arr.OfType<Square>();
            foreach (var s in sq)
            {
                count_sq++;
            }
            Console.WriteLine("Square: " + count_sq);//периметры квадратов
            List<Square> squares = new List<Square>();
            squares.Add((Square)arr[3]);
            squares.Add((Square)arr[5]);
            squares.Add((Square)arr[6]);
            var sqr = squares.Max(p => p.Per());
            Console.WriteLine("Max perimetr of square: "+sqr);
            var msqr = squares.Min(p => p.Per());
            Console.WriteLine("Min perimetr of square: " + msqr);
            List<Rectangular> rectas = new List<Rectangular>();//периметры прямоугольников
            rectas.Add((Rectangular)arr[0]);
            rectas.Add((Rectangular)arr[4]);
            var r = rectas.Max(p => p.Per());
            Console.WriteLine("Max perimetr of rectangular: " + r);
            var mr = rectas.Min(p => p.Per());
            Console.WriteLine("Min perimetr of rectangular: " + mr);
            List<Rhombus> rhomb = new List<Rhombus>();//периметры ромбов
            rhomb.Add((Rhombus)arr[1]);
            rhomb.Add((Rhombus)arr[7]);
            rhomb.Add((Rhombus)arr[8]);
            var rhm = rhomb.Max(p => p.Per());
            Console.WriteLine("Max perimetr of rhombus: " + rhm);
            var mrhm = rhomb.Min(p => p.Per());
            Console.WriteLine("Min perimetr of rhombus: " + mrhm);
            List<Arbitrary> ar = new List<Arbitrary>();//периметры произвольных
            ar.Add((Arbitrary)arr[2]);
            ar.Add((Arbitrary)arr[9]);
            var aar = ar.Max(p => p.Per());
            Console.WriteLine("Max perimetr of arbitrary: " + aar);
            var maar = ar.Min(p => p.Per());
            Console.WriteLine("Min perimetr of arbitrary: " + maar);
            Console.WriteLine("Array of sides of squares < 7 ");//массив квадратов
            int x=7;
            IEnumerable<Square> ssss = from p in squares
                                       where p.side <= x
                                       select p;
            foreach (Square s in ssss)
                Console.WriteLine(s.side);
            Console.WriteLine("Array of rectangulars ");//упорядоченные прямоугольники
            IEnumerable<Rectangular> rrrr = rectas.OrderBy(p => p.Per());
            foreach (Rectangular s in rrrr)
                Console.WriteLine(s.per);



            //4 task!!!!!!!!
            IEnumerable<string> query = from p in months
                 .Where(p => p.Contains("r"))//ограничение и квантор
                 .OrderBy(p => p)//упорядочивание
                 .Take(3)//разбиение
                 .Except(expt)//множество
                                        select p;
            foreach (string s in query)
                Console.WriteLine(s);


            //5 task!!!!!!!!!
            int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var newq = months.Join(
                num,
                p => p.Length,
                s => s,
                (p, s) => new
                {
                    length = s,
                    name = p,
                });
            foreach (var k in newq)
                Console.WriteLine(k);
        }
    }
}
