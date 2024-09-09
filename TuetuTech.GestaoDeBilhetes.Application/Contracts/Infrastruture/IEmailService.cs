using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Models.Mail;

namespace TuetuTech.GestaoDeBilhetes.Application.Contracts.Infrastruture
{
    public interface IEmailService
    {
        Task<bool> EnviarEmail(Email email);
    }
}
