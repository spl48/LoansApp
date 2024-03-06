using AutoMapper;
using LoansApp.Core.Services;
using LoansApp.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoansApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _mapper = mapper;
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var allCustomers = _customerService.GetAllCustomersData();
            return Ok(_mapper.Map<IEnumerable<CustomerVM>>(allCustomers));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerVM customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
                AddModelError($"{nameof(customer.FirstName)} is required when registering.",
                    nameof(customer.FirstName));

            if (ModelState.IsValid)
            {
                var appCustomer = _mapper.Map<Customer>(customer);
                var result = await _customerService.CreateCustomerAsync(appCustomer);
                return Ok();

            }

            return BadRequest(ModelState);
        }

        protected void AddModelError(string error, string key = "")
        {
            ModelState.AddModelError(key, error);
        }
    }
}
