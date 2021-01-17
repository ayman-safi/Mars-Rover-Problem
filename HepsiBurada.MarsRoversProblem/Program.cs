
using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
using MarsRover.Business.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HepsiBurada.MarsRoversProblem
{
    public class Program
    {

        static void Main(string[] args)
        {
            try
            {

                IServiceProvider serviceProvider = ServicesRegisteration();
                var orientationService = serviceProvider.GetService<IOrientationService>();

                // Entry region
                Console.WriteLine("Please Enter upper-right coordinates bounderies:");
                var coordinatesBoundaries = Console.ReadLine().Trim().Split(' ').Select(int.Parse ).ToList();

                Console.WriteLine("Please Enter Current Postion of The Rover:");
                var currnetPosition = Console.ReadLine().ToString();

                Console.WriteLine("Please Enter moves Series:");
                var movesSet = Console.ReadLine().ToUpper();

                var movementModel = new MovementModel()
                {
                    CurrnetPosition = currnetPosition,
                    CoordinatesBoundaries = coordinatesBoundaries,
                    MovesSet = movesSet
                };

               var output = orientationService.StartMovement(movementModel);

                Console.WriteLine($"{output}");

                Console.WriteLine("\npress any key to exit ...");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n Oops someThing Went Wrong ! \n Error Details:" + ex);
            }


        }

        private static IServiceProvider ServicesRegisteration()
        {
            var collection = new ServiceCollection();
            
            collection.AddScoped<IOrientationService, OrientationService>();
            IServiceProvider serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
