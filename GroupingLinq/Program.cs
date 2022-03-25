using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", 180, 70, Person.Gender.Male),
                new Person("John", 170, 88, Person.Gender.Male),
                new Person("Anna", 150, 48, Person.Gender.Female),
                new Person("Kyle", 164, 77, Person.Gender.Male),
                new Person("Anna", 164, 77, Person.Gender.Female),
                new Person("Maria", 160, 55, Person.Gender.Female),
                new Person("John", 160, 55, Person.Gender.Female),
            };

            Console.WriteLine("1) Agrupar las personas por género");

            var genderGroup = from x in people
                              group x by x.gender;

            foreach (var person in genderGroup)
            {
                Console.WriteLine($"{person.Key}");

                foreach (var p in person)
                {
                    Console.WriteLine($"    {p.Name} - {p.gender}");
                }
            }

            Console.WriteLine("--------------");

            Console.WriteLine("2) Agrupar las personas por letra de inicio del Nombre");

            var alphabeticalGroup = from x in people
                                    orderby x.Name
                                    group x by x.Name[0];

            foreach (var person in alphabeticalGroup)
            {
                Console.WriteLine($"{person.Key}");

                foreach (var p in person)
                {
                    Console.WriteLine($"    {p.Name}");
                }
            }
            Console.WriteLine("--------------");

            Console.WriteLine("3) Agrupar las personas por género con Lambda Expression");

            var genderGroupLambda = people.GroupBy(x => x.gender);                             

            foreach (var person in genderGroupLambda)
            {
                Console.WriteLine($"{person.Key}");

                foreach (var p in person)
                {
                    Console.WriteLine($"    {p.Name} - {p.gender}");
                }
            }
            Console.WriteLine("--------------");

            Console.WriteLine("4) Agrupar las personas por género con y que midan más de 160 con Lambda Expression");

            var genderHeightGroupLambda = people.Where(x => x.Height > 160)
                                                .GroupBy(x => x.gender);

            foreach (var person in genderHeightGroupLambda)
            {
                Console.WriteLine($"{person.Key}");

                foreach (var p in person)
                {
                    Console.WriteLine($"    {p.Name} - {p.Height}");
                }
            }
            Console.WriteLine("--------------");

            Console.WriteLine("5) Agrupar las personas por género y altura con MultiKey");

            var multiKey = people.GroupBy(x => new { x.gender, x.Height });

            foreach (var person in multiKey)
            {
                Console.WriteLine($"{person.Key}");

                foreach (var p in person)
                {
                    Console.WriteLine($"    {p.Name}");
                }
            }
            Console.WriteLine("--------------");
        }
    }
}
