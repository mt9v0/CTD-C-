using Microsoft.AspNetCore.Mvc;
using Lab3.Services;
using System;
using System.Threading.Tasks;
using Lab3.Models;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Xml.Linq;

namespace Lab3.Controllers
{
    [ApiController]
    [Route("api/Equations")]
    public class EquationController : ControllerBase
    {
        private readonly IEqService _eqServices;

        public EquationController(IEqService compService)
        {
            _eqServices = compService;
        }

        [HttpPost("solve-1")]
        public async Task<IActionResult> AddEquation1([Required] float k, [Required] float b)
        {
            try
            {
                if (k == 0)
                {
                    return BadRequest("k should not be 0");
                }
                Equation resEq = new Equation(k, b);
                return Ok(await _eqServices.Solve(resEq));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error solving Equation: {ex.Message}");
            }
        }

        [HttpPost("solve-2")]
        public async Task<IActionResult> AddEquation2([Required] float a, [Required] float b, [Required] float c)
        {
            try
            {
                if (a == 0)
                {
                    return BadRequest("a should not be 0");
                }
                Equation resEq = new Equation(a, b, c);
                await _eqServices.Solve(resEq);

                return Ok(resEq.PrintEquation());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error solving equation: {ex.Message}");
            }
        }

        [HttpGet("find")]
        public async Task<IActionResult> FindEq([Required] int index)
        {
            try
            {
                if (index <= 0 )
                {
                    return BadRequest("Index should be more than zero");
                }
                string eq = await _eqServices.Find(index);
                if (eq != "")
                {
                    return Ok(eq);
                }
                else return Ok("No equation with such number on the list");

            }
            catch (Exception ex)
            {
                return BadRequest($"Error finding the equation: {ex.Message}");
            }
        }

        [HttpDelete("clear")]
        public async Task<ActionResult> Clear()
        {
            try
            {
                await _eqServices.Clear();

                return Ok($"The list is now empty");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error clearing the list: {ex.Message}");
            }
        }
    }

}
