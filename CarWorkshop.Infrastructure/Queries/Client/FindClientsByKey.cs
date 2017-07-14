using CarWorkshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Queries.Client
{
    public class FindClientsByKey : IQuery<Task<ClientDTO>>
    {
        public string EmailAddress { get; set; }

        public int ID { get; set; }
    }
}
