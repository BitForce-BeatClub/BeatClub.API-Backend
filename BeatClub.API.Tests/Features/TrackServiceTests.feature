Feature: TrackServiceTests
  As a Developer
  I want to add new Tutorial through API
  In order to make it available for applications.
  Background: 
  	Given the Endpoint https://localhost:7071/api/v1/tracks


@track-adding
Scenario: Add track with unique source and unique title
	When a Post Track Request is sent
	| title             | privacy | artist| cover                                                                       | source                                                                                                                                                         | userId |
	| Ella quiere beber | public  | Anuel | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true | 2      |
    Then a Response with Status 200 is received
    And a Track Resource is included in Response Body
    | id | title             | privacy | artist | cover                                                                       | source                                                                                                                                                         | userId |
    |  1 | Ella quiere beber | public  | Anuel  | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true | 2      |
    
@track-adding
Scenario: Add track with existing source
	Given a Track is already stored
	  | id | title             | privacy | artist | cover                                                                       | source                                                                                                                                                         | userId |
	  |  1 | Ella quiere beber | public  | Anuel  | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true | 2      |
    When a Post Track Request is sent
      | title             | privacy | artist | cover                                                                       | source                                                                                                                                                                         | userId |
      | SlimShady         | public  | Eminem | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg         | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true         | 1      |
      Then A Response with Status 400 is received
      And An Error Messagewith value "Track sourc already exists" is returned
@track-adding
      Scenario: Add a track with existing title
      	Given a Track is already stored
          | id | title             | privacy | artist | cover                                                                       | source                                                                                                                                                         | userId |
          |  1 | Ella quiere beber | public  | Anuel  | https://cdn.themedizine.com/2018/07/Anuel-AA-Real-Hasta-La-Muerte-Album.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Anuel%20AA%20-%20Ella%20Quiere%20Beber%20(Remix)%20ft.%20Romeo%20Santos%20(DISCOSMP3.ONLINE).mp3?raw=true | 2      |
        When a Post Request is sent
          | title             | privacy | artist | cover                                                                                              | source                                                                                                    | userId |
          | Ella quiere beber | public  | Eminem | https://www.lahiguera.net/musicalia/artistas/eminem/disco/9341/tema/19471/eminem_venom-portada.jpg | https://github.com/BitForce-BeatClub/Files/blob/main/Eminem%20-%20Venom%20(DISCOSMP3.ONLINE).mp3?raw=true | 3      |
          Then A Response with Status 400 is received
          And An Error Message with value "Track title already exists" is returned
          