﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public interface IComputingDevice
    {
        bool IsWorking { get; set; }
        string DeviceOn();
        string DeviceOff();
    }
}
