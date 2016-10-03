using System;
using System.Collections.Generic;

namespace Computers.Models.Components.HardDrives
{
    public class SingleHardDrive : HardDrive
    {
        private IDictionary<int, string> data;
        private int capacity;

        public SingleHardDrive(int capacity)
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>();
        }

        public override int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public override string LoadData(int address)
        {
            if (!this.data.ContainsKey(address))
            {
                throw new ArgumentException("This key is not in the memory");
            }
            else
            {
                var resultData = this.data[address];
                return resultData;
            }
        }

        public override void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }
    }
}
