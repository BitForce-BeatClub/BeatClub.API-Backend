Feature: TrackServiceTest
	As a developer I want to add a new track through API
	In order to make it available for applications 
	
	Background: 
		Given the Endpoint https://localhost:7071/api/v1/tracks are available

@track-adding
		Scenario: Add track with unit title
			When a Post Request is sent
			| UserId | Title      | Privacy | Artist | Cover  | Source |
			| 000003 | Shake that | Public  | Eminem | Sample | Sample |
   			Then Response the status 200 is received 
   			And A track resource is included in response body
            | Id | UserId | Title      | Privacy | Artist | Cover  | Source |
            | 1  | 000003 | Shake that | Public  | Eminem | Sample | Sample |
            
@track-adding
		Scenario: Add track with existing title
		Given A track is already stored
		    | Id | UserId | Title      | Privacy | Artist | Cover  | Source |
		    | 1  | 000003 | Shake that | Public  | Eminem | Sample | Sample |
		When a Post Request is sent
		    | UserId | Title 	       | Privacy | Artist	   | Cover  | Source |
		    | 000004 | Congratulations | Public  | Post Malone | Sample | Sample |
      	Then A response with the Status 400 is received 
      	And An error message with value "track title already exist" is returned
      	