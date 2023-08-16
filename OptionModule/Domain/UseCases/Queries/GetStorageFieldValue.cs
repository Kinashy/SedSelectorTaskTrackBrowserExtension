using System.Threading.Tasks;
using testprog.CqrsCore;

namespace testprog.OptionModule.Domain.UseCases.Queries
{
    public class GetStorageFieldValue : IQuery<Task<string?>>
    {
        public string Field { get; }
        public GetStorageFieldValue(string field) 
        {
            Field = field;
        }
    }
}
