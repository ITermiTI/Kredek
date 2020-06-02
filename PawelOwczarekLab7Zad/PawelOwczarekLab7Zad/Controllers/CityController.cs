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
    /// Klasa kontrolera dla miast
    /// </summary>
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        //Obiekt serwisu dla tabeli miasta
        private CityService _cityService;

        public CityController()
        {
            _cityService = new CityService();
        }

        /// <summary>
        /// Metoda httpget dla wszystkich miast
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var countries = _cityService.Get();
            return Ok(countries);
        }

        /// <summary>
        /// Metoda httpget dla miasta o wybranym ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get([FromRoute] int Id)
        {
            var country = _cityService.get(Id);
            return Ok(country);
        }

        /// <summary>
        /// Metoda httppost dla wyslanego miasta (np w formularzu)
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] City city)
        {
            var id = _cityService.Post(city);
            return Ok(id);
        }

        /// <summary>
        /// Metoda httpput dla zmienionego miasta o podanym id
        /// </summary>
        /// <param name="city"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put([FromBody] City city, [FromRoute] int id)
        {
            var isUpdateSuccessful = _cityService.Put(city, id);
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
        /// Metoda httpdelete dla miasta o podanym ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            bool isDeleteSuccesful = _cityService.Delete(id);
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