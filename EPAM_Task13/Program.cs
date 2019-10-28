using EPAM_Task13.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task13
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProcess process = new DataProcess();
            Tree upload = new Tree();
            
            Node root = null;
            root = upload.Insert(root, 1, "Саша", "Математика", "1 января 2019 г.", "B+");
            root = upload.Insert(root, 2, "Стас", "География", "5 января 2019 г.", "C+");
            root = upload.Insert(root, 3, "Екатерина", "Биология", "25 февраля 2019 г.", "A+");
            root = upload.Insert(root, 4, "Вероника", "Высшая Математика", "24 марта 2019 г.", "A+");
            root = upload.Insert(root, 5, "Туран", "Геометрия", "26 апреля 2019 г.", "A+");
            root = upload.Insert(root, 6, "Дженнифер", "Логика", "2 марта 2019 г.", "D");
            root = upload.Insert(root, 7, "Безос", "Программирование", "24 марта 2019 г.", "D");

            //process.WriteStudentToFile(upload.nodes);

            Tree students = process.ReadStudentsFromFile();

            Console.WriteLine("Выберите соответствующую цифровую команду:");
            int command;
            Console.WriteLine(@"1-Найти студента по имени; 2-Найти студентов по оценкам; 3-Отсортировать студентов по имени");
            command = Convert.ToInt32(Console.ReadLine());
            switch (command)
            {
                case 1:
                    Console.WriteLine("Введите имя студента ");
                    string name = Console.ReadLine();
                    var studentByName = students.nodes.FirstOrDefault(f => f.name == name);
                    Console.WriteLine(studentByName.name);
                    Console.WriteLine(studentByName.testName);
                    Console.WriteLine(studentByName.testMark);
                    Console.WriteLine(studentByName.testDate);
                    break;
                case 2:
                    Console.WriteLine("Введите оценку ");
                    string mark = Console.ReadLine();
                    var studentsByMark = students.nodes.Where(w=>w.testMark==mark).ToList();
                    foreach (var student in studentsByMark)
                    {
                        Console.WriteLine(student.name);
                    }
                    break;
                case 3:
                    var studentsSorted = students.nodes.OrderBy(o => o.name);
                    foreach (var student in studentsSorted)
                    {
                        Console.WriteLine($"{student.name} {student.testMark} ");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
