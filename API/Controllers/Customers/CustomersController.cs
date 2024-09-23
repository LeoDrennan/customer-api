using AutoMapper;
using Domain.Models;
using API.Controllers.Customers.Contracts;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customers
{
    /// <summary>
    ///     Basic customer information.
    /// </summary>
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        ///     Returns a list of all customers.
        /// </summary>
        /// <response code="200">
        ///     The call was successful and returned a list of customers.
        ///     An empty list is returned when no records are found.
        /// </response>
        [HttpGet]
        [ProducesResponseType(typeof(CustomersListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            try
            {
                List<CustomerModel> customers = await _customerService.GetAllAsync();

                CustomersListResponse response = CustomersMapper.Map(customers);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Returns a single customer object for the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">The customer was found and returned.</response>
        /// <response code="404">No customer could be found with the id provided.</response>
        [HttpGet("{id:int:min(1)}", Name = nameof(GetCustomerByIdAsync))]
        [ActionName(nameof(GetCustomerByIdAsync))]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerByIdAsync([FromRoute] int id)
        {
            try
            {
                CustomerModel? customer = await _customerService.GetByIdAsync(id);

                if (customer is null) return NotFound();

                CustomerResponse response = CustomersMapper.Map(customer);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Creates a new customer.
        /// </summary>
        /// <param name="request"></param>
        /// <response code="201">The customer was successfully created.</response>
        /// <response code="422">The request cannot be processed or is invalid.</response>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerRequest request)
        {
            try
            {
                CustomerModel model = CustomersMapper.Map(request);

                CustomerModel createdCustomer = await _customerService.CreateCustomerAsync(model);

                CustomerResponse response = CustomersMapper.Map(createdCustomer);

                return CreatedAtAction(nameof(GetCustomerByIdAsync), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Updates an existing customer.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <response code="200">The customer was successfully updated.</response>
        /// <response code="404">No customer could be found with the id provided.</response>
        /// <response code="422">The request cannot be processed or is invalid.</response>
        [HttpPut("{id:int:min(1)}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int id, [FromBody] CustomerRequest request)
        {
            try
            {
                CustomerModel model = CustomersMapper.Map(id, request);

                CustomerModel updatedCustomer = await _customerService.UpdateCustomerAsync(model);

                CustomerResponse response = CustomersMapper.Map(updatedCustomer);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Deletes an existing customer.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">The customer was successfully deleted.</response>
        /// <response code="404">No customer could be found with the id provided.</response>
        [HttpDelete("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int id)
        {
            try
            {
                CustomerModel? customer = await _customerService.GetByIdAsync(id);

                if (customer is null) return NotFound();

                await _customerService.DeleteCustomerById(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

