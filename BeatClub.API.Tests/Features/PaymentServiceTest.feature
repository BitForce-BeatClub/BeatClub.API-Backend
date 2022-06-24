Feature: PaymentServiceTests
  As a User
  I want to pay for a membership
  In order to make it available for applications.
  Background: 
  	Given the Endpoint https://localhost:7071/api/v1/payments


@payment-adding
Scenario: Add payment with unique source and unique title
	When a Post Payment Request is sent

	| Description      | PayMethod  | Amount | CreateAt   | UserId | User   |
	| Bank transaction | Debit Card | $20    | 18/05/2022 | 19     | Miguel |	
 
    Then a Response with Status 200 is received
    And a Payment Resource is included in Response Body
    
    | id | Description      | PayMethod  | Amount | CreateAt   | UserId | User   |
    | 3  | Bank transaction | Debit Card | $20    | 18/05/2022 | 19     | Miguel |	
    
@payment-adding
Scenario: Add payment with existing source
	Given a Payment is already stored
	  | id | Description      | PayMethod  | Amount | CreateAt   | UserId | User   |
	  | 3  | Bank transaction | Debit Card | $20    | 18/05/2022 | 19     | Miguel |	
    When a Post Payment Request is sent
      | Description      | PayMethod   | Amount | CreateAt   | UserId | User   |
      | Bank transaction | Credit Card | $10    | 02/02/2023 | 45     | Manuel |	
      Then A Response with Status 400 is received
      And An Error Messagewith value "Payment source already exists" is returned
@payment-adding
      Scenario: Add a payment with existing title
      	Given a Payment is already stored
          | id | Description      | PayMethod  | Amount | CreateAt   | UserId | User   |
          | 3  | Bank transaction | Debit Card | $20    | 18/05/2022 | 19     | Miguel |	
        When a Post Request is sent
          | Description      | PayMethod  | Amount | CreateAt   | UserId | User   |
          | Bank transaction | Debit Card | $20    | 18/05/2022 | 19     | Miguel |	
          Then A Response with Status 400 is received
          And An Error Message with value "Payment title already exists" is returned
          