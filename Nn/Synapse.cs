using System;
using System.Collections.Generic;
using System.Text;

namespace Nn
{
    public class Synapse
    {
        public Synapse(Neuron destination, double weight)
        {
            Destination = destination;
            Weight = weight;
        }
        public Neuron Destination { get; set; }
        public double Weight { get; set; }
    }
}
