using Crud_Operations.CommonLayer.Model;
using Crud_Operations.RepositoryLayer;
using System.Threading.Tasks;

namespace Crud_Operations.ServiceLayer
{
    public class CrudOperationSL : ICrudOperationSL
    {
        public readonly ICrudOperationRL _crudOperationRL; // calling interface of repository layer for DI. REP layer is for the data fetching from DB using EF core

        public  CrudOperationSL(ICrudOperationRL crudOperationRL)
        {
            _crudOperationRL = crudOperationRL;
        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
           return await _crudOperationRL.CreateRecord(request);
        }
    }
}
