using System;
using System.Collections.Generic;
using System.Linq;

namespace Nn
{
    public class NeuralNetwork
    {
        public List<List<Neuron>> Neurons { get; set; } = new List<List<Neuron>>();

        public static NeuralNetwork Create()
        {
            return new NeuralNetwork();
        }

        public NeuralNetwork AddDenseLayer(int count, Func<double,double> activationFunction, Func<double> weightInitializationFunc)
        {
            Neurons.Add(Enumerable.Range(0, count).Select(n => new Neuron()).ToList());
            if (Neurons.Count() > 1)
            {
                var lastLayer = Neurons[Neurons.Count() - 2];
                var currentLayer = Neurons.Last();
                lastLayer.ForEach(ln => {
                    currentLayer.ForEach(cn => {
                        ln.Connect(cn, weightInitializationFunc());
                    });
                });
            }
            return this;
        }
    }
}
