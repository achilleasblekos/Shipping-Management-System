using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystem.Domain
{
    public class BulkContainer : Container
    {
        private int weight;

        public BulkContainer(String code, String destination, int weight)
            : base(code, destination)
        {
            this.weight = weight;
        }

        public override double GetCharge()
        {
            return 10 * weight;
        }
    }
}