using System;
using Xunit;
using TodoIt.Data;

namespace TodoIt.Tests
{
    public class PersonSequencerTests
    {
	//
	// kontrollera att PersonSequencer när den startar alltid börjar på 1
	//
	// Todo klassens assignee är like med 0 när assignee ännu inte är tilldelad
	//
	[Fact]
	public void IdCounterWorks1()
	{
	    //Arrange
	    PersonSequencer.reset();

	    //Act
	    int firstId = PersonSequencer.nextPersonId();

	    //Assert
	    Assert.True( firstId == 1);
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
	    int firstId  = PersonSequencer.nextPersonId();
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
