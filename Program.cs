using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            Prodavac milijana = new Prodavac("Milijana", 50);
            Prodavac djamo = new Prodavac("mudja", 50);
            Sef cale = new Sef("mudjin tata", 50, 3);
            cale.Dodeli(djamo);
            cale.Dodeli(milijana);
            djamo.Prodao(10);
            milijana.Prodao(69);
            Console.WriteLine(cale);
            Console.ReadKey();
        }
        public abstract class Radnik
        {
            private string ime;
            private double procenat;

            protected Radnik(string i, double p)
            {
                ime = i; procenat = p;
            }
            public abstract double Prihod { get; }
            public double Plata
            {
                get { return Prihod * procenat / 100; }
            }
            public override string ToString()
            {
                return ime + "/" + Plata;
            }
        }
        public class Prodavac : Radnik
        {
            private double prihod;
            public Prodavac(string i, double p)
                : base(i, p) { }
            public void Prodao(double vrednost)
            {
                prihod += vrednost;
            }
            public override double Prihod
            {
                get { return prihod; }
            }
        }
        public class Sef : Radnik
        {
            private Radnik[] podredjeni;
            private int BrPod;

            public Sef(string i, double p, int maks_pod)
                : base(i, p)
            {
                podredjeni = new Radnik[maks_pod];
            }
            public bool Dodeli(Radnik r)
            {
                if (BrPod >= podredjeni.Length)
                    return false;
                podredjeni[BrPod++] = r;
                return true;
            }
            public override double Prihod
            {
                get
                {
                    double pom = 0;
                    for (int i = 0; i < BrPod; pom += podredjeni[i++].Prihod) ;
                    return pom;
                }
            }
        }
    }
}
