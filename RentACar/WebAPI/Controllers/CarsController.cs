﻿using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcardetails")]
        public IActionResult GetAllCarDetails()
        {
            var result = _carService.GetAllCarDetails();
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail(int id)
        {
            var result = _carService.GetCarDetail(id);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
