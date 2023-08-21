using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserForRegisterDto:IDto
    {
        public string Name{ get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
