using MVVMExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVMExample.Services
{
    public class CarDatabaseService : ICarDatabase
    {
        public List<Car> _carCollection;

        public CarDatabaseService()
        {
            InitCarCollection();
        }

        public List<Car> GetCars() 
        {
            return _carCollection.ToList();
        }

        private void InitCarCollection()
        {
            _carCollection = new List<Car>()
            {
                new Car()
                {
                    Id= 1,
                    Color = "Red",
                    Name = "Lanos",
                    ManufacturedDate = new DateTime(2005, 4, 10)
                },
                new Car()
                {
                    Id= 2,
                    Color = "Green",
                    Name = "Alfa Romeo",
                    ManufacturedDate = new DateTime(2011, 5, 9)
                },
                new Car()
                {
                    Id= 3,
                    Color = "Orange",
                    Name = "Mazda",
                    ManufacturedDate = new DateTime(2019, 1, 1)
                }
            };
        }
    }

    public interface ICarDatabase
    {
        List<Car> GetCars();
    }
}
