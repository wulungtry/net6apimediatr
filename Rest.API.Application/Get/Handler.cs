using MediatR;

namespace Rest.API.Application
{
    public class GetHandler : IRequestHandler<GetRequest, GetResponse>
    {
        public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            
            var data = new SampleData().Data
                                       .FirstOrDefault(x => x.EmployeeNo == request.employeeNo);

            GetResponse response = new()
            {
                EmployeeNo = data.EmployeeNo,
                FirstName = data.FirstName,
                LastName = data.LastName
            };

            return response;
        }
    }
}
