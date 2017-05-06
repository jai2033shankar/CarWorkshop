using CarWorkshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Employee Get(Guid Id);

        Employee Get(string firstname);

        IEnumerable<Employee> GetAll();

        void Add(Employee employee);

        void Remove(Guid Id);

        void Update(Employee employee);

    }
}
