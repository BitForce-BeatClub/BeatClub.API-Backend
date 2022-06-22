Feature: UserServiceTests
	As a Developer
	I want to add new Tutorial through API
	In order to make it available for applications.
	Background: 
		Given the Edpoint https://localhost:7071/api/v1/users
		
@user-adding
Scenario: Add User with Unique nickname
	When a Post Request is sent
	| nickname | firstname | lastname | urlToImage                                                                        | typeUser |
	| kike     | enrique   | postigo  | https://www.adslzone.net/app/uploads-adslzone.net/2019/04/borrar-fondo-imagen.jpg | Artist |
    Then A Response with Status 200 is received
    And a User Resource is included in Response Body
     | id | nickname | firstname | lastname | urlToImage                                                                        | typeUser |
     |  1 | kike     | enrique   | postigo  | https://www.adslzone.net/app/uploads-adslzone.net/2019/04/borrar-fondo-imagen.jpg | Artist   |
@user-adding
Scenario: Add User with existing nickname
	Given A User is already stored
	  | id | nickname | firstname | lastname | urlToImage                                                                        | typeUser |
	  |  1 | kike     | enrique   | postigo  | https://www.adslzone.net/app/uploads-adslzone.net/2019/04/borrar-fondo-imagen.jpg | Artist   |
    When a Post Request is sent
     | nickname | firstname | lastname | urlToImage                                                                        | typeUser |
     | kike     | julio     | cesar    | https://www.adslzone.net/app/uploads-adslzone.net/2019/04/borrar-fondo-imagen.jpg | Artist   |	
     Then A Response with Status 400 is received
     And An Error Messagewith value "User nickname already exists." is returned
