using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.Commands.Client
{
    public class DeleteClient : ICommand
    {
        public int Id { get; set; }
    }
}
