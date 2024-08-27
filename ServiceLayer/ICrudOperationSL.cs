using Crud_Operations.CommonLayer.Model;
using System.Threading.Tasks;

namespace Crud_Operations.ServiceLayer
{
    public interface ICrudOperationSL
    {
        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);
    }
}
