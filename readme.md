# TDD without rigorous Unit testing
In this sample I try to illustrate how to use TDD without using unit
testing (as in testing every class in isolation) as a way of testing,
but rather we can test a component with many classes and high coverage
without having to test the implementation details.

I had many debates about the validity of this approach so I tried to 
illustrate it in code so I can put the idea to test in public and 
get your feed back.

**_so if you have comments, go ahead and
[create an issue](https://github.com/Romany-Saad/calculator-csharp-tdd/issues/new) 
to discuss._**

## The why?
The motives behind this is to set our minds in a way that helps us 
deliver value, building better code and doing that while enjoying it.

The main issues with unit testing (as in testing every class in isolation): 
* It ties your tests to your implementation, making refactoring harder 
and we all know how dangerous this can become.
* unit testing (for isolated classes) doesn't add real value to if the 
system delivers what it should, but rather to how it does it, which
doesn't guarantee that you get the real benefit from tests (that your 
system does what it should).
* unit testing requires a lot of mocking which increases the effort done
by the developer and participates in disrupting the flow of thought, 
from focusing on the solution towards managing complex dependencies.

## System requirements for this example

this example simulates a calculator system that should be able to
take a string value and parse it and calculate the result.

The commits on this repo will follow these updates as if they were not 
received at the same time to show how this evolves over time.

Update #1
* support for basic operations `+`, `-`, `*`, `/`, `power`, and `rooting`.
* it should detect invalid syntax.

Update #2
* it should support combinations of basic operations

Update #3
* support for parentheses for more control over the order of execution.

Update #4 
* it should detect where the syntax error is.

Update #5
* support for more unary operations like `sqrt`, `sin`, `cos`, `tan`  

## Implementation notes

### Update #2 
this was easily done by implementing a list of delimiters (the signs for
the operations) that we use to split the given string into 2 parts
from right to left and recursively do that for the rest of the left part
solving them first and working our way backwards to calculate the whole 
equation.
