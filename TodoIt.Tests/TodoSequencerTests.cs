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
