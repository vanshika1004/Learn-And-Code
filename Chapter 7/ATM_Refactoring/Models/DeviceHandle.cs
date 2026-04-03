using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Refactoring.Models
{
    public class DeviceHandle
    {
        public static DeviceHandle INVALID = new DeviceHandle { IsValid = false };
        public bool IsValid { get; set; }
    }
}
