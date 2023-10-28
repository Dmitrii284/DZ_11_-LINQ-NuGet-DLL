using System.Xml.Linq;
/*
//Task_ "books"
 Требуется написать C#-код, используя LINQ и XML, для выполнения следующих задач:

Вывести все названия книг, отсортированные по названию в алфавитном порядке.
Посчитать количество книг каждого жанра.
Получить список авторов, у которых есть книги с годом издания до 1900
Получить список авторов у которых не менее 2х книг в списке
Посчитать количество книг в названиях которых больше одного слова и получить данные об этих книгах
Получить имена авторов и книг, которые были написаны между 1940 и 2000 годами.
 
 */

namespace DZ_11__LINQ__NuGet___DLL
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // Task - Trein
            List<Train> trains = new List<Train>()
            {
                new Train{TreinNumber = 1, DeparturePoint = "Москва", Destination ="Санкт-Петербург",
                            TimeDeparture = DateTime.Parse("10:00"), TimeArrival = DateTime.Parse("20:00")},
                new Train{TreinNumber = 2, DeparturePoint = "Владивосток", Destination = "Москва",
                            TimeDeparture = DateTime.Parse("11:40"), TimeArrival = DateTime.Parse("10:20")},
                new Train{TreinNumber = 3, DeparturePoint = "Оренбург", Destination = "Екатеринбург",
                            TimeDeparture = DateTime.Parse("20:15"), TimeArrival = DateTime.Parse("12:00")},
                new Train{TreinNumber = 4, DeparturePoint = "Астрахань", Destination = "Уренгой",
                            TimeDeparture = DateTime.Parse("15:00"), TimeArrival = DateTime.Parse("05:00")},
                new Train{TreinNumber = 5, DeparturePoint = "Сочи", Destination = "Екатеринбург",
                            TimeDeparture = DateTime.Parse("15:30"), TimeArrival = DateTime.Parse("22:20")}
            };

            Console.WriteLine("Список поездов:");
            foreach (var train in trains)
            {
                train.PrintInfo();
            }
            Train newTrain = new Train();
            Console.Write("Номер поезда: ");
            newTrain.TreinNumber = int.Parse(Console.ReadLine());
            Console.Write("Пункт отправления: ");
            newTrain.DeparturePoint = Console.ReadLine();
            Console.Write("Пункт назначения: ");
            newTrain.Destination = Console.ReadLine();
            Console.Write("Время отправления: ");
            newTrain.TimeDeparture = DateTime.Parse(Console.ReadLine());
            Console.Write("Время прибытия: ");
            newTrain.TimeArrival = DateTime.Parse(Console.ReadLine());
            trains.Add(newTrain);

            Console.WriteLine("Список поездов после добавления нового поезда:");
            foreach (var train in trains)
            {
                train.PrintInfo();
            }


            Console.WriteLine("Введите номер поезда, который хотите найти и удалить:");
            int trainNumber = int.Parse(Console.ReadLine());

            Train trainToDelete = trains.FirstOrDefault(train => train.TreinNumber == trainNumber);

            trainToDelete.PrintInfo();


            if (trainToDelete.Equals(default(Train)))
            {
                Console.WriteLine("Поезд с таким номером не найден");
            }
            else
            {
                trains.Remove(trainToDelete);
                Console.WriteLine($"Поезд номер {trainNumber} удален");
            }


            Console.WriteLine("Список поездов после удаления выбранного поезда:");
            foreach (var train in trains)
            {
                train.PrintInfo();
            }

            trains = trains.OrderBy(train => train.DeparturePoint).ToList();

            Console.WriteLine("Список поездов после сортировки по пункту отправления:");
            foreach (var train in trains)
            {
                train.PrintInfo();
            }
            Console.ReadLine();

            Console.WriteLine("Task_ \"books. \nСписок поездов после сортировки по пункту отправления:");

            //Task_ "books"
            string filePath = (@"C:\Users\Дмитрий\source\repos\DZ_11_ LINQ, NuGet , DLL\DZ_11_ LINQ, NuGet , DLL\books.xml");
            XDocument doc = XDocument.Load(filePath);
            var books = doc.Descendants("book");

            // Вывести все названия книг, отсортированные по названию в алфавитном порядке
            var sortedBooks = books.OrderBy(book => book.Element("title").Value);
            Console.WriteLine("Сортированные по названию книги:");
            foreach (var book in sortedBooks)
            {
                Console.WriteLine(book.Element("title").Value);
            }

            Console.WriteLine();

            // Посчитать количество книг каждого жанра
            var genreCounts = books.GroupBy(book => book.Element("genre").Value)
                                   .Select(group => new { Genre = group.Key, Count = group.Count() });
            Console.WriteLine("Количество книг по жанрам:");
            foreach (var genreCount in genreCounts)
            {
                Console.WriteLine($"Жанр: {genreCount.Genre}, Количество: {genreCount.Count}");
            }

            Console.WriteLine();

            // Получить список авторов, у которых есть книги с годом издания до 1900
            var authorsBefore1900 = books.Where(book => int.Parse(book.Element("year").Value) < 1900)
                                         .Select(book => book);
        }
    }
}