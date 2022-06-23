Feature: PaymentServiceTests
  As a User
  I want to pay for a membership
  In order to make it available for applications.
  Background: 
  	Given the Endpoint https://localhost:7071/api/v1/payments


@payment-adding
Scenario: Add payment with unique source and unique title
	When a Post Payment Request is sent
	| title             | privacy | artist| cover                                                                       | source                                                                                                                                                         | userId |
	| Ella quiere beber | public  | Anuel | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true | 2      |
    Then a Response with Status 200 is received
    And a Payment Resource is included in Response Body
    | id | title             | privacy | artist | cover                                                                       | source                                                                                                                                                         | userId |
    |  1 | Ella quiere beber | public  | Anuel  | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true | 2      |
    
@payment-adding
Scenario: Add payment with existing source
	Given a Payment is already stored
	  | id | title             | privacy | artist | cover                                                                       | source                                                                                                                                                         | userId |
	  |  1 | Ella quiere beber | public  | Anuel  | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true | 2      |
    When a Post Payment Request is sent
      | title             | privacy | artist | cover                                                                       | source                                                                                                                                                                         | userId |
      | SlimShady         | public  | Eminem | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg         | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true         | 1      |
      Then A Response with Status 400 is received
      And An Error Messagewith value "Payment sourc already exists" is returned
@payment-adding
      Scenario: Add a payment with existing title
      	Given a Payment is already stored
          | id | title             | privacy | artist | cover                                                                       | source                                                                                                                                                         | userId |
          |  1 | Ella quiere beber | public  | Anuel  | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true | 2      |
        When a Post Request is sent
          | title             | privacy | artist | cover                                                                                              | source                                                                                                    | userId |
          | Ella quiere beber | public  | Eminem | https://www.lahiguera.net/musicalia/artistas/eminem/disco/9341/tema/19471/eminem_venom-portada.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Eminem%20-%20Venom%20(DISCOSMP3.ONLINE).mp3?raw=true | 3      |
          Then A Response with Status 400 is received
          And An Error Message with value "Payment title already exists" is returned
          