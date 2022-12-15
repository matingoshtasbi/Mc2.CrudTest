using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Contract.Queries.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers.CustomerManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        #region members
        private readonly ISender _mediator;
        #endregion

        #region constractors
        public CustomersController(ISender mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region public methods
        [HttpGet]
        public async Task<ActionResult<List<CustomerVM>>> GetAll([FromQuery] FindCustomerRequest request)
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery(request));
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerVM>> Get(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomersQuery(id));
            return Ok(customer);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> AddEmployee([FromBody] CustomerRequest request)
        {
            return Ok(await _mediator.Send(new CreateCustomerCommand(request)));
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateEmployee([FromBody] CustomerRequest request)
        {
            await _mediator.Send(new UpdateCustomerCommand(request));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return Ok();
        }
        #endregion
    }
}
