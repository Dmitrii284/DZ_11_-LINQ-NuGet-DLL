/*
 Задача
Решить задачу на С# с помощью LInq . Создайте структуру «Поезд» с полями: номер поезда, пункт отправления,
пункт назначения, время отправления и время прибытия. Добавьте свойство Info, выводящее информацию о поезде.
Добавьте метод, получающий в качестве параметра фактическое время прибытия поезда и сравнивающий его с временем,
указанным в экземпляре структуры. Из метода верните сообщение: 
«Поезд опоздал на (указать время) минут» или «Поезд пришел вовремя».
Создайте список (List) для хранения объектов структуры «Поезд». Заполните данный список пятью экземплярами.
Реализуйте добавление нового экземпляра структуры (введенного с клавиатуры) в список. 
Отсортируйте список по пункту отправления (в порядке возрастания). 
Реализуйте поиск и удаление экземпляра структуры из списка по введённому номеру поезда.
 */
namespace DZ_11__LINQ__NuGet___DLL
{
    public struct Train
    {
        public int TreinNumber { get; set; }
        public string DeparturePoint { get; set; }
        public string Destination { get; set; }
        public DateTime TimeDeparture { get; set; }
        public DateTime TimeArrival { get; set; }

        public Train(int treinNumber, string departurePoint, string destination, DateTime timeDeparture,
                        DateTime timeArrival)
        {
            TreinNumber = treinNumber;
            DeparturePoint = departurePoint;
            Destination = destination;
            TimeDeparture = timeDeparture;
            TimeArrival = timeArrival;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Номер поезда: {TreinNumber}\n Пункт отправления: {DeparturePoint}\n " +
                $"Пункт назначения: {Destination}\n Время отправления: {TimeDeparture}\n Время прибытия: {TimeArrival}\n");
        }

        public string CheckArrivalTime(DateTime actualArrivalTime)
        {
            if (actualArrivalTime < TimeArrival)
            {
                TimeSpan delay = actualArrivalTime - TimeArrival;
                return $"Поезд опоздал на {delay.TotalMinutes} минут";
            }
            return "Поезд пришел вовремя";
        }
        public Train() { }
        public Train(string name) { }
    }
}
