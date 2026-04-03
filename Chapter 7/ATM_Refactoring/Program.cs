using ATM_Refactoring.Exceptions;
using ATM_Refactoring.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Refactoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new ATMDeviceController();

            try
            {
                atm.Withdraw("ACC123", 500);
                Console.WriteLine("Withdrawal successful.");
            }
            catch (DeviceNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DeviceLockedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NetworkConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}
