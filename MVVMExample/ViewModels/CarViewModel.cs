using MVVMExample.Models;
using MVVMExample.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.ViewModels
{
    public class CarViewModel : ViewModelBase
    {
        private readonly ICarDatabase _carDatabase;

        private Car _selectedCar;
        public List<Car> CarCollection
        {
            get
            {
                return _carDatabase.GetCars();
            }
        }

        public Car SelectedCar
        {
            get
            {
                return _selectedCar;
            }
            set 
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public CarViewModel(ICarDatabase carDatabase)
        {
            _carDatabase = carDatabase;
        }
    }
}
