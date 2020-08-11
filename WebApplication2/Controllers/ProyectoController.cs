using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{   
    [Route("api/proyecto")]
    public class ProyectoController : ApiControllerBase
    {
        private readonly IProyectoService proyectoService;
        public ProyectoController(IProyectoService proyectoService)
        {
            this.proyectoService = proyectoService;
        }

        [HttpGet("update")]
        //[ProducesResponseType(typeof(IEnumerable<ProyectoDto>))]
        public HttpResponseMessage Update(HttpRequestMessage request, [FromBody] ProyectoDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.Update(dto);
                response = request.CreateResponse(HttpStatusCode.OK);
            }

            return response;

        }

        [HttpGet("get")]
        //[ProducesResponseType(typeof(IEnumerable<ProyectoDto>))]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK);
            }

            return response;

        }

        [HttpGet("get")]
        //[ProducesResponseType(typeof(IEnumerable<ProyectoDto>))]
        public HttpResponseMessage GetOne(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK);
            }

            return response;

        }

        // CREAR EL RESTO DE LOS METODOS, DTO Y SERVICES
    }
}
