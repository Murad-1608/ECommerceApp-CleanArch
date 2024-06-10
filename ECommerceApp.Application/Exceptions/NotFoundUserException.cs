using System;

namespace ECommerceApp.Application.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException(string? message) : base(message)
        {
        }
    }
}
