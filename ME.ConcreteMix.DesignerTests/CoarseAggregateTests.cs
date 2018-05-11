using Microsoft.VisualStudio.TestTools.UnitTesting;
using ME.ConcreteMix.Designer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer.Tests
{
    [TestClass()]
    public class CoarseAggregateTests
    {
        [TestMethod()]
        public void CalculateCoarseAggVolTest()
        {
            double result = CoarseAggregateMaterial.CalculateCoarseAggVol(NominalAggregateSize.Size19, 2.7);
            Assert.IsTrue(result == 0.63);
            result = CoarseAggregateMaterial.CalculateCoarseAggVol(NominalAggregateSize.Size37_5, 2.8);
            Assert.IsTrue(result == 0.71);
        }
    }
}