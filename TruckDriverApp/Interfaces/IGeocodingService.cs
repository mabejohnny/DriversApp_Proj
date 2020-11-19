using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckDriverApp.Models;

namespace TruckDriverApp.Interfaces
{
    public interface IGeocodingService
    {
        public Task<Facility> AttachLatAndLong(Facility facility);

    }
}
