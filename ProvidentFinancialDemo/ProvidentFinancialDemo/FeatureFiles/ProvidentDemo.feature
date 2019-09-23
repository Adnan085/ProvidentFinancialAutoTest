Feature: ProvidentDemo
	

@verifyText
Scenario: VerifyTextPresent
	Given I navigate to provident financial website
	Then I can verify that text Representative example: £260 loan over 26 weeks. 26 payments of £15.60 per week. Rate of interest 112% p.a. fixed. Representative 535.3% APR. Total amount payable £405.60. is present
	And I click on TwentySix weeks
	Then I can verify weekly payment value is £6.00

Scenario: CompleteForm
      Given I navigate to provident financial website
	  And I click on apply now
	  And I enter date of birth greater than twenty one
	  And I enter address
	  Then I can verify that address 1 Godwin Street, BRADFORD, West Yorkshire, BD1 2SU is present
	  And I enter wrong address
	  Then I should get an error message that says Unfortunately we can’t find your address and therefore cannot continue with your loan application online. Please call 0800 056 8722 to speak to our customer services team. Open 8am - 8pm Mon-Fri / 8am - 5pm Sat.



	
	
