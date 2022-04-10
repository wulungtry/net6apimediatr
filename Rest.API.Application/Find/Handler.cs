using MediatR;

namespace Rest.API.Application
{
    public class FindHandler : IRequestHandler<FindRequest, FindResponse>
    {
        public async Task<FindResponse> Handle(FindRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            //just for sample purpose
            var sample = new SampleData().Data
                                         .Where(x => x.LastName.ToLower().Contains(request.lastName.ToLower()))
                                         .ToList();

            List<Employee> employees = new();
            sample.ForEach(x => {
                Employee employee = new()
                {
                    EmployeeNo = x.EmployeeNo,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                };

                employees.Add(employee);
            });

            FindResponse response = new()
            {
                Employees = employees
            };

            return response;
        }
    }
}
