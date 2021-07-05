using System;
using Xunit;
using TodoIt.Data;

namespace TodoIt.Tests
{
    //
    // med den här märkningen hindras det här testet från att köras samtidigt
    // med exv de i PersonSequencerTests-klassen
    //
    // xUnit parallelliserar normalt sett körningen av test som är i placerade i olika klasser
    // så exv TodoSequencer kan köras parallellt med denna men även PeopleTests
    //
    // PeopleTests är beroende av att PersonSequencer.nextPersonId
    // alltid ger samma talföljd varje exekvering men om denna körs sam
    //
    // https://xunit.net/docs/running-tests-in-parallel
    //
    [Collection("our_test_runners")]
    public class TodoSequencerTests
    {
	//
	// kontrollera att id från TodoSequencer när den startar alltid börjar på 1
	//
	[Fact]
	public void IdCounterWorks1()
	{
	    //Arrange
	    TodoSequencer.reset();

	    //Act
	    int firstId = TodoSequencer.nextTodoId();

	    //Assert
	    Assert.True(firstId == 1);
	}

	//
	// kontrollera att id från TodoSequencer ökar
	//
	[Fact]
	public void IdCounterWorks2()
	{
	    //Arrange
	    TodoSequencer.reset();

	    //Act
	    int firstId = TodoSequencer.nextTodoId();
	    int secondId = TodoSequencer.nextTodoId();
	    int thirdId = TodoSequencer.nextTodoId();

	    //Assert
	    Assert.True(firstId != secondId);
	    Assert.True(firstId != thirdId);
	    Assert.True(secondId != thirdId);
	    Assert.True(firstId < secondId);
	    Assert.True(secondId < thirdId);
	}
    }
}
