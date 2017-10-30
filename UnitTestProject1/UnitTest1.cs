using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternMatch;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(true, Match.Match_1("hello", "hello"));
            Assert.AreEqual(false, Match.Match_1("helloooooo", "hello"));
            Assert.AreEqual(true, Match.Match_1("hello", "hellooo"));
        }
        [TestMethod]
        public void AdvancedTest1()
        {
            Assert.AreEqual(true, Match.Match_1("?ello", "hello"));
            Assert.AreEqual(true, Match.Match_1("?ello", "heello"));
            Assert.AreEqual(true, Match.Match_1("+ello", "hello"));
            Assert.AreEqual(true, Match.Match_1("*ello", "hello"));
            Assert.AreEqual(true, Match.Match_1("hell+", "hello"));
            Assert.AreEqual(true, Match.Match_1("hell*", "hell"));

            Assert.AreEqual(false, Match.Match_1("*ello", "helo"));
            Assert.AreEqual(false, Match.Match_1("hell+", "hell"));
            Assert.AreEqual(false, Match.Match_1("hell*", "hel"));
        }
        [TestMethod]
        public void AdvancedTest2()
        {
            Assert.AreEqual(true, Match.Match_1("hel\\*o", "hel*o"));
            Assert.AreEqual(true, Match.Match_1("hel\\+o", "hel+o"));
            Assert.AreEqual(true, Match.Match_1("hel\\?o", "hel?o"));
            Assert.AreEqual(true, Match.Match_1("hel\\\\+o", "hel\\\\ooooo"));
            Assert.AreEqual(true, Match.Match_1("hel\\\\\\*", "hel\\\\ooooo"));


            Assert.AreEqual(false, Match.Match_1("hel\\*o", "hel\\ooo"));
            Assert.AreEqual(false, Match.Match_1("hel\\?o", "heloo"));
        }
        [TestMethod]
        public void YanSunTest()
        {
            Assert.AreEqual(true, Match.Match_1("+\\\\", "aaaaa\\"));
            Assert.AreEqual(true, Match.Match_1("+\\*b", "aaaaa*b"));
            Assert.AreEqual(true, Match.Match_1("*\\*ab", "*ab"));
            Assert.AreEqual(true, Match.Match_1("*\\*ab", "a*ab"));
            Assert.AreEqual(true, Match.Match_1("a*a\\*", "abbca*"));
            Assert.AreEqual(true, Match.Match_1("a\\*", "a*"));
            Assert.AreEqual(true, Match.Match_1("?\\+", "c+"));
            //positive Tests
            //            Assert.AreEqual(true, Match.Match_1("*aa\\?", "aa?"));

        }
    }
}
