using System.ComponentModel.Design.Serialization;
using AutoMapper;

using Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Assecor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        private IPersonService _personService;
        private IColorService _colorService;

        public PersonsController(IPersonService personService, IColorService colorService)
        {
            _personService = personService;
            _colorService = colorService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(_personService.GetPersons());
        }

        [HttpGet("{id}")]
        public ActionResult? Get(int id)
        {
            var result = _personService.GetPerson(id);
            if (result == null)
                return Problem(detail:$"The Person with this '{id}' id has not found.");
            return Json(result);
        }

        [HttpGet("color/{id}")]
        public ActionResult? GetByColor(int id)
        {
            var persons = _personService.GetPersons();
            var color = _colorService.GetColor(id);
            if (color == null)
                return Problem(detail: $"The Color with this '{id}' id has not found.");
            return Json( persons.Where(x=>x.Color.ToLower().Equals(color.Farbe.ToLower())));
        }
    }
}
