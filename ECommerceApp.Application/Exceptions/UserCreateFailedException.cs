﻿namespace ECommerceApp.Application.Exceptions
{
    public sealed class UserCreateFailedException : Exception
    {
        public UserCreateFailedException()
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
