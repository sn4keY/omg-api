using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenMyGarage.Domain.Service
{
    public interface IGateService
    {
        Task ToggleGate();
    }
}
