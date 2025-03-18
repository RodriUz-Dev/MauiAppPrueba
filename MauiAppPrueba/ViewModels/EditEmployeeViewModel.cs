using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MauiAppPrueba.Entities;
using MauiAppPrueba.Services;
using MauiAppPrueba.Views;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPrueba.ViewModels
{
    [QueryProperty(nameof(SelectedItem), "SelectedItem")]
    public partial class EditEmployeeViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IEmployeeRepository _employeeRepository;

        [ObservableProperty]
        private Employee selectedItem;

        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public int code;

        [ObservableProperty]
        public string? name;

        [ObservableProperty]
        public string? entryDate;

        [ObservableProperty]
        public decimal salary;

        [ObservableProperty]
        public string? imageUrl;

        public EditEmployeeViewModel(IConfiguration configuration)
        {
            _employeeRepository = new EmployeeService(configuration);
                       
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("SelectedItem"))
            {
                SelectedItem = query["SelectedItem"] as Employee;

                if (SelectedItem != null)
                {
                    if (string.IsNullOrEmpty(SelectedItem.ImageUrl))
                    {
                        SelectedItem.ImageUrl = "empleadodefault.jpeg";
                    }

                    Id = SelectedItem.Id;
                    Code = SelectedItem.Code;
                    Name = SelectedItem.Name;
                    EntryDate = SelectedItem.EntryDate;
                    Salary = SelectedItem.Salary;
                    ImageUrl = SelectedItem.ImageUrl;
                }
                else
                {
                    Id = 0;
                    Code = 0;
                    Name = string.Empty;
                    EntryDate = string.Empty;
                    Salary = 0;
                    ImageUrl = string.Empty;
                }
            }
        }

        [RelayCommand]
        private async Task GoBack()
        {
            //await Shell.Current.DisplayAlert("Alert", "GoLoginView", "OK");
            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task SaveEmployee()
        {
            var uri = $"{nameof(EmployeesView)}";

            var employee = new Employee
            {
                Id = id,
                Code = code,
                Name = name!,
                EntryDate = entryDate!,
                Salary = salary,
                ImageUrl = imageUrl!
            };

            if (string.IsNullOrEmpty(employee.ImageUrl))
            {
                employee.ImageUrl = "empleadodefault.jpeg";
            }

            if (Id == 0)
            {
                
                employee = await _employeeRepository.Create(employee);
                if (employee.Id == 0)
                {
                    await Shell.Current.DisplayAlert("Error", "There was a problem, the employee was not created", "OK");
                    return;
                }
                await Shell.Current.DisplayAlert("Information", "The employee has been created successfully", "OK");
            }
            else
            {
                employee = await _employeeRepository.Update(employee);
                if(employee.Id == 0)
                {
                    await Shell.Current.DisplayAlert("Error", "Employee was not saved successfully", "OK");
                    return;
                }
                await Shell.Current.DisplayAlert("Information", "Employee was saved successfully", "OK");
            }                        

        }

        [RelayCommand]
        private async Task DeleteEmployee()
        {
            var uri = $"{nameof(EmployeesView)}";                             
            
            var resp = await _employeeRepository.Delete(Id);
           
            if(!resp)
            {
                await Shell.Current.DisplayAlert("Error", "There was a problem, the employee could not be deleted", "OK");
                return;
            }
            await Shell.Current.DisplayAlert("Information", "The employee has been successfully deleted", "OK");
            
            //await Shell.Current.GoToAsync(uri);
            await Shell.Current.Navigation.PopAsync();
        }

    }
}
