namespace Rest.API.Application
{
    public class FindResponse
    {
        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
