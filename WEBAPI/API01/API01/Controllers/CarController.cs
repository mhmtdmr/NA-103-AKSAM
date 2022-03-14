using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API01.Entity;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private static List<Car> CarList = new List<Car>() { 
            new Car(){ID=1,Brand="Honda",Model="NSX",EngineSize=2500},
            new Car(){ID=2,Brand="Nissan",Model="GTR",EngineSize=3000},
            new Car(){ID=3,Brand="Mazda",Model="MX5",EngineSize=2000},
        };

        // GET: api/<CarController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CarList);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(CarList.Where(car => car.ID == id));
        }

        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post([FromBody] Car newCar)
        {
            if (newCar != null)
                CarList.Add(newCar);
            //return StatusCode(201, "Eklendi!");
            return Created("Yeni araba","Eklendi!");
                //.StatusCode = 201;  (201,"The new car added!");
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Car updatedCar)
        {
            var currentCar = CarList.SingleOrDefault(car => car.ID == updatedCar.ID);
            if (currentCar is not null)
            {
                currentCar.Brand = updatedCar.Brand != default ? updatedCar.Brand : currentCar.Brand;
                currentCar.Model = updatedCar.Model != default ? updatedCar.Model : currentCar.Model;
                currentCar.EngineSize = updatedCar.EngineSize != default ? updatedCar.EngineSize : currentCar.EngineSize;
                return Ok("Başarı ile güncellendi");
            }
            return BadRequest("Bu araba yok ki güncellensin!!!");
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car selectedCar = CarList.Where(car => car.ID == id).SingleOrDefault();
            if (selectedCar is null)
                return BadRequest("Silinmek istenen araba bulunamadı!");
            CarList.Remove(selectedCar);
            return Ok("Araba başarı ile silindi!");
        }
    }
}
