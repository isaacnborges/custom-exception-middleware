﻿using System;

namespace CustomExceptionMiddleware.CustomExceptions
{
    #pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class NotFoundException : Exception
    #pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}

