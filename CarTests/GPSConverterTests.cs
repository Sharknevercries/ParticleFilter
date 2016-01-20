using Microsoft.VisualStudio.TestTools.UnitTesting;
using Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Tests
{
    [TestClass()]
    public class GPSConverterTests
    {
        [TestMethod()]
        public void GetTWD97Test()
        {
            double[] ret = GPSConverter.GetTWD97(24.82831645, 121.01274986);
            double exp1 = 251288.75338373493;
            double exp2 = 2746761.884534264;
            Assert.AreEqual(exp1, ret[0]);
            Assert.AreEqual(exp2, ret[1]);
        }
    }
}