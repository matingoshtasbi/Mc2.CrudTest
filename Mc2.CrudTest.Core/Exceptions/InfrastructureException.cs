﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException()
        {
        }

        public InfrastructureException(string? message) : base(message)
        {
        }

        public InfrastructureException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InfrastructureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
