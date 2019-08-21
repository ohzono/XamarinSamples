using Prism.Navigation;
using PrismRxApi.Model;
using PrismRxApi.Model.Api;
using Reactive.Bindings;

namespace PrismRxApi.ViewModels
{
    public class ListItemPageViewModel : ViewModelBase
    {
        public ReactiveProperty<string> Id { get; private set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Name { get; private set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Salary { get; private set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> Age { get; private set; } = new ReactiveProperty<string>();
        //public ReactiveProperty<ImageSource> ProfileImage { get; private set; } = new ReactiveProperty<ImageSource>();

        private Employee _employee;

        public ReactiveCommand Update { get; private set; } = new ReactiveCommand();
        public ListItemPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Update.Subscribe(() => UpdateEmployee());
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            _employee = parameters.GetValue<Employee>(typeof(Employee).Name);

            Id.Value = _employee.Id;
            Name.Value = _employee.Name;
            Salary.Value = _employee.Salary;
            Age.Value = _employee.Age;
            //ProfileImage.Value = _employee.ProfileImage;
        }

        private async void UpdateEmployee()
        {
            var api = new ApiPutEmployee();
            var employee = new Employee();
            employee.Id = Id.Value;
            employee.Name = Name.Value;
            employee.Age = Age.Value;
            employee.Salary = Salary.Value;
            //employee.ProfileImage = ProfileImage.Value;
            await api.PutDataAsync(employee);
        }
    }
}
