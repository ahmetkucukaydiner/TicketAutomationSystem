using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BusOwnerValidator : AbstractValidator<BusOwner>
    {
        public BusOwnerValidator()
        {

        }
    }
}
