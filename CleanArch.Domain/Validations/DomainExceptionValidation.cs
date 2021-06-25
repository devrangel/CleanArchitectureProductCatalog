using System;

namespace CleanArch.Domain.Validations
{
    public class DomainExceptionValidation : Exception
    {
        private DomainExceptionValidation(string message) : base(message)
        {
        }

        public static void When(bool hasError, string error)
        {
            if(hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
