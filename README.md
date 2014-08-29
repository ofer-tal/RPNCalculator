RPNCalculator
=============

Reverse Polish Notation Calculator

This solution provides an implementation of an extendible reverse polish notation calculator.
The calculator is implemented using a stack (generic c# collection of type decimal) and a set of operators. Each operator is implemented as a subclass of the abstract org.shmoop.RPNCalculator.Operators.Operator class by implementing its abstract methods.

Each operator is "registered" in the calculator class. each operator has methods to identify its triggering input token (e.g. "+" for addition) and to process the actual operator calculation.
 
Since many math operators (all of the ones implemented in this solution) are binary operators, a class named BinaryOperator is provided as a specialized abstract superclass of all Binary operators to facilitate the implementation of such operators and hide the stack manipulation from the implementors.

To add unary operators (e.g. sqrt, ln, sin, cos) it is recommended to implement a similar superclass for those operators.

The main functionality of the calculator is divided as follows:

RPNCalculatorExecutable - main executable entry point. contains the main input loop and handling of non-calculator commands (quit)

RPNCalculator - Class that represents the calculator. It implements a method that processes one user input (token) at a time

Operator - An abstract superclass for all available operators.
(Subclasses of Operator impement specific operations -- see each class documentation for further information)

Procedure for extending the RPNCalculator with additional operators

1. Implement a subclass of "Operator" (or BinaryOperator) and provide:

	- an implemnterion for the abstract method "bool IsTriggeringInput(string)" that identifies an input token that triggers it (e.g. "+" for an addition operator). when the triggering operator is received, the Operator's calculation method will be called

	- an implementation of the "Calculate" method that pops operands from the stack and pushes the result to the stack.

	(* for BinaryOperators, it is more convenient to extend the BinaryOperator class instead - the Calculate method in that case simply operates on the 2 operands (parameters) and returns the result)

2. Add an instance of the operator class to the static constractor of the Calculator class.



