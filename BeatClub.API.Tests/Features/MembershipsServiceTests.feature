Feature: MembershipsServiceTests
As a Developer
I want to add new Tutorial through API
In order to make it available for applications.
Background: 
	Given the Endpoint https://localhost:7071/api/v1/memberships
	
@membership-adding
	
Scenario: Add membership with unique price, title, feature and description
	When a Post Membership Request is sent
	| title | price | feature | description  | urlimage                                                                                                                                                                                                                                                                                                                                                                                                                    |
	| VIP   | $25   | For VIP | VIP benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
	Then a Response with Status 200 is received
	And a Membership Resource is included in Response Body
	| id | title | price | feature | description  | urlimage                                                                                                                                                                                                                                                                                                                                                                                                                    |
	| 4  | VIP   | $25   | For VIP | VIP benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
	@membership-adding
	Scenario: Add membership with existing title
		Given a Membership is already stored
		  | id | title | price | feature | description  | urlimage                                                                                                                                                                                                                                                                                                                                                                                                                    |
		  | 4  | VIP   | $25   | For VIP | VIP benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
		When a Post Membership Request is sent
		  | title | price | feature | description  | urlimage                                                                                                                                                                                                                                                                                                                                                                                                                    |
		  | VIP   | $32   | For VIPPP | VIPPP benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
		Then A Response with Status 400 is received
		And An Error Messagewith value "Membership title already exists" is returned
	@membership-adding
	Scenario: Add membership with existing price
		Given a Membership is already stored
		  | id | title | price | feature | description  | urlimage                                                                                                                                                                                                                                                                                                                                                                                                                    |
		  | 4  | VIP   | $25   | For VIP | VIP benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
		When a Post Membership Request is sent
		  | title   | price | feature     | description | urlimage |
		  | VIP-PRO | $25   | For VIP-PRO | VIP-PRO benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
		Then A Response with Status 400 is received
		And An Error Messagewith value "Membership price already exists" is returned
	@membership-adding
	Scenario: Add membership with existing feature
		Given a Membership is already stored
		  | id | title | price | feature | description  | urlimage                                                                                                                                                                                                                                                                                                                                                                                                                    |
		  | 4  | VIP   | $25   | For VIP | VIP benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
		When a Post Membership Request is sent
		  | title   | price | feature | description      | urlimage |
		  | VIP-PRO | $32   | For VIP | VIP-PRO benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
		Then A Response with Status 400 is received
		And An Error Messagewith value "Membership feature already exists" is returned
	@membership-adding
	Scenario: Add membership with existing description
		Given a Membership is already stored
		  | id | title | price | feature | description  | urlimage                                                                                                                                                                                                                                                                                                                                                                                                                    |
		  | 4  | VIP   | $25   | For VIP | VIP benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
		When a Post Membership Request is sent
		 | title   | price | feature     | description | urlimage |
		 | VIP-PRO | $32   | For VIP-PRO | VIP benefits | https://www.google.com/imgres?imgurl=https%3A%2F%2Fst.depositphotos.com%2F1431107%2F2548%2Fv%2F950%2Fdepositphotos_25488889-stock-illustration-vip-vector-symbol.jpg&imgrefurl=https%3A%2F%2Fsp.depositphotos.com%2Fvector-images%2Fvip-club.html&tbnid=0qavzAS7toPOUM&vet=12ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ..i&docid=ltKX09d2bJO75M&w=1024&h=1024&q=vip&ved=2ahUKEwj00O6V-b_4AhVdALkGHRajBI0QMygDegUIARDjAQ |
		Then A Response with Status 400 is received
		And An Error Messagewith value "Membership description already exists" is returned