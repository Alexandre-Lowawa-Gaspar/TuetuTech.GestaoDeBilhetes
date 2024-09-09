using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message ): base (message)
        {
            
        }
    }
}
