using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Models.Components.HardDrives
{
    public class RaidArray : HardDrive
    {
        private ICollection<HardDrive> drives;

        public RaidArray(ICollection<HardDrive> drives)
        {
            this.drives = drives;
        }

        public override int Capacity
        {
            get
            {
                if (this.drives.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return this.drives.First().Capacity;
                }
            }
        }

        public override string LoadData(int address)
        {
            if (!this.drives.Any())
            {
                throw new ArgumentException("No harddrives in the array");
            }
            else
            {
                return this.drives.First().LoadData(address);
            }
        }

        public override void SaveData(int address, string data)
        {
            foreach (var drive in this.drives)
            {
                drive.SaveData(address, data);
            }
        }
    }
}
