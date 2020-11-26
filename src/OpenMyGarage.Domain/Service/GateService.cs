using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenMyGarage.Domain.Service
{
    public class GateService : IGateService
    {
        public async Task ToggleGate()
        {
            var pin = 11;
            var gpioController = new GpioController();

            gpioController.OpenPin(pin, PinMode.Output);
            gpioController.Write(pin, PinValue.High);
            await Task.Delay(10);
            gpioController.Write(pin, PinValue.Low);
        }
    }
}
