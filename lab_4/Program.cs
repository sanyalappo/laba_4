using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace lab_4
{
    public static class Extension
    {
        public static char? FirstNum(this string s)
        {
            foreach (char c in s)
            {
                if (c >= '1' && c <= '0')
                {
                    return c;
                }
            }
            return null;
        }

        public static void Del(this Set set)
        {
            int[] arr = set.Elements;
            Array.Sort(arr);
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] >= 0)
                {
                    Array.Resize<int>(ref arr, i);
                }
            }
            set.Elements = arr;
        }
    }

    public class Set
    {
        int[] elements;
        public int[] Elements
        {
            set
            {
                elements = value;
            }
            get
            {
                return elements;
            }
        }
        public class Owner
        {
            int ID;
            string Name;
            string Org;

            public Owner(int ID, string Name, string Org)
            {
                this.ID = ID;
                this.Name = Name;
                this.Org = Org;
            }
            public override string ToString()
            {
                return "Owner:" + ID +" "+ Name +" "+ Org;
            }
        }
        public class Date
        {
            private int Day { get; }
            private int Month { get; }
            private int Year { get; }

            public string data { get; private set; }

            public Date()
            {
                DateTime date = DateTime.Now;
                Day = date.Day;
                Month = date.Month;
                Year = date.Year;
                data = Day.ToString() + '.' + Month.ToString() + '.' + Year.ToString();
            }
           


        }
        public Set()
        {
            elements = new int[] { 1, 2, 3, 4, 5 };

        }
        public Set(int[] array)
        {
            elements = new int[array.Length];
            array.CopyTo(elements, 0);
            Check();

        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < elements.Length) return elements[i];
                else return 0;
            }
        }

        public void Check()
        {
            bool Changed = true;
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length; j++)
                {
                    if (elements[i] == elements[j])
                    {
                        int Var = elements[elements.Length];
                        elements[elements.Length] = elements[j];
                        elements[j] = Var;
                        Array.Resize<int>(ref elements, elements.Length - 1); //изменяет кол-во эл-ов одномер. массива до указанного нового размера

                        Changed = true;
                    }
                }
            }
            Array.Sort(elements);
            if (Changed)
            {
                Console.WriteLine($"В множестве присутствуют одинаковые элементы\n Множество изменено!");
                ShowSet();
            }
        }
        public void ShowSet()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.WriteLine(this.elements[i] + " ");
            }
            Console.WriteLine();
        }

        public static bool operator >(int[] numbers, Set obj)
        {
            int amountinSet = 0;
            foreach (int number in numbers)
            {
                bool InSet = false;
                foreach (int elem in obj.elements)
                {
                    if (number == elem)
                    {
                        Console.WriteLine($"Element {number} is in Set");
                        InSet = true;
                        amountinSet++;
                        break;
                    }

                }
                if (!InSet)
                {
                    Console.WriteLine($"Element {number} is not in Set");
                }

            }
            if (amountinSet == numbers.Length)
                return true;
            else return false;
        }

        public static bool operator <(int[] subset, Set obj)
        {
            int el = 0;
            foreach (int InSubset in subset)
            {
                foreach (int elInSubset in obj.elements)
                {
                    if (InSubset == elInSubset)
                    {
                        el++;
                        break;
                    }
                }
            }
            if (el == subset.Length)
                return true;
            else return false;
        }

        public static Set operator *(Set s1, Set s2)
        {
            var result = from s in s1.elements.Intersect(s2.elements)
                         select s;
            Set s3 = new Set((int[])result);
            return s3;
        }

        public static class StaticOPeration
        {
            public static int Sum(Set set)
            {
                int sum = 0;
                foreach (int elem in set.elements)
                {
                    sum = elem;
                }
                return sum;
            }

        }

        public static int MaxMin(Set set)
        {
            int max = 0;
            int min = set.elements[0];
            foreach (int elem in set.elements) {
                if (elem > max)
                    max = elem;
                if (elem < min)
                    min = elem;
            }
            int diff = max - min;
            return (diff);
        }

        public static int Amount(Set set)
        {
            int amount = 0;
            foreach(int elem in set.elements)
            {
                amount++;
            }
            return amount;
        }


    static void Main(string[] args)
        {
            Owner person = new Owner(1234, "Александра","БГТУ");
            Console.WriteLine(person);
          
        }

    }
};   
       
    

