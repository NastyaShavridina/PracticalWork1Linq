using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticalWork1Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Users user1 = new Users { FirstName = "Anna", LastName = "Dmitreeva" };

            Users user2 = new Users { FirstName = "Pavel", LastName = "Pavlov" };

            Users user3 = new Users { FirstName = "Oleg", LastName = "Olegov" };

            Users user4 = new Users { FirstName = "Yana", LastName = "Yakovleva" };

            ComputingTechnics computingTechnics1 = new ComputingTechnics { Name = "laptop", Cost = 1000, ComputingPower = 0.1, Users = new List<Users> { user2, user4, user1 } };

            ComputingTechnics computingTechnics2 = new ComputingTechnics { Name = "Computer", Cost = 800, ComputingPower = 0.2, Users = new List<Users> { user2, user3, user4, user1 } };

            ComputingTechnics computingTechnics3 = new ComputingTechnics { Name = "Mainframe", Cost = 50000, ComputingPower = 1.5, Users = new List<Users> { user3, user1 } };

            ComputingTechnics computingTechnics4 = new ComputingTechnics { Name = "Tablet", Cost = 300, ComputingPower = 0.05, Users = new List<Users> { user3, user2 } };

            ComputingTechnics computingTechnics5 = new ComputingTechnics { Name = "Tablet", Cost = 250, ComputingPower = 0.04, Users = new List<Users> { user3, user2 } };

            ComputingTechnics computingTechnics6 = new ComputingTechnics { Name = "Mainframe", Cost = 100000, ComputingPower = 1.5, Users = new List<Users> { user3, user2 } };

            ComputingTechnics computingTechnics7 = new ComputingTechnics { Name = "Computer", Cost = 500, ComputingPower = 0.2, Users = new List<Users> { user3, user2, user4 } };

            ComputingTechnics computingTechnics8 = new ComputingTechnics { Name = "Computer", Cost = 800, ComputingPower = 0.2, Users = new List<Users> { user2, user3,} };

            List<ComputingTechnics> listComp = new List<ComputingTechnics> 
            { computingTechnics1, computingTechnics2, computingTechnics3, computingTechnics4, computingTechnics5, computingTechnics6, computingTechnics7, computingTechnics8};

            foreach (var technics in listComp)
            {
                Console.WriteLine($"Technique Name: {technics.Name}, Cost: {technics.Cost}, Power: {technics.ComputingPower}" );

                Console.WriteLine(" Пользователи устройства");

                foreach (Users users in technics.Users)
                {
                    Console.WriteLine($" {users.FirstName}  {users.LastName}");
                }
            }

            // Сортировка с помощью интерфейса Icomparer 
            Console.WriteLine(new string('*', 180));

            listComp.Sort(new ComparerTechniqueByCost());

            listComp.Sort(new ComparerTechniqueByPower());

            foreach (var technics in listComp)
            {
                Console.WriteLine($"Technique Name: {technics.Name}, Cost: {technics.Cost}, Power: {technics.ComputingPower}");

                Console.WriteLine("Пользователи устройства");

                foreach (Users users in technics.Users)
                {
                    Console.WriteLine($" {users.FirstName}  {users.LastName}");
                }
            }

            // Сортировка по стоимости и вычислительной мощности 
            Console.WriteLine(new string('*', 180));

            List<ComputingTechnics> computingTechnicsSorted1 = listComp.Where(lc => lc.Cost >= 300 && lc.ComputingPower >= 0.1).ToList();

            foreach (var technics in computingTechnicsSorted1)
            {
                Console.WriteLine($"Technique Name: {technics.Name}, Cost: {technics.Cost}, Power: {technics.ComputingPower}");

                Console.WriteLine("Пользователи устройства");

                foreach (Users users in technics.Users)
                {
                    Console.WriteLine($" {users.FirstName}  {users.LastName}");
                }
            }

            // Сортировка по названию техники в алфавитном порядке и по фамилиям в алфавитном порядке  
            Console.WriteLine(new string('*', 155));

            List<ComputingTechnics> computingTechnicsSorted2 = listComp.OrderBy(x => x.Name).ToList();//.ThenBy(x => x.Users.OrderBy(x => x.LastName).ToList()).ToList();//ThenBy(x => x.Users.OrderBy(x => x.LastName).ToList()).ToList(); 

            foreach (var technics in computingTechnicsSorted2)
            {
                var usersSorted = technics.Users.OrderBy( x => x.LastName).ToList();

                Console.WriteLine($"Technique Name: {technics.Name}, Cost: {technics.Cost}, Power: {technics.ComputingPower}");

                Console.WriteLine("Пользователи устройства");

                foreach (Users users in usersSorted)
                {
                    Console.WriteLine($" {users.FirstName}  {users.LastName}");
                }
            }

            // Сортировка по названию техники в обратном алфавитном порядке
            Console.WriteLine(new string('*', 180));

            List<ComputingTechnics> computingTechnicsSorted3 = listComp.OrderByDescending(x => x.Name).ToList();

            foreach (var technics in computingTechnicsSorted3)
            {
                Console.WriteLine($"Technique Name: {technics.Name}, Cost: {technics.Cost}, Power: {technics.ComputingPower}");

                Console.WriteLine("Пользователи устройства");

                foreach (Users users in technics.Users)
                {
                    Console.WriteLine($" {users.FirstName}  {users.LastName}");
                }
            }

            // Группировка по одному полю (Название)
            Console.WriteLine(new string('*', 180));

            var computingTechnicsGrouping = listComp.GroupBy( x => x.Name);

            foreach (var technics in computingTechnicsGrouping)
            {
                Console.WriteLine($"{technics.Key } : ");

                foreach (var tecnicsDefenition in technics)
                {   
                    Console.WriteLine($" Cost: {tecnicsDefenition.Cost}, Power: {tecnicsDefenition.ComputingPower}");

                    Console.WriteLine("Пользователи устройства");

                    foreach (Users users in tecnicsDefenition.Users)
                    {
                        Console.WriteLine($" {users.FirstName}  {users.LastName}");
                    }
                }
            }

            // Группировка по двум полям (Название, вычислительная мощность)
            Console.WriteLine(new string('*', 180));

            var computingTechnicsGrouping2 = listComp.GroupBy(x => new { x.Name, x.ComputingPower });

            foreach (var technics in computingTechnicsGrouping2)
            {
                Console.WriteLine($"Вид : {technics.Key.Name} Вычислительная мощность : {technics.Key.ComputingPower}");

                foreach (var tecnicsDefenition in technics)
                {
                    Console.WriteLine($" Cost: {tecnicsDefenition.Cost}");

                    Console.WriteLine("Пользователи устройства");

                    foreach (Users users in tecnicsDefenition.Users)
                    {
                        Console.WriteLine($" {users.FirstName}  {users.LastName}");
                    }
                }
            }

        }
    }
}
