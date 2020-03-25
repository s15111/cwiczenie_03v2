using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        private const string Sciezka = "Data Source=db-mssql;Initial Catalog=s15111;Integrated Security=True";
        private IDbService _dbService;

       

        public SudentController(IDbService dbService)
        {
            _dbService = dbService;
        }




        [HttpGet]

        public IActionResult GetStudent()

        {

            List<Student> students = new List<Student>();

            using (var con = new SqlConnection(Sciezka))

            using (var com = new SqlCommand())

            {

                com.Connection = con;

                com.CommandText =

                    "SELECT FirstName, LastName, BirthDate, Semester, Name FROM Student " +

                    "INNER JOIN Enrollment ON Student.IdEnrollment = Enrollment.IdEnrollment " +

                    "INNER JOIN Studies ON Studies.IdStudy = Enrollment.IdStudy";



                con.Open();

                var dr = com.ExecuteReader();

                while (dr.Read())

                {

                    var st = new Student();

                    st.FirstName = dr["FirstName"].ToString();

                    st.LastName = dr["LastName"].ToString();

                    st.BirthDate = dr["BirthDate"].ToString();

                    st.idEnrollment = dr["Semester"].ToString();

                    st.NameOfStudies = dr["Name"].ToString();

                    students.Add(st);

                }



            }
            return Ok(students);

        }


        [HttpGet("{id}")]
        public IActionResult GetStudent(String id)
        {


            List<Enrollment> zapisy = new List<Enrollment>();



            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18728;Integrated Security=True"))

            using (var com = new SqlCommand())

            {

                com.Connection = con;

                com.CommandText = "SELECT * FROM Enrollment INNER JOIN Student ON Enrollment.IdEnrollment = Student.IdEnrollment WHERE Student.IndexNumber = @id";

                com.Parameters.AddWithValue("id", id);



                con.Open();

                var dr = com.ExecuteReader();

                while (dr.Read())

                {

                    var en = new Enrollment();

                    en.IdEnrollment = dr["IdEnrollment"].ToString();

                    en.Semester = dr["Semester"].ToString();

                    en.IdStudy = dr["IdStudy"].ToString();

                    en.StartDate = dr["StartDate"].ToString();

                    zapisy.Add(en);

                }



                return Ok(zapisy);

            }



        }



        /*
                public IActionResult CreateStudent(Student student)
                {

                    student.IndexNumber = $"s{new Random().Next(1,20000)}" ;
                    return Ok(student);

                }


        */



        /* [HttpDelete("{id}")]

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
 */


    }

}