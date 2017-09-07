﻿using MyApp.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Validations
{
    public class RegisterNewClientCommandValidation : ClientValidation<RegisterNewClientCommand>
    {
        public RegisterNewClientCommandValidation()
        {
            ValidateName();
        }
    }
}