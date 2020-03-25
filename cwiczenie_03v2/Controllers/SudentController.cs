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


        public IActionResult GetStudents([FromServices] IDbService dbServices)
        {

            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(Sciezka))
            using(SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from student";


                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.idEnrollment = dr["idEnrollment"].ToString();
                    list.Add(st);

                }
            }

            return Ok(list);
          
        }


        [HttpGet("{id}")]
        public IActionResult GetStudent(String id)
        {
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(Sciezka))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from student where IndexNumber =@index";

                com.Parameters.AddWithValue("index", id);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Student();

                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.idEnrollment = dr["idEnrollment"].ToString();
                    return Ok(st);

                }
                else
                {
                    return NotFound("nie znaleziono studenta");
                }
            }
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