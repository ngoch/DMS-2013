using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using DMS.Domain.Fuzzy.Aggregation;
using DMS.Domain;

namespace DMS.Fuzzy.Test
{
    [TestClass]
    public class AggregationUnitTest
    {
        [TestMethod]
        public void TestMin()
        {

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateSimpleAggregation(AggregationType.MIN);

            //Test Values
            List<decimal> values = new List<decimal>() { 1.0M, 0.6M, 0.5M, 0.3M };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(0.3M, result);
        }

        [TestMethod]
        public void TestMax()
        {

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateSimpleAggregation(AggregationType.MAX);

            //Test Values
            List<decimal> values = new List<decimal>() { 1.0M, 0.6M, 0.5M, 0.3M };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(1.0M, result);
        }

        [TestMethod]
        public void TestAverage()
        {

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateSimpleAggregation(AggregationType.AVERAGE);

            //Test Values
            List<decimal> values = new List<decimal>() { 1.0M, 0.6M, 0.5M, 0.3M };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(0.6M, result);
        }

        [TestMethod]
        public void TestOWA()
        {
            //Test weights
            List<decimal> weights = new List<decimal>() { 0.2M, 0.3M, 0.1M, 0.4M };

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateWeightAggregation(AggregationType.OWA, weights);

            //Test Values
            List<decimal> values = new List<decimal>() { 1.0M, 0.6M, 0.5M, 0.3M };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(0.55M, result);
        }


        [TestMethod]
        public void TestPOWA()
        {
            //Test weights
            List<decimal> weights = new List<decimal>() { 0.2M, 0.2M, 0.2M, 0.4M };

            List<decimal> p = new List<decimal>() { 0.4M, 0.2M, 0.3M, 0.1M };

            decimal beta = 0.5M;

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateParamAggregation(AggregationType.POWA, weights, p, beta);

            //Test Values
            List<decimal> values = new List<decimal>() { 20, 40, 50, 30 };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(33M, Math.Round(result, 1));
        }

        [TestMethod]
        public void TestGOWA()
        {
            //Test weights
            List<decimal> weights = new List<decimal>() { 0.5M, 0.3M, 0.2M };

            decimal param = 2;

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateParamAggregation(AggregationType.GOWA, weights, param);

            //Test Values
            List<decimal> values = new List<decimal>() { 0.6M, 0.45M, 0.5M };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(0.5436M, Math.Round(result, 4));
        }

        [TestMethod]
        public void TestOWG()
        {
            //Test weights
            List<decimal> weights = new List<decimal>() { 0.5M, 0.5M, 0, 0 };

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateWeightAggregation(AggregationType.OWG, weights);

            //Test Values
            List<decimal> values = new List<decimal>() { 1, 1, 1, 1 };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(4M, result);
        }

        [TestMethod]
        public void TestIOWA()
        {
            //Test weights
            List<decimal> weights = new List<decimal>() { 0.4M, 0.3M, 0.2M, 0.1M };

            List<decimal> rating = new List<decimal>() { 0.5M, 0.5M, 0.2M, 0.7M };

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateParamAggregation(AggregationType.IOWA, weights, rating);

            //Test Values
            List<decimal> values = new List<decimal>() { 0.8M, 0.2M, 0.9M, 0.9M };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(0.7M, Math.Round(result, 1));
        }

        [TestMethod]
        public void TestIGOWA()
        {
            //Test weights
            List<decimal> weights = new List<decimal>() { 0.2M, 0.2M, 0.3M, 0.3M };

            List<decimal> rating = new List<decimal>() { 7, 2, 10, 3 };

            decimal alfa = 1;

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateParamAggregation(AggregationType.IGOWA, weights, rating, alfa);

            //Test Values
            List<decimal> values = new List<decimal>() { 25, 40, 20, 60 };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(39, Math.Round(result, 1));
        }

        [TestMethod]
        public void TestIOWG()
        {
            //Test weights           
            List<decimal> weights = new List<decimal>() { 0.5M, 0.5M, 0, 0 };

            List<decimal> rating = new List<decimal>() { 7, 2, 10, 3 };

            //Create Aggregation
            IAggregation aggregation = AggregationFactory.CreateParamAggregation(AggregationType.IOWG, weights, rating);

            //Test Values
            List<decimal> values = new List<decimal>() { 1, 1, 1, 1 };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(4M, result);
        }

        [TestMethod]
        public void TestUtil()
        {

            List<int> testData = new List<int>();
            testData.Add(1);
            testData.Add(2);
            testData.Add(3);

            AggrerationUtil fu = new AggrerationUtil();

            IEnumerable<IEnumerable<int>> result = fu.Permutation<int>(testData);

            Trace.WriteLine(result);

        }

        [TestMethod]
        public void TestASPOWA()
        {
            //Test weights
            List<decimal> weights = new List<decimal>() { 0.5M, 0.3M, 0.2M };

            List<decimal> p = new List<decimal>() { 0.7M, 1M, 0.5M };

            decimal beta = 0.3M;

            //Create Aggregationk
            IAggregation aggregation = AggregationFactory.CreateParamAggregation(AggregationType.ASPOWA_MIN, weights, p, beta);

            //Test Values
            List<decimal> values = new List<decimal>() { 70M, 50M, 60M };

            decimal result = aggregation.Calc(values);

            Assert.AreEqual(53.90M, result);
        }
    }
}
