using System;
using System.Collections.Generic;
using System.Linq;

namespace Nn
{
    public class Neuron
    {
        private readonly Guid _guid;
        public Neuron()
        {
            _guid = Guid.NewGuid();
        }
        public Func<double, double> ActivationFunction { get; set; } = CommonActivations.Rectifier;
        public List<Synapse> Outputs { get; set; } = new List<Synapse>();
        //Possibly Redundant
        public List<Synapse> Inputs { get; set; } = new List<Synapse>();
        private Dictionary<Neuron, double> InputValues { get; } = new Dictionary<Neuron, double>();
        private double TotalInputValue => InputValues.ToList().Select(kv => kv.Value).Aggregate(0d, (a, v) => a + v);
        public double ActivatedValue => ActivationFunction(TotalInputValue);

        public Neuron Connect(Neuron next, double weight)
        {
            Outputs.Add(new Synapse(next, weight));
            return this;
        }
        public Neuron Connect(Neuron next)
        {
            var r = new Random();
            var weight = r.NextDouble() / 100;
            Outputs.Add(new Synapse(next, weight));
            return this;
        }

        public void Activate(double value, Neuron from)
        {
            InputValues[from] = value;
            Outputs.ForEach(o => o.Destination.Activate(ActivatedValue * o.Weight, this));
        }

        public void Activate(double value)
        {
            Activate(value, PhantomNeuron);
        }

        //Represents a manual activation
        private static Neuron _phantomNeuron;
        public static Neuron PhantomNeuron {
            get
            {
                if (_phantomNeuron == null)
                {
                    _phantomNeuron = new Neuron();
                }
                return _phantomNeuron;
            }
        }
    }
}
