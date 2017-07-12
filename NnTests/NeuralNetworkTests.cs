using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nn;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NnTests
{
    [TestClass]
    public class NeuralNetworkTests
    {
        [TestMethod]
        public void AddDenseLayer_should_create_new_layer_neurons()
        {
            var network = NeuralNetwork.Create()
                .AddDenseLayer(3, CommonActivations.Rectifier, CommonDistributions.SmallUniformRandom)
                .AddDenseLayer(1, CommonActivations.Rectifier, CommonDistributions.SmallUniformRandom)
                .AddDenseLayer(1, CommonActivations.Sigmoid, CommonDistributions.SmallUniformRandom);

            Assert.AreEqual(network.Neurons[0].Count, 3);
            Assert.AreEqual(network.Neurons[1].Count, 1);
            Assert.AreEqual(network.Neurons[2].Count, 1);
        }

        [TestMethod]
        public void AddDenseLayer_should_link_neuron_in_new_layer()
        {
            var network = NeuralNetwork.Create()
                .AddDenseLayer(1, CommonActivations.Rectifier, CommonDistributions.SmallUniformRandom)
                .AddDenseLayer(1, CommonActivations.Rectifier, CommonDistributions.SmallUniformRandom);

            network.Neurons[0][0].Activate(5);

            Assert.IsTrue(network.Neurons[0][0].Outputs.Select(o => o.Destination).Contains(network.Neurons[1][0]));
        }

        [TestMethod]
        public void AddDenseLayer_should_link_all_neurons_in_new_layer()
        {
            var network = NeuralNetwork.Create()
                .AddDenseLayer(2, CommonActivations.Rectifier, CommonDistributions.SmallUniformRandom)
                .AddDenseLayer(2, CommonActivations.Rectifier, CommonDistributions.SmallUniformRandom);

            Assert.IsTrue(network.Neurons[0][0].Outputs.Select(o => o.Destination).Contains(network.Neurons[1][0]));
            Assert.IsTrue(network.Neurons[0][0].Outputs.Select(o => o.Destination).Contains(network.Neurons[1][1]));
            Assert.IsTrue(network.Neurons[0][1].Outputs.Select(o => o.Destination).Contains(network.Neurons[1][0]));
            Assert.IsTrue(network.Neurons[0][1].Outputs.Select(o => o.Destination).Contains(network.Neurons[1][1]));
        }
    }
}
