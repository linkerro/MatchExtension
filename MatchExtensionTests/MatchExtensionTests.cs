using System;
using System.Collections.Generic;
using MatchExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MatchExtensions.MatchExtension;

namespace MatchExtensionTests
{
    [TestClass]
    public class MatchExtensionTests
    {
        [TestMethod]
        public void SimpleMatchesShouldWork()
        {
            var result = "no result";
            Match(1,new List<Case<int>>
            {
                Case<int>(x=>x==1,x=>result="we found the one"),
                Default<int>(_=>result="the default is now "+_)
            });
            Assert.AreEqual("we found the one",result);
        }

        [TestMethod]
        public void DefaultMatchShouldWork()
        {
            var result = "no result";
            Match(345, new List<Case<int>>
            {
                Case<int>(x=>x==1,x=>result="we found the one"),
                Default<int>(_=>result="the default is now "+_)
            });
            Assert.AreEqual("the default is now 345", result);
        }
    }
}
