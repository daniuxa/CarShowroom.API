using CarShowroom.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Bll.Interfaces
{
    public interface IEnginesService
    {
        Task<IEnumerable<Engine>> GetEnginesForCompany(string companyName);
    }
}
