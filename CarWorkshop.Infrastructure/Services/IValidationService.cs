using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Services
{
    public interface IValidationService
    {
        Task<Boolean> ValidatePesel(string Pesel);

        Task<Boolean> ValidateIdNumber(string IdNumber);
    }
}
