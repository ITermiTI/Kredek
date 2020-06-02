using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawelOwczarekLab7Zad.Services;

namespace PawelOwczarekLab7Zad.Controllers
{
    /// <summary>
    /// Klasa kontrolera dla krajow
    /// </summary>
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        //Obiekt serwisu dla tabeli kraju
        private CountryService _countryService;

        public CountryController()
        {
            _countryService = new CountryService();
        }
        /// <summary>
        /// Metoda httpget dla wszystkich krajow
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var countries = _countryService.Get();
            return Ok(countries);
        }
        /// <summary>
        /// Metoda httpget dla kraju o wybranym ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get([FromRoute] int Id)
        {
            var country = _countryService.get(Id);
            return Ok(country);
        }
        /// <summary>
        /// Metoda httppost dla wyslanego kraju (np w formularzu)
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Country country)
        {
            var id = _countryService.Post(country);
            return Ok(id);
        }

        /// <summary>
        /// Metoda httpput dla zmienionego kraju o podanym id
        /// </summary>
        /// <param name="city"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put([FromBody] Country country, [FromRoute] int id)
        {
            var isUpdateSuccessful = _countryService.Put(country, id);
            if (isUpdateSuccessful)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Metoda httpdelete dla kraju o podanym ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            bool isDeleteSuccesful = _countryService.Delete(id);
            if (isDeleteSuccesful)
            {
                ;
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}