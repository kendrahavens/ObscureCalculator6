# Generate Tests with Visual Studio

### Intro
This sample repo introduces tools in Visual Studio that can help you generate tests. **Visual Studio Enterprise is required**.

* [Generate test method stubs](https://docs.microsoft.com/visualstudio/test/create-unit-tests-menu)
* [Code coverage](https://docs.microsoft.com/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested)
* [IntelliTest](https://docs.microsoft.com/visualstudio/test/generate-unit-tests-for-your-code-with-intellitest)

### Walkthrough

#### Generate test method stubs
1. Clone repo in Visual Studio Enterprise
2. Run app - This is a simple ASP.NET website that converts useful measurements into more obscure measurement. 
3. Navigate to ConversionCalculator.cs.
4. Right-click inside the ConversionCalculator class (outside any methods or the constructor) and select **Create unit tests**
5. Rename the test project in the dialog as you see fit or select **Okay**
6. Navigate to your new test project
7. Note that the tests generated are simple stubs that map directly back to all the methods in the class it was generated from. You can also generate stubs at the method level and add them to pre-existing test projects.

#### Calculate code coverage
1. Code coverage is a helpful metric that tells you how much of your product code is tested by your tests. Code coverage is most useful for helping you understand if you are building up technical debt in the form of untested functionality.
2. In the top-level menu of Visual Studio Enterprise, select **Test** and **Analyze code coverage for all tests**.
3. Note the current percentage is 50% because test code is included in this calculation and none of your product code is yet called by tests.
4. Add the two tests below to your ConversionCalculatorTests file. (Make sure you add a using statement if needed or they are in the same namespace as the ConversionCalculator.cs)

```csharp
        [TestMethod()]
        public void ConversionCalculatorTest1()
        {
            ConversionCalculator cc = new ConversionCalculator();
            Assert.IsNotNull(cc);
        }

        [TestMethod()]
        public void CalculateFortnightTest1()
        {
            ConversionCalculator cc = new ConversionCalculator();
            Assert.AreEqual(2, cc.CalculateFortnight(28));
        }
```

5. Rerun code coverage with **Test > Analyze Code Coverage for all Tests**. Note how the percentage of coverage has increased and the product code dll (obscurecalculator6.dll) is now included in the analysis.
6. In the code coverage window you can also turn on code coverage highlighting to more easily determine what lines of your product code are tested (highlighted in blue) and what aren't (highlighted in red). Partially tested code gets a yellow highlight. Turn on highlighting with the Show Code Coverage Coloring button at the top of the Code Coverage Results window. Navigate to the ConversionCalculator.cs
7. Note the highlighting of the constructor and the CalculateFortnight method are covered by the tests you added.

#### IntelliTest
1. IntelliTest can generate fuzz tests for your code. Fuzz tests specifically look at the range of input parameters and take several possible inputs from that range and use those to generate tests. IntelliTest also specifically searches for parameters that will execute all code paths so the tests it generates executes all of your logic branches. IntelliTest will also check parameters for null values and other common exceptions.
2. In ConversionCalculator.cs, navigate to the CalculateTrust method on line 36. This method has many parameters and a few logic branches that need to be tested.
3. Right-click in the CalculateTrust method and select **Create IntelliTest**. Select **Okay** to generate a new test project.
4. Navigate to the new test project and file that you generated. IntelliTest generates a test suite and re-generates tests with each run.
5. Right-click in the generated IntelliTest file and select run IntelliTest.
6. The IntelliTest window will appear and display the generated tests, results, and exceptions it found.
7. IntelliTest has found several null reference issues, a divide by zero exception, and an overflow exception.
8. The generated IntelliTest code can be found nested under the cs file. It has the extension .g.cs to show it is generated.
9. Let's fix up our code. In the CalculcateTrust method in ConversionCalculator.cs uncomment line 40 to 47 to add in null checks and check for zero.
10. Rerun IntelliTest with right-click **Run IntelliTest**.
11. A different set of tests has now been generated. IntelliTest detected that the null reference and divide by zero cases would no longer be encountered with the new code so it cleaned up the generated tests to only what is still relevant. One null reference test is still apparent, but it passes showing this case is now handled correctly.
12. If you run code coverage again from **Test > Analyze Code Coverage for All Tests** note that the code coverage for your project as increased substantially. Note the method that we ran IntelliTest on, CalculateTrust, is now 100% code coverage.