using MVVMExample.Services;

namespace MVVMExample.ViewModels
{
    public class ViewModelLocator
    {
        private readonly ICarDatabase _carDatabase;
        private readonly CarViewModel _carViewModel;

        public CarViewModel CarViewModel => _carViewModel;

        public ViewModelLocator()
        {
            _carDatabase = new CarDatabaseService();
            _carViewModel = new CarViewModel(_carDatabase);
        }
    }
}
