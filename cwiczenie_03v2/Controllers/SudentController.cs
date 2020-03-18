using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenie_03v2.DAL;
using cwiczenie_03v2.Models;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenie_03v2.Controllers
{
    [ApiController]
    [Route("api/student")]


    public class SudentController : ControllerBase
    {
        private readonly IDbService _dbService;

        public SudentController(IDbService dbService)
        {
            _dbService = dbService;
        }




        [HttpGet]

        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudent());
        }



        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("kowalski");
            }else if( id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("nie znaleziono studenta");
        }

        public IActionResult CreateStudent(Student student)
        {

            student.IndexNumber = $"s{new Random().Next(1,20000)}" ;
            return Ok(student);

        }


        [HttpDelete("{id}")]

        public IActionResult DeleteStudent(int id)

        {

            //find student in database

            //jesli istnieje to usun, jesli nie to nie znaleziono

            if (id == 1)
            {
                //usuniecie studenta z bazy
                return Ok("Usunieto");
            }
            return NotFound("nie znaleziono studneta o danym id");
        }




        [HttpPut("{id}")]

        public IActionResult UpdateStudent(string Name, int id)
        {
            //find student in database
            //jesli istnieje update, jesli nie to nie znaleziono
            if (id == 1)
            {
                //zmiana imienia studenta
                return Ok("Aktualizacja zakonczona");
            }
            return NotFound("nie znaleziono studneta  id");
        }



    }

}