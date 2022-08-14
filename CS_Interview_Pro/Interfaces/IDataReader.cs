using CS_Interview_Pro.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interview_Pro.Interfaces
{
    public interface IDataReader
    {
        Task<List<Trade>> ReadMultiple(List<string> fileLocations);
    }
}
