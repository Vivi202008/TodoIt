using System;
using Xunit;
using TodoIt.Data;

namespace TodoIt.Tests
{
    public class PersonSequencerTests
    {
	//
	// kontrollera att id från sekvensklassen börjar på 1
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

	    //Assert
	    Assert.True(firstId < secondId);
	}
    }
}