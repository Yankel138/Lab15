using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите начальное значение прогрессии:");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите шаг прогрессии:");
            int step = Convert.ToInt32(Console.ReadLine());

            #region Арифметическая
            Console.WriteLine("Арифметическая прогрессия:");
            ArithProgression ap = new ArithProgression();
            ap.SetStart(start);
            ap.SetStep(step);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(ap.GetNext() + " "); 
            }
            ap.Reset(); 
            #endregion

            #region Геометрическая
            Console.WriteLine("\nГеометрическая прогрессия:");
            GeomProgression gp = new GeomProgression();
            gp.SetStart(start);
            gp.SetStep(step);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(gp.GetNext() + " ");
            }
            gp.Reset();
            #endregion

            Console.ReadKey();
        }
    }

    interface ISeries
    {
        void SetStart(int x);
        void SetStep(int x); 
        int GetNext();
        void Reset();
    }

    public abstract class Progression : ISeries
    {

        public int Start { set; get; }
        public int Step { set; get; }
        public int Current { set; get; }

        public abstract int GetNext();

        public void Reset()
        {
            Current = Start;
            Console.Write(Current + " ");
        }

        public void SetStart(int x)
        {
            Start = x;
            Current = Start;
            Console.Write(Current + " ");
        }

        public void SetStep(int x)
        {
            Step = x;
        }
    }
    public class ArithProgression : Progression
    {

        public override int GetNext()
        {
            Current += Step;
            return Current;
        }

    }

    class GeomProgression : Progression
    {
        public override int GetNext()
        {
            Current *= Step;
            return Current;
        }
    }
}

