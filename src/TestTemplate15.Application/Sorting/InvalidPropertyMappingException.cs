using System;

namespace TestTemplate15.Application.Sorting
{
    public class InvalidPropertyMappingException : Exception
    {
        public InvalidPropertyMappingException(string message)
            : base(message)
        {
        }
    }
}
