Feature: SearchAndBuy

Background: user will be on home pagw

@tag1
Scenario Outline: Search And Buy Product
	When User type '<searchtext>' in text box
	* Click On search button
	Then User will be redirected into product page
	When User click on add to cart button for products
	And Click On gotocart button
	Then User Will Be On CartPage
	When User Click On Proceed To Pay
	Then User will be On payment page
	When User Enter The Form Data with '<firstname>' ,'<lastname>' ,'<Address>' ,'<City>' ,'<Email>' , '<State>',  '<Apartment>','<Pincode>' ,'<PhoneNumber>' 
	And  Press SubmitButton
	Then User will be on Final Payment Page with Proceed Button
	Examples: 
	| searchtext | firstname | lastname | Address | City | Email              | State | Apartment | Pincode | PhoneNumber |
	| pedigree   | vysh      | kc       | kannur  | ktba | newvc123@gmail.com | KL    | 12B       | 670612  | 7907018812  |
