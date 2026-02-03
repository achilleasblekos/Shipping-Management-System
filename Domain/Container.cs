using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystem.Domain
{
    public abstract class Container
    {
        private string code;
        private string destination;

        public Container(string code, string destination)
        {
            this.code = code;
            this.destination = destination;
        }

        public abstract double GetCharge();
    }
}