using ATM_Refactoring.Exceptions;
using ATM_Refactoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Refactoring.Services
{
    public class ATMDeviceController
    {
        private const double DEFAULT_BALANCE = 1000;
        public void Withdraw(string accountId, double amount)
        {
            var handle = GetHandle("DEV1");
            ValidateDevice(handle);

            var record = RetrieveDeviceRecord(handle);
            ValidateDeviceStatus(record);

            ValidateConnection(record);

            ValidateBalance(accountId, amount);

            DispenseCash(handle, amount);
        }

        private void ValidateDevice(DeviceHandle handle)
        {
            if (handle == null || !handle.IsValid)
                throw new DeviceNotFoundException();
        }

        private void ValidateDeviceStatus(DeviceRecord record)
        {
            if (record.IsSuspended)
                throw new DeviceLockedException();
        }

        private void ValidateConnection(DeviceRecord record)
        {
            if (!record.IsConnected)
                throw new NetworkConnectionException();
        }

        private void ValidateBalance(string accountId, double amount)
        {
            if (GetBalance(accountId) < amount)
                throw new InsufficientFundsException();
        }

        private DeviceHandle GetHandle(string deviceId)
        {
            return new DeviceHandle { IsValid = true };
        }

        private DeviceRecord RetrieveDeviceRecord(DeviceHandle handle)
        {
            return new DeviceRecord
            {
                IsSuspended = false,
                IsConnected = true
            };
        }

        private double GetBalance(string accountId)
        {
            return DEFAULT_BALANCE;
        }

        private void DispenseCash(DeviceHandle handle, double amount)
        {
            Console.WriteLine($"Cash dispensed: {amount}");
        }
    }
}
