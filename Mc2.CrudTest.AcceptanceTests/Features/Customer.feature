Feature: CustomerBDD
Create , Update , Delete Customer

@create
Scenario: Input Customer Successfully in App
	Given Input Customer info
	When Customer Added to App
	Then App should be Show Customer Id

@update
Scenario: Update Existed Customer Successfully in App
	Given Input Customer Family For Find Customer
	And Input Customer new Info
	When Customer Updated to App
	Then App Should be Show Update Successful

@delete
Scenario: Delete Existed Customer Successfully from App
	Given Input Customer Name for Find Customer
	When Customer Deleted from App
	Then App should be Show Delete Successful
