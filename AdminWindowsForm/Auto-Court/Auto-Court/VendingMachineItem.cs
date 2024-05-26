using System;
using System.Collections.Generic;
using System.Text;

namespace Auto_Court
{
    class VendingMachineItem
    {
        public int Id { get; set; }

        public VendingMachineItem(int id)
        {
            Id = id;
        }
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
