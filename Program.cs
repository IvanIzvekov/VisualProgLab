using System;

namespace VizualProgLab1
{
    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            int count;
            int sum = 0;
            bool flag;
            int[] CusOnCus = new int [n];
            for(int i = 0; i < n; i++)//забиваем массив касс 0
            {
                CusOnCus[i] = 0;
            }
            for(int i = 0; i < customers.Length; i++)//главный цикл проходящий по всем покупателям
            {
                flag = false;
                for(int j = 0; j < n; j++)//цикл в котором происходит поиск пустых касс и их заполнение
                {
                    if (CusOnCus[j] == 0)
                    {
                        CusOnCus[j] = customers[i];
                        flag = true;
                        for(int g = 0; g < n; g++)
                        {
                            if (CusOnCus[g] == 0)
                            {
                                flag = true;
                            }
                            else
                                flag = false;
                        }
                        break;
                    }
                }
                if (flag == true)
                {
                    continue;
                }
                int min = CusOnCus[0];
                for(int j = 0; j < n; j++)//цикл в котором происходит поиск людей с самым маленьким временем
                {
                    if (CusOnCus[j] < min)
                    {
                        min = CusOnCus[j];
                    }
                }
                sum += min;
                for(int j = 0; j < n; j++)//цикл в котором мы вычитаем из всех покупателей время 
                {
                    CusOnCus[j] -= min;
                }
            }
            int max=0;
            for(int i = 0; i < n; i++)//суммируем из оставшихся покупателей самого большого
            {
                if (CusOnCus[i] > max)
                {
                    max = CusOnCus[i];
                }
            }
            sum += max;
            return sum;
        }
    }
    class Program
    {
        static void Main()
        {
            int[] a = { 5, 3, 4 };
            Console.WriteLine("Одна касса [5, 3, 4]. Ожидается: 12. Результат: " + HW1.QueueTime(a, 1));
            int[] b = { 10, 2, 3, 3 };
            Console.WriteLine("Две кассы [10, 2, 3, 3]. Ожидается: 10. Результат: " + HW1.QueueTime(b, 2));
            int[] с = { 2, 3, 10 };
            Console.WriteLine("Две кассы [2, 3, 10]. Ожидается: 12. Результат: " + HW1.QueueTime(с, 2));
            int[] d = { 533, 43, 10 };
            Console.WriteLine("Четыре кассы [533, 43, 10]. Ожидается: 533. Результат: " + HW1.QueueTime(d, 4));
            int[] e = { 55 };
            Console.WriteLine("Одна касса [55]. Ожидается: 55. Результат: " + HW1.QueueTime(e, 1));
            int[] f = { };
            Console.WriteLine("Три кассы []. Ожидается: 0. Результат: " + HW1.QueueTime(f, 3));
            int[] g = { 5, 5, 5, 2 };
            Console.WriteLine("Три кассы [5, 5, 5, 2]. Ожидается: 7. Результат: " + HW1.QueueTime(g, 3));
            int[] u = { 1000005, 1000005, 1000005,1000002, 3 };
            Console.WriteLine("Три кассы [1000005, 1000005, 1000005,1000002]. Ожидается: 2000007. Результат: " + HW1.QueueTime(u, 3));
        }
    }
}