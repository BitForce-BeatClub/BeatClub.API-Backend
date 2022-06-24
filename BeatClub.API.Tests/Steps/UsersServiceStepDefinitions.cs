using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BeatClub.API.Tests.Steps;

[Binding]
public sealed class UsersServiceStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;

    public UsersServiceStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
        // To use the multiline text or the table argument of the scenario,
        // additional string/Table parameters can be defined on the step definition
        // method. 

        _scenarioContext.Pending();
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
        // To use the multiline text or the table argument of the scenario,
        // additional string/Table parameters can be defined on the step definition
        // method. 

        _scenarioContext.Pending();
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        //TODO: implement act (action) logic

        _scenarioContext.Pending();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        //TODO: implement assert (verification) logic

        _scenarioContext.Pending();
    }

    [Given(@"the Edpoint https://localhost:(.*)/api/v(.*)/users")]
    public void GivenTheEdpointHttpsLocalhostApiVUsers(int port, int version)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveUserResource)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"A Response with Status (.*) is received")]
    public void ThenAResponseWithStatusIsReceived(int expectedStatus)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"a User Resource is included in Response Body")]
    public void ThenATutorialResourceIsIncludedInResponseBody(Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [Given(@"A User is already stored")]
    public void GivenAUserIsAlreadyStored(Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"An Error Messagewith value ""(.*)"" is returned")]
    public void ThenAnErrorMessagewithValueIsReturned(string p0)
    {
        ScenarioContext.StepIsPending();
    }
}