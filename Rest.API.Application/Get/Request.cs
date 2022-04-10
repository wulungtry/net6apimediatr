using MediatR;

namespace Rest.API.Application
{
    public class GetRequest : IRequest<GetResponse>
    {
        public string employeeNo { get; init; }

        public GetRequest(string employeeNo)
        {
            this.employeeNo = employeeNo;
        }
    }
}
