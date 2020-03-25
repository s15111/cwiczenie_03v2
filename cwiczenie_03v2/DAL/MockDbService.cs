using cwiczenie_03v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenie_03v2.DAL
{


    public class MockDbService : IDbService
    {

        private static IEnumerable<Student> _students;
        
        
        static MockDbService()
        {

            _students = new List<Student>
            {
        /*        new Student{idStudent=1, FirstName="Jan", LastName="Kowalski"},
                new Student{idStudent=2, FirstName="Anna", LastName="Malewski"},
                new Student{idStudent=3, FirstName="Andrzej", LastName="Andrzejewicz"},*/
            };
        }

        public IEnumerable<Student> GetStudent()
        {
            return _students;
        }
    }
}
