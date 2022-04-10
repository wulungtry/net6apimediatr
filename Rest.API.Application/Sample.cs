namespace Rest.API.Application
{
    public class SampleData
    {
        public List<Sample> Data { get; init; }

        public SampleData()
        {
            this.Data = new List<Sample>()
            {
                new Sample()
                {
                    EmployeeNo = "JM0036",
                    FirstName = "Joan",
                    LastName = "Mir"
                },
                new Sample()
                {
                    EmployeeNo = "MM0093",
                    FirstName = "Marc",
                    LastName = "Marquez"
                },
                new Sample()
                {
                    EmployeeNo = "AM0073",
                    FirstName = "Alex",
                    LastName = "Marquez"
                },
                new Sample()
                {
                    EmployeeNo = "FQ0020",
                    FirstName = "Fabio",
                    LastName = "Quartararo"
                }
            };
        }
    }

    public class Sample
    {
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
