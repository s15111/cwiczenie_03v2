using cwiczenie_03v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenie_03v2.DAL
{
    public interface IDbService
    {

        public IEnumerable<Student> GetStudent();

    }
}
