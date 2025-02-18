using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class customerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public customerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall-customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}