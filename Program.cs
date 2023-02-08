using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Класс, описывающий поля записи студентов(ФИО, Дата(3поля), группа, наименование предмета и оценка(массивом).Выдать студентов, которые учатся в указанной группе, студентов-должников, студентов-отличников, студентов моложе 20лет. )
//Меню(заполнение, выборки, выход)
namespace AMOGUS
{
    class Student
    {
        public string FNF;
        public int DoB_d;
        public int DoB_m;
        public int DoB_y;
        public string Group;
        public string[] sub_n_grade = new string[10];

    }

    internal class Program
    {
        public static void Filler(int n, Student[] spisok, bool flag_sort, bool[] flagi_sorta, string gruppa)
        {
            for (int i = 0; i < n; i++)
            {
                spisok[i] = new Student();
                Console.WriteLine("ФИО Студента");
                spisok[i].FNF = Console.ReadLine();
                Console.WriteLine("День рождения");
                spisok[i].DoB_d = int.Parse(Console.ReadLine());
                Console.WriteLine("Месяц рождения");
                spisok[i].DoB_m = int.Parse(Console.ReadLine());
                Console.WriteLine("Год рождения");
                spisok[i].DoB_y = int.Parse(Console.ReadLine());
                Console.WriteLine("Группа студента");
                spisok[i].Group = Console.ReadLine();
                Console.WriteLine("Предметы и оценки по ним");
                for (int j = 0; j < 10; j++)
                {
                    spisok[i].sub_n_grade[j] = Console.ReadLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Список студентов заполнен");
            Console.WriteLine();
            Menu(flag_sort, n, spisok, flagi_sorta, gruppa);
        }

        static void SortingQuery(int n, Student[] spisok, bool flag_sort, bool[] flagi_sorta)
        {
            Console.WriteLine("По каким критериям вы хотите отобрать студентов ?");
            Console.WriteLine("1.По группе");
            Console.WriteLine("2.Должники");
            Console.WriteLine("3.Отличники");
            Console.WriteLine("4.Моложе 20 лет");

            string[] sortiki = Console.ReadLine().Split();
            string gruppa = "";

            if (sortiki[0] == "")
            {
                flag_sort = true; Menu(flag_sort, n, spisok, flagi_sorta, gruppa);
            }

            for (int i = 0; i < sortiki.Length; i++)
            {
                if (sortiki[i] == "1")
                {
                    Console.WriteLine("Введите код группы");
                    gruppa = Console.ReadLine();
                    flagi_sorta[0] = true;
                }
                if (sortiki[i] == "2")
                {
                    flagi_sorta[1] = true;
                }
                if (sortiki[i] == "3")
                {
                    flagi_sorta[2] = true;
                }
                if (sortiki[i] == "4")
                {
                    flagi_sorta[3] = true;
                }
            }

            flag_sort = true;

            Menu(flag_sort, n, spisok, flagi_sorta, gruppa);

        }

        static void Menu(bool flag_sort, int n, Student[] spisok, bool[] flagi_sorta, string gruppa)
        {
            Console.WriteLine("1.Ввод студентов(ВЫПОЛНЕН)");
            if (flag_sort == true)
            {
                Console.WriteLine("2.Выборка(ЗАДАНА)");
            }
            else
            {
                Console.WriteLine("2.Выборка");
            }
            Console.WriteLine("3.Вывод результата");
            Console.WriteLine("4.Выход из прогаммы");

            int choice2 = int.Parse(Console.ReadLine());

            switch (choice2)
            {
                case 1: Filler(n, spisok, flag_sort, flagi_sorta, gruppa); break;
                case 2: SortingQuery(n, spisok, flag_sort, flagi_sorta); break;
                case 3: ResultOutput(n, flagi_sorta, spisok, gruppa); break;
                case 4: Console.Clear(); Environment.Exit(0); break;
            }
        }

        static void ResultOutput(int n, bool[] flagi_sorta, Student[] spisok, string gruppa)
        {
            int num = 1;
            for (int i = 0; i < n; i++)
            {
                bool is_ok = true;
                if (flagi_sorta[0] == true)
                {
                    if (spisok[i].Group != gruppa)
                    {
                        is_ok = false;
                    }
                }
                if (flagi_sorta[1] == true)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (spisok[i].sub_n_grade[j] == "2")
                        {
                            is_ok = true; break;
                        }
                        else
                        {
                            is_ok = false;
                        }
                    }
                }
                if (flagi_sorta[2] == true)
                {
                    if (spisok[i].sub_n_grade[1] != "5" || spisok[i].sub_n_grade[3] != "5" || spisok[i].sub_n_grade[5] != "5" || spisok[i].sub_n_grade[7] != "5" || spisok[i].sub_n_grade[9] != "5")
                    {
                        is_ok = false;
                    }
                }
                if (flagi_sorta[3] == true)
                {
                    DateTime birthDate = new DateTime(spisok[i].DoB_y, spisok[i].DoB_m, spisok[i].DoB_d);
                    int divergence = GetAge(birthDate);
                    if (divergence >= 20)
                    {
                        is_ok = false;
                    }
                }
                if (is_ok == true)
                {
                    Console.WriteLine(num + ". " + spisok[i].FNF + " " + spisok[i].DoB_d + "." + spisok[i].DoB_m + "." + spisok[i].DoB_y + "г. " + spisok[i].Group); Console.WriteLine();
                    num++;
                }
            }
        }
        public static int GetAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            return now.Year - birthDate.Year - 1 +
                ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        }

        static void Main()
        {
            bool[] flagi_sorta = new bool[4]; flagi_sorta[0] = false; flagi_sorta[1] = false; flagi_sorta[2] = false; flagi_sorta[3] = false;
            bool flag_sort = false;
            Console.WriteLine("Меню"); Console.WriteLine("");
            Console.WriteLine("1.Ввод студентов");
            Console.WriteLine("2.Выборка");
            Console.WriteLine("3.Вывод результата");
            Console.WriteLine("4.Выход из программы");
            int choice = int.Parse(Console.ReadLine());
            string gruppa = "";

            if (choice == 1)
            {
                Console.WriteLine("Введите кол-во студентов");
                int n = int.Parse(Console.ReadLine()); Student[] spisok = new Student[n];
                Filler(n, spisok, flag_sort, flagi_sorta, gruppa);
            }
            else if (choice == 4)
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else if (choice == 2 || choice == 3)
            {
                Console.WriteLine("Список студентов пуст. Выборка невозможна");
                Environment.Exit(1);
            }
        }
    }
}