using Crud_Operations.CommonLayer.Model;
using System.Threading.Tasks;

namespace Crud_Operations.RepositoryLayer
{
    public interface ICrudOperationRL
    {
        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

    }
}
