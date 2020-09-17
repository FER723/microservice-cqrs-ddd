using Microsoft.AspNetCore.Http;
using ServicioPrueba.Application.Configuration.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioPrueba.API.SeedWork
{
    public class InvalidCommandProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InvalidCommandProblemDetails(InvalidCommandException exception)
        {
            this.Title = exception.Message;
            this.Status = StatusCodes.Status400BadRequest;
            this.Detail = exception.Details;
            this.Type = "https://somedomain/validation-error";
        }
    }
}
