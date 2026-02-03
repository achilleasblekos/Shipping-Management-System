using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystem.Domain
{
    public class RefrigeratorContainer : Container
    {
        private double power;

        public RefrigeratorContainer(string code, string destination, double power)
            : base(code, destination)
        {
            this.power = power;
        }

        public override double GetCharge()
        {
            return 2000 * power;
        }
    }
}