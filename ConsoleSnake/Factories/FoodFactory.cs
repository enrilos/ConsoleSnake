using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleSnake.Factories
{
    public static class FoodFactory
    {
        static Random random;

        static FoodFactory()
        {
            random = new Random();
        }

        public static Food GenerateRandomFood(int boardX, int boardY)
        {
            List<Type> foodTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.BaseType == typeof(Food))
                .ToList();

            Type currentFoodType = foodTypes[random.Next(0, foodTypes.Count)];

            int coordinateX = random.Next(1, boardX - 1);
            int coordinateY = random.Next(1, boardY - 1);

            Coordinate foodCoordinate = new Coordinate(coordinateX, coordinateY);

            return Activator.CreateInstance(currentFoodType, new object[] { foodCoordinate }) as Food;
        }
    }
}
