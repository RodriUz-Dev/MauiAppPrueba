using Domain.Entities;

namespace MauiAppPrueba.Views;

public partial class EmployeesView : ContentPage
{
    public List<Employee>? Employees { get; set; }
    public EmployeesView()
	{
		InitializeComponent();
        LoadData();
        BindingContext = this;
    }

    private void LoadData()
    {
        Employees = new List<Employee>
        {
            new Employee{ Id = 1, Code = 145642, Name = "Juan Perez", EntryDate = "01/01/2021", Salary = 1000, ImageUrl = "https://media.istockphoto.com/id/1295870150/photo/hipster-sitting-at-kitchen-table-working.jpg?s=612x612&w=0&k=20&c=2YkSLzR3EtdvMPY8NavTFbj-A9ImXq4oWnUPn_e1r3Q=" },
            new Employee{ Id = 2, Code = 234556, Name = "Maria Lopez", EntryDate = "01/01/2021", Salary = 2000, ImageUrl = "https://media.istockphoto.com/id/2201504865/photo/smiling-woman-working-from-home-in-kitchen-using-laptop.jpg?s=612x612&w=0&k=20&c=EO7V884fvpI3amjBLeTUmp1eijEznprnI-1WtyiYYaU=" },
            new Employee{ Id = 3, Code = 345453, Name = "Pedro Ramirez", EntryDate = "01/01/2021", Salary = 3000, ImageUrl = "https://media.istockphoto.com/id/1205747336/photo/man-smiling-working-using-computer-laptop.jpg?s=612x612&w=0&k=20&c=LZv4bh3qKqmW67smb87CMYT5ej525DJpYHD7bRpJVjA=" },
            new Employee{ Id = 4, Code = 456891, Name = "Jose Rodriguez", EntryDate = "01/01/2021", Salary = 4000, ImageUrl = "https://media.istockphoto.com/id/1551446123/photo/portrait-of-a-young-african-american-male-student-studying-at-home-remotely-sitting-on-the.jpg?s=612x612&w=0&k=20&c=3j-gJpztQPLuEYC8C9PUHaTUH5T7eeOEF_3KhIvySLU=" },
            new Employee{ Id = 5, Code = 522476, Name = "Ana Torres", EntryDate = "01/01/2021", Salary = 5000, ImageUrl = "https://media.istockphoto.com/id/1484546895/photo/mature-woman-working-from-home.jpg?s=612x612&w=0&k=20&c=zJdRoSwLe8aRPPg1gaNQHAoGojQo8QFRD1VrdQcKa40=" },
        };
    }

    private async void GoLoginView(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "GoLoginView", "OK");
        await Navigation.PopAsync();
    }
}