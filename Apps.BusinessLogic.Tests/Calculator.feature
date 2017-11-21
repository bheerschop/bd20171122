Feature: Calculator
	As a User 
	I want to use a Calculator App 
	So that I can Add, Subtract, Multiply and Divide two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
