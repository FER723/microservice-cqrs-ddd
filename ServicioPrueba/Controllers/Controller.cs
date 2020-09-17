using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ervicioPrueba.API.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServicioPrueba.Application.Atributos.AddAtributos;
using ServicioPrueba.Application.Atributos.GetAtributos;

namespace ServicioPrueba.API.Atributos
{
    [Route("api/v1")]
    [ApiController]
    public class AtributosController : Controller
    {
        private readonly IMediator _mediator;

        public AtributosController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Get customer orders.
        /// </summary>
        /// <returns>List of atributes</returns>
        [Route("/atributos")]
        [HttpGet]
        [ProducesResponseType(typeof(List<AtributoDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAtributos()
        {
            var atributos = await _mediator.Send(new GetAtributosQuery());

            return Ok(atributos);
        }

        /// <summary>
        /// Get atributos ID.
        /// </summary>
        /// <param name="atributoID">Atributo ID.</param>
        /// <returns>List of atributes</returns>
        [Route("/atributos/{atributoID}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<AtributoDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAtributoID(int atributoID)
        {
            var atributos = await _mediator.Send(new GetAtributosQuery(atributoID));

            return Ok(atributos);
        }

        /// <summary>
        /// Add atributo
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /atributos
        ///     {
        ///        "AtributoId": 1,
        ///        "Descripcion": "Liquidame"
        ///     }
        /// </remarks>
        /// <param name="request">AtributoRequest</param>
        /// <returns>Atributo Creado</returns>
        [Route("/atributos")]
        [HttpPost]
        [ProducesResponseType(typeof(AtributoDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterAtributo([FromBody]AtributosRequest request)
        {
            var atr = await _mediator.Send(new AtributosAddCommand(request.AtributoId, request.Descripcion));

            return Created(string.Empty, atr);
        }

        /// <summary>
        /// Modificar atributo
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /atributos
        ///     {
        ///        "AtributoId": 1,
        ///        "Descripcion": "Liquidame"
        ///     }
        /// </remarks>
        /// <param name="request">AtributoRequest</param>
        /// <returns>Atributo Creado</returns>
        [Route("/atributos")]
        [HttpPut]
        [ProducesResponseType(typeof(AtributoDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarAtributo([FromBody]AtributosRequest request)
        {
            var atr = await _mediator.Send(new AtributosModifyCommand(request.AtributoId, request.Descripcion));

            return Ok(atr);
        }

        /// <summary>
        /// Delete atributo
        /// </summary>
        /// <param name="atributoID">Atributo ID.</param>
        /// <returns></returns>
        [Route("/atributos")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAtributo(int atributoID)
        {
            var atr = await _mediator.Send(new AtributosDeleteCommand(atributoID));

            return Ok(atr);
        }
    }
}