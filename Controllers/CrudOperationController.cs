using Crud_Operations.CommonLayer.Model;
using Crud_Operations.RepositoryLayer;
using Crud_Operations.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Crud_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        public readonly ICrudOperationSL _crudOperationSL; //calling interface fromservice layer and writing instance of _crudOperationSL. There was one error also we we imported the class. Instance of interface cant be created.  

        public CrudOperationController(ICrudOperationSL crudOperationSL) // constructor of class. this is where we inject our service.
        {
            _crudOperationSL = crudOperationSL;
        }

        [HttpPost]
        [Route(template: "CreateRecord")]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;

            try {
                   response = await _crudOperationSL.CreateRecord(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
            
        }
    }
}
