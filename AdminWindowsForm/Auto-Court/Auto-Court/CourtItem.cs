using System;
using System.Collections.Generic;
using System.Text;

namespace Auto_Court
{
    class CourtItem
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public CourtItem(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
