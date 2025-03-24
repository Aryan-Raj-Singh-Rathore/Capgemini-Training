using CustomerService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Service
{
    public interface IRegistrationManager
    {
        public RegistrationResponseDto Register(RegistrationRequestDto request);
    }
}
