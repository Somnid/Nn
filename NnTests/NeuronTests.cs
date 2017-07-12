using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nn;

namespace NnTests
{
    [TestClass]
    public class NeuronTests
    {
        [TestMethod]
        public void Should_propogate_acitivation_energy()
        {
            var NeuronA = new Neuron();
            var NeuronB = new Neuron();

            NeuronA.Connect(NeuronB, 2.0);

            NeuronA.Activate(2);

            Assert.AreEqual(NeuronB.ActivatedValue, 4.0);
        }

        [TestMethod]
        public void Should_chain_propogate_acitivation_energy()
        {
            var NeuronA = new Neuron();
            var NeuronB = new Neuron();
            var NeuronC = new Neuron();

            NeuronA.Connect(NeuronB, 2.0);
            NeuronB.Connect(NeuronC, 1.25);

            NeuronA.Activate(2);

            Assert.AreEqual(NeuronC.ActivatedValue, 5.0);
        }

        [TestMethod]
        public void Should_stack_propogate_acitivation_energy()
        {
            var NeuronA = new Neuron();
            var NeuronB = new Neuron();
            var NeuronC = new Neuron();

            NeuronA.Connect(NeuronC, 2.0);
            NeuronB.Connect(NeuronC, 3.0);

            NeuronA.Activate(2);
            NeuronB.Activate(1);

            Assert.AreEqual(NeuronC.ActivatedValue, 7.0);
        }
    }
}
