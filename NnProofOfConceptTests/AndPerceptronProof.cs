using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nn;
using System.Collections.Generic;

namespace NnProofOfConceptTests
{
    [TestClass]
    public class AndPerceptronProof
    {
        private List<Neuron> _net;
        private Neuron _nA;
        private Neuron _nB;
        private Neuron _nHidden;
        private Neuron _nOutput;

        [TestInitialize]
        public void Setup()
        {
            _net = new List<Neuron>() {
                new Neuron(),
                new Neuron(),
                new Neuron(),
                new Neuron(),
            };

            _nA = _net[0];
            _nB = _net[1];
            _nHidden = _net[2];
            _nOutput = _net[3];

            _nA.Connect(_nHidden, 1);
            _nB.Connect(_nHidden, 1);
            _nHidden.Connect(_nOutput, 1);

            _nHidden.ActivationFunction = CommonActivations.BinaryThreshold(2);
        }

        [TestMethod]
        public void Is_high_if_both_high()
        {
            _nA.Activate(1);
            _nB.Activate(1);
            Assert.AreEqual(_nOutput.ActivatedValue, 1);
        }

        [TestMethod]
        public void Is_low_if_A_is_low()
        {
            _nA.Activate(0);
            _nB.Activate(1);
            Assert.AreEqual(_nOutput.ActivatedValue, 0);
        }

        [TestMethod]
        public void Is_low_if_B_is_low()
        {
            _nA.Activate(1);
            _nB.Activate(0);
            Assert.AreEqual(_nOutput.ActivatedValue, 0);
        }

        [TestMethod]
        public void Is_low_if_both_are_low()
        {
            _nA.Activate(0);
            _nB.Activate(0);
            Assert.AreEqual(_nOutput.ActivatedValue, 0);
        }
    }
}
