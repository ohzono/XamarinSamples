using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using PrismRxApi.Model;
using PrismRxApi.Model.Api;
using PrismRxApi.Views;

namespace PrismRxApi.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        public ReactiveProperty<string> Input { get; private set; } = new ReactiveProperty<string>("");
        public ReactiveProperty<string> Result { get; private set; } = new ReactiveProperty<string>("");
        public ReactiveProperty<Employee> SelectedItem { get; private set; } = new ReactiveProperty<Employee>();
        public ReactiveCollection<Employee> ListItems { get; private set; } = new ReactiveCollection<Employee>();
        public ReactiveProperty<bool> IsRefreshing { get; private set; } = new ReactiveProperty<bool>();
        public ReactiveCommand Get { get; private set; } = new ReactiveCommand();
        public ReactiveCommand Selected { get; private set; } = new ReactiveCommand();

        private IEnumerable<Employee> employees;
        private INavigationService _navigationService;
        public ListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            // reactive property のsample
            Result = Input
                .Delay(dueTime: TimeSpan.FromSeconds(3))
                .Select(x => x.ToUpper())
                .ToReactiveProperty();

            Get.Subscribe(() => FetchEmployees());
            Selected.Subscribe(() => Navigate());
        }

        private async void FetchEmployees()
        {
            IsRefreshing.Value = true;
            var api = new ApiGetEmployees();
            employees = await api.GetDataAsync();
            //api.GetDataAsync().ToObservable().Where(x => x.ElementAt(0).Title == "error").Subscribe();
            ListItems.Clear();
            foreach (Employee value in employees)
            {
                ListItems.Add(value);
            }
            IsRefreshing.Value = false;
        }

        private void Navigate()
        {
            var parameters = new NavigationParameters();
            parameters.Add(typeof(Employee).Name, SelectedItem.Value);
            _navigationService.NavigateAsync(typeof(ListItemPage).Name, parameters);
        }
    }
}
