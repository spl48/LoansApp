using AutoMapper;
using LoansApp.Core.Services;
using LoansApp.Server.Models;
using LoansApp.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoansApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ILoanApplicationService _loanApplicationService;

        public LoanApplicationController(IMapper mapper, ILogger<CustomerController> logger,
            ILoanApplicationService loanApplicationService)
        {
            _mapper = mapper;
            _logger = logger;
            _loanApplicationService = loanApplicationService;
        }

        [HttpGet("{customerId}")]
        public IActionResult GetLoanApplicationsByCustomerId(int customerId)
        {
            var loanApplications = _loanApplicationService.GetLoanApplicationsByCustomerId(customerId);

            if (loanApplications.Any())
                return Ok(_mapper.Map<IEnumerable<LoanApplicationVM>>(loanApplications));

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoanApplicationVM loanApplication)
        {
            if (ModelState.IsValid)
            {
                var appLoanApplication = _mapper.Map<LoanApplication>(loanApplication);
                var result = await _loanApplicationService.CreateLoanApplicationAsync(appLoanApplication);
                return Ok();

            }

            return BadRequest(ModelState);
        }
    }
}
