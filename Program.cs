using System;
using System.Linq;

namespace DynamicSolution
{
    class Program
	{
		static void Main(string[] args)
		{
            var result = new ResultA
            {
                Date = DateTime.Now,
                Day = 22,
                Month = 1,
                Year = 2020
            };

            dynamic runTimeObject = result;

            object o = runTimeObject;

            string[] propertyNames = o.GetType().GetProperties().Select(p => p.Name).ToArray();

            foreach (var prop in propertyNames)
            {
                var name = o.GetType().GetProperty(prop).Name;
                object propValue = o.GetType().GetProperty(prop).GetValue(o, null);
                Console.WriteLine($"{name} - {propValue}");
            }           
            Console.ReadKey();
        }
	}

    public class ResultA
    {
        public DateTime Date { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
