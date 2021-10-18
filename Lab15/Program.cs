using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //Небольшой интерактив
            Console.Write("Введите начальное значение прогрессии:");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите шаг прогрессии:");
            int step = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество членов прогрессии:");
            int time = Convert.ToInt32(Console.ReadLine());

            #region Арифметическая
            Console.WriteLine("Арифметическая прогрессия:");
            ArithProgression ap = new ArithProgression();
            ap.SetStart(start);
            ap.SetStep(step);
            for (int i = 0; i < time; i++)
            {
                Console.Write(ap.GetNext() + " "); //Раз уж не воид, иначе зачем вообще возвращать что-то. Ну можно было в массив еще записать
            }
            ap.Reset(); //Не нравится как сюда вписывается, но нужна была проверка метода сброса
            #endregion

            #region Геометрическая
            Console.WriteLine("\nГеометрическая прогрессия:");
            GeomProgression gp = new GeomProgression();
            gp.SetStart(start);
            gp.SetStep(step);
            for (int i = 0; i < time; i++)
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
        void SetStep(int x); // Надеюсь не страшно, захотелось добавить еще шаг...
        int GetNext();
        void Reset();
    }

    class ArithProgression : ISeries
    {
        int start;
        int step;
        int current;
        public int GetNext()
        {
            current += step;
            return current;
        }

        public void Reset()
        {
            current = start;
            Console.Write(current + " ");
        }

        public void SetStart(int x)
        {
            start = x;
            current = start;
            Console.Write(current + " ");
        }

        public void SetStep(int x)
        {
            step = x;
        }
    }

    class GeomProgression : ISeries
    {
        int start;
        int step;
        int current;
        public int GetNext()
        {
            current *= step;
            return current;
        }

        public void Reset()
        {
            current = start;
            Console.Write(current + " ");
        }

        public void SetStart(int x)
        {
            start = x;
            current = start;
            Console.Write(current + " ");
        }

        public void SetStep(int x)
        {
            step = x;
        }
    }
}
