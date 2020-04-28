using System;
using MathExprSolver.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MathExprSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<double> Get(string expr)
        {
            try {
                return Solver.Solve(expr);
            } catch (InvalidCharacterSequenceException e) {
                return StatusCode(500, new {message = "Invalid character in given expr", character = e.Character, position = e.Position});
            } catch (InvalidNumberException e) {
                return StatusCode(500,
                                  new {
                                      message = "Invalid number part in expr", number = e.Number, startPosition = e.StartPosition, endPosition = e.EndPosition
                                  });
            } catch (UnexpectedEndOfInputException) {
                return StatusCode(500, new {message = "Unexpected end of input"});
            } catch (Exception) {
                return StatusCode(500, new {message = "Unknown error occured"});
            }
        }
    }
}