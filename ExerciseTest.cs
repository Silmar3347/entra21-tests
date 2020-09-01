using System;
using Xunit;

namespace entra21_tests
{
    public class ExerciseTest
    {
        [Fact]
        public void Should_return_5050()
        {
            // BDD - Behavior Driven Design
            // Dado, Quando, Deve

            //dado- setup
            var exercises = new Exercises();
            
            //Ação - Quando
            var result = exercises.Exercise2();

            Assert.Equal(5050, result);
        }
    }
}
