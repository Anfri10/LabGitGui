
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;



namespace _04._03
{
    class Student_24
    {

        //данные о студентах
        private string lastName { get; set; }
        private string firstName { get; set; }
        private string patrName { get; set; }
        private string group { get; set; }


        public Student_24() { }
        public Student_24(string lastName_p, string firstName_p, string patrName_p, string group_p, double mark_p)
        {
            lastName = lastName_p;
            firstName = firstName_p;
            patrName = patrName_p;
            group = group_p;
            mark = mark_p;
        }
        public void Display()
        {
            Console.WriteLine(lastName + " " + firstName + " " + patrName + " " + group + " " + mark);
        }
        public string getLastName() { return lastName; }
        public bool GetHightName(Student_24 a)
        {
            string str1 = lastName + firstName + patrName;
            string str2 = a.lastName + a.firstName + a.patrName;
            for (int i = 0; i < (str1.Length > str2.Length ? str2.Length : str1.Length); i++)
            {
                if (str1.ToCharArray()[i] < str2.ToCharArray()[i]) return false;
                if (str1.ToCharArray()[i] > str2.ToCharArray()[i]) return true;
            }
            return false;
        }
        public bool GetHightMark(Student_24 a)
        {
            if (mark > a.mark)
                return true;
            return false;
        }
        public bool GetHightGroup(Student_24 a)
        {
            for (int i = 0; i < (group.Length > a.group.Length ? a.group.Length : group.Length); i++)
            {
                if (group.ToCharArray()[i] < a.group.ToCharArray()[i]) return false;
                if (group.ToCharArray()[i] > a.group.ToCharArray()[i]) return true;
            }
            return false;
        }


    }
    class Junction
    {
        public Student_24 Data;
        public Junction(Student_24 data)
        {
            Data = data;
        }

        public Junction Next;

    }

    class MyList
    {
        private Junction head;
        private Junction tail;
        private int count;

        public int getLenght() { return count; }

        public void Add(Student_24 data)
        {
            Junction junction = new Junction(data);

            if (head == null)
                head = junction;
            else
                tail.Next = junction;
            tail = junction;


            count++;
        }

