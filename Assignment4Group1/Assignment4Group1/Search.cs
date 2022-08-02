using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4Group1
{
    public class Search : IComparable<Search>
    {
       


        public double Number { get; set; }

        public Search(double num)
        {
            this.Number = num;
        }

        public int CompareTo(Search other)
        {
            if (object.ReferenceEquals(other, null))
                    return -1;
            else
                return Number.CompareTo(other.Number);

            throw new NotImplementedException();
        }      
    }
}
