using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab8_myCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab8_myCar.Tests
{
    [TestClass()]
    public class Form1Tests
    {
            [TestMethod()]
            public void LoadMyFileTest1()
            {
                Assert.AreEqual(-1, Form1.LoadMyFile("myCars.xml"));
            }

            [TestMethod()]
            public void LoadMyFileTest2()
            {
                Assert.AreEqual(-1, Form1.LoadMyFile("myCars_err1.xml"));
            }


            [TestMethod()]
            public void LoadMyFileTest6()
            {
                Assert.AreEqual(5, Form1.LoadMyFile("myCars_err5.xml"));
            }

            [TestMethod()]
            public void LoadMyFileTest7()
            {
                Assert.AreEqual(6, Form1.LoadMyFile("myCars_err6.xml"));
            }

            [TestMethod()]
            public void LoadMyFileTest8()
            {
                Assert.AreEqual(7, Form1.LoadMyFile("myCars_err7.xml"));
            }

            [TestMethod()]
            public void LoadMyFileTest9()
            {
                Assert.AreEqual(8, Form1.LoadMyFile("myCars_err8.xml"));
            }

            [TestMethod()]
            public void LoadMyFileTest10()
            {
                Assert.AreEqual(10, Form1.LoadMyFile("myCars_err9.xml"));
            }

            [TestMethod()]
            public void LoadMyFileTest11()
            {
                Assert.AreEqual(9, Form1.LoadMyFile("myCars_err9_1.xml"));
            }
    }    
}