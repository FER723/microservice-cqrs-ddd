using Microsoft.AspNetCore.Http;
using ServicioPrueba.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioPrueba.API.SeedWork
{
    public class BusinessRuleValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            this.Title = exception.Message;
            this.Status = StatusCodes.Status409Conflict;
            this.Detail = exception.Details;
            this.Type = "https://somedomain/business-rule-validation-error";
        }
    }
}
