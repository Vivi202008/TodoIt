using System;
using Xunit;
using TodoIt.Data;

namespace TodoIt.Tests
{
    //
    // med den här märkningen hindras det här testet från att köras samtidigt
    // med exv de i PeopleTests-klassen
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
    public class PersonSequencerTests
    {
	//
	// kontrollera att id från PersonSequencer när den startar alltid börjar på 1
	//
	[Fact]
	public void IdCounterWorks1()
	{
	    //Arrange
	    PersonSequencer.reset();

	    //Act
	    int firstId = PersonSequencer.nextPersonId();

	    //Assert
	    Assert.True(firstId == 1);
	}

	//
	// kontrollera att id från sekvensklassen ökar
	//
	[Fact]
	public void IdCounterWorks2()
	{
	    //Arrange
	    PersonSequencer.reset();

	    //Act
	    int firstId = PersonSequencer.nextPersonId();
	    int secondId = PersonSequencer.nextPersonId();
	    int thirdId = PersonSequencer.nextPersonId();

	    //Assert
	    Assert.True(firstId != secondId);
	    Assert.True(firstId != thirdId);
	    Assert.True(secondId != thirdId);
	    Assert.True(firstId < secondId);
	    Assert.True(secondId < thirdId);
	}
    }
}