        public void Remove(Student_24 data)
        {
            var current = head;
            Junction previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous == null)
                    {
                        head = head.Next;
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    else
                    {

                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            tail = previous;
                        }

                    }
                    --count;
                    break;
                }
                previous = current;
                current = current.Next;
            }
        }


        public void Clear()
        {
            head = null;
            tail = null;
        }

        public void swap(Junction a, Junction b)
        {
            var c = a.Data;
            a.Data = b.Data;
            b.Data = c;
        }

        public void ReadFromFile(string path)
        {
            this.Clear();
            string s;
            using (StreamReader reader = new StreamReader(path))
            {
                while ((s = reader.ReadLine()) != null)
                {
                    string[] line = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    this.Add(new Student_24(line[0], line[1], line[2], line[3], Convert.ToDouble(line[4])));
                }
            }

        }

        public void WriteToFile(string path)
        {

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                var current = head;
                while (current != null)
                {
                    writer.WriteLine(current.Data.lastName + " " + current.Data.firstName + " " + current.Data.patrName + " " + current.Data.group + " " + current.Data.mark);
                    current = current.Next;
                }
            }
        }

        public void DisplayStudentList()
        {
            var current = head;
            while (current != null)
            {
                current.Data.Display();
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void SortNameUp()
        {
            for (int i = 0; i < count - 1; ++i)
            {
                var current = head;
                bool swaped = false;
                for (int j = 0; j < count - 1 - i; ++j)
                {

                    if (current.Data.GetHightName(current.Next.Data))
                    {
                        swap(current, current.Next);
                        swaped = true;
                    }
                    current = current.Next;
                }
                if (!swaped)
                {
                    break;
                }
            }
        }
        public void SortNameDown()
        {

            for (int i = 0; i < count - 1; ++i)
            {
                var current = head;
                bool swaped = false;
                for (int j = 0; j < count - 1 - i; ++j)
                {

                    if (!current.Data.GetHightName(current.Next.Data))
                    {
                        swap(current, current.Next);
                        swaped = true;
                    }
                    current = current.Next;
                }
                if (!swaped)
                {
                    break;
                }
            }
        }
        public void SortMarksUp()
        {

            for (int i = 0; i < count - 1; ++i)
            {
                var current = head;
                bool swaped = false;
                for (int j = 0; j < count - 1 - i; ++j)
                {

                    if (current.Data.GetHightMark(current.Next.Data))
                    {
                        swap(current, current.Next);
                        swaped = true;
                    }
                    current = current.Next;
                }
                if (!swaped)
                {
                    break;
                }
            }
        }
        public void SortMarksDown()
        {

            for (int i = 0; i < count - 1; ++i)
            {
                var current = head;
                bool swaped = false;
                for (int j = 0; j < count - 1 - i; ++j)
                {

                    if (!current.Data.GetHightMark(current.Next.Data))
                    {
                        swap(current, current.Next);
                        swaped = true;
                    }
                    current = current.Next;
                }
                if (!swaped)
                {
                    break;
                }
            }
        }
        public void SortGroupUp()
        {

            for (int i = 0; i < count - 1; ++i)
            {
                var current = head;
                bool swaped = false;
                for (int j = 0; j < count - 1 - i; ++j)
                {

                    if (current.Data.GetHightGroup(current.Next.Data))
                    {
                        swap(current, current.Next);
                        swaped = true;
                    }
                    current = current.Next;
                }
                if (!swaped)
                {
                    break;
                }
            }
        }
        public void SortGroupDown()
        {

            for (int i = 0; i < count - 1; ++i)
            {
                var current = head;
                bool swaped = false;
                for (int j = 0; j < count - 1 - i; ++j)
                {

                    if (!current.Data.GetHightGroup(current.Next.Data))
                    {
                        swap(current, current.Next);
                        swaped = true;
                    }
                    current = current.Next;
                }
                if (!swaped)
                {
                    break;
                }
            }
        }
        public Student_24 Search()
        {
            Console.WriteLine("Введите фамилию студента");
            string lastName = Console.ReadLine();
            var current = head;
            for (int i = 0; i < count; ++i)
            {
                if (current.Data.getLastName() == lastName)
                {
                    current.Data.Display();
                    return current.Data;
                }
                current = current.Next;
            }
            return new Student_24();
        }
        public void AddStudent()
        {
            Student_24 newStudent = new Student_24();
            Console.WriteLine("Введите данные о студенте");
            Console.Write("Фамилия - ");
            newStudent.lastName = Console.ReadLine();
            Console.Write("Имя - ");
            newStudent.firstName = Console.ReadLine();
            Console.Write("Отчество - ");
            newStudent.patrName = Console.ReadLine();
            Console.Write("Группа - ");
            newStudent.group = Console.ReadLine();
            Console.Write("Оценка - ");
            newStudent.mark = double.Parse(Console.ReadLine());
            this.Add(newStudent);
        }
        public void DeleteStudent()
        {
            this.Remove(this.Search());
        }
    }




    class Program
    {
        static void Main(string[] args)
        {

            string path = Path.Combine(Environment.CurrentDirectory, "MyText04.txt");
            MyList list = new MyList();
            list.ReadFromFile(path);

            Console.WriteLine("Введите команду:");
            Console.WriteLine("вывести список");
            Console.WriteLine("сортировка по алфавиту по возрастанию");
            Console.WriteLine("сортировка по алфавиту по убыванию");
            Console.WriteLine("сортировка по оценке по возрастанию");
            Console.WriteLine("сортировка по оценке по убыванию");
            Console.WriteLine("сортировка по группе по возрастанию");
            Console.WriteLine("сортировка по группе по убыванию");
            Console.WriteLine("поиск по фамилии");
            Console.WriteLine("добавить студента");
            Console.WriteLine("удалить студента");
            Console.WriteLine();
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                Console.WriteLine();
                switch (input)
                {
                    case "считать с файла":
                        list.ReadFromFile(path);
                        list.DisplayStudentList();
                        break;
                    case "вывести список":
                        list.DisplayStudentList();
                        break;
                    case "запись списка в файл":
                        list.WriteToFile(path);
                        break;
                    case "сортировка по алфавиту по возрастанию":
                        list.SortNameUp();
                        list.DisplayStudentList();
                        break;
                    case "сортировка по алфавиту по убыванию":
                        list.SortNameDown();
                        list.DisplayStudentList();
                        break;
                    case "сортировка по оценке по возрастанию":
                        list.SortMarksUp();
                        list.DisplayStudentList();
                        break;
                    case "сортировка по оценке по убыванию":
                        list.SortMarksDown();
                        list.DisplayStudentList();
                        break;
                    case "сортировка по группе по возрастанию":
                        list.SortGroupUp();
                        list.DisplayStudentList();
                        break;
                    case "сортировка по группе по убыванию":
                        list.SortGroupDown();
                        list.DisplayStudentList();
                        break;
                    case "поиск по фамилии":
                        list.Search();
                        break;
                    case "добавить студента":
                        list.AddStudent();
                        break;
                    case "удалить студента":
                        list.DeleteStudent();
                        break;
                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
                list.WriteToFile(path);
            }


        }
    }
}
