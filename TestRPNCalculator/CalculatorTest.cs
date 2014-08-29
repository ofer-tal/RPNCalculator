using org.shmoop.RPNCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestRPNCalculator
{    
    /**
     * @class CalculatorTest        A test class for RPNCalculator
     * 
     * @author      Ofer Tal
     **/    
    [TestClass()]
    public class CalculatorTest
    {
        /**
         * Test a single addition sequence
         **/
        [TestMethod()]
        public void TestSingleAdditionSequence()
        {
            Calculator target = new Calculator();
            string input;
            string expected;
            string actual;

            // input: 5 - expected output: 5 (echo). stack content: [ 5 ] 
            input = "5"; expected = "5";           
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: 8 - expected output: 8 (echo). stack content: [ 8 , 5 ] 
            input = "8"; expected = "8";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: + - expected output: 7 (5 + 2). stack content: [ 7 ] 
            input = "+"; expected = "13";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);
        }

        /**
         * Test Multiplication and addition sequence (with negative numbers)
         **/
        [TestMethod()]
        public void TestMultiplicationAndAdditionSequence()
        {
            Calculator target = new Calculator();
            string input;
            string expected;
            string actual;

            // input: -3 - expected output: -3 (echo). stack content: [ -3 ] 
            input = "-3"; expected = "-3";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: -2 - expected output: -2 (echo). stack content: [ -2 , -3 ] 
            input = "-2"; expected = "-2";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: * - expected output: 6 (-2 * -3). stack content: [ 6 ] 
            input = "*"; expected = "6";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: 5 - expected output: 5 (echo). stack content: [ 5 , 6 ] 
            input = "5"; expected = "5";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: + - expected output: 11 (6 + 5). stack content: [ 11 ] 
            input = "+"; expected = "11";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);
        }

        /**
         * Test all operator sequence
         **/
        [TestMethod()]
        public void TestAllOperatorSequence()
        {
            Calculator target = new Calculator();
            string input;
            string expected;
            string actual;

            // input: 5 - expected output: 5 (echo). stack content: [ 5 ] 
            input = "5"; expected = "5";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: 7 - expected output: 7 (echo). stack content: [ 7 , 5 ] 
            input = "7"; expected = "7";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: 2 - expected output: 2 (echo). stack content: [ 2 , 7 , 5 ] 
            input = "2"; expected = "2";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);
            
            // input: / - expected output: 3.5 (7 / 2). stack content: [ 3.5 , 5 ] 
            input = "/"; expected = "3.5";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: - - expected output: 1.5 (5 - 3.5). stack content: [ 1.5 ] 
            input = "-"; expected = "1.5";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: -0.25 - expected output: -0.25 (echo). stack content: [ -0.25 1.5 ] 
            input = "-0.25"; expected = "-0.25";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: * - expected output: -0.375 (1.5 * -0.25). stack content: [ -0.375 ] 
            input = "*"; expected = "-0.375";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: 12 - expected output: 12 (echo). stack content: [ 12 , -0.375 ] 
            input = "12"; expected = "12";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: + - expected output: 11.625 (-0.375 + 12). stack content: [ 11.625 ] 
            input = "+"; expected = "11.625";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);
        }

        /**
         * Test all operator sequence
         **/
        [TestMethod()]
        public void TestErrorCasesSequence()
        {
            Calculator target = new Calculator();
            string input;
            string expected;
            string actual;

            // input: * - expected output: Exception with message "A binary operator requires at least 2 numbers in the stack". stack content: [ ] 
            input = "*"; expected = "A binary operator requires at least 2 numbers in the stack";
            try
            {
                actual = target.ProcessUserInput(input);
            }
            catch (InvalidOperationException e)
            {
                actual = e.Message;
            }
            Assert.AreEqual(expected, actual);

            // input: 5 - expected output: 5 (echo). stack content: [ 5 ] 
            input = "5"; expected = "5";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: + - expected output: Exception with message "A binary operator requires at least 2 numbers in the stack". stack content: [ 5 ] 
            input = "+"; expected = "A binary operator requires at least 2 numbers in the stack";
            try
            {
                actual = target.ProcessUserInput(input);
            }
            catch (InvalidOperationException e)
            {
                actual = e.Message;
            }
            Assert.AreEqual(expected, actual);

            // input: 0 - expected output: 0 (echo). stack content: [ 0 , 5 ] 
            input = "0"; expected = "0";
            actual = target.ProcessUserInput(input);
            Assert.AreEqual(expected, actual);

            // input: / - expected output: Exception with message "Arithmetic error: Division by zero". stack content: [ 0 , 5 ] 
            input = "/"; expected = "Arithmetic error: Division by zero";
            try
            {
                actual = target.ProcessUserInput(input);
            }
            catch (InvalidOperationException e)
            {
                actual = e.Message;
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
