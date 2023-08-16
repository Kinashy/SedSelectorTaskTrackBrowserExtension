using System.Threading.Tasks;
using SelectorExtensionForChrome.CqrsCore;

namespace SelectorExtensionForChrome.OptionModule.Domain.UseCases.Queries
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
