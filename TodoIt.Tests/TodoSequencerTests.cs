using System;
using Xunit;
using TodoIt.Data;

namespace TodoIt.Tests
{
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
            int firstId = TodoSequencer.nextTodoID();

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
	    int firstId  = TodoSequencer.nextTodoID();
	    int secondId = TodoSequencer.nextTodoID();
	    int thirdId = TodoSequencer.nextPersonId();

	    //Assert
	    Assert.True(firstId != secondId);
	    Assert.True(firstId != thirdId);
	    Assert.True(secondId != thirdId);
	    Assert.True(firstId < secondId);
	    Assert.True(secondId < thirdId);
	}
    }
}
