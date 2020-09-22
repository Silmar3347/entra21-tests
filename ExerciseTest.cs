using System;
using System.Collections.Generic;
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

        [Fact]
        
        public void Should_return_numbers_from_1_to_200()
        {
            var exercises = new Exercises();

            var result = exercises.Exercise3();

            var expectedOutput = new int[]
            {
                1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,53,55,57,59,61,63,65,67,69,71,73,75,77,79,81,83,85,87,89,91,93,95,97,99,101,103,105,107,109,111,113,115,117,119,121,123,125,127,129,131,133,135,137,139,141,143,145,147,149,151,153,155,157,159,161,163,165,167,169,171,173,175,177,179,181,183,185,187,189,191,193,195,197,199
            };

            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(expectedOutput[i], result[i]);
            }
        }


        [Fact]
        public void Should_return_age_average()
        {
            var exercises = new Exercises();

            var Mylist = new List<int>(){5,15,40};

            double result = exercises.Exercise4(Mylist);

            Assert.Equal(20, result);
        }

        [Fact]
        public void Should_Return_An_Percentage_Women_Between_18_and_35_Years()
        {
            //Given
            var exercises = new Exercises();
            var womensAges = new int[5]
            {
                30,22,25,13,15
            };

            var result = exercises.Exercise5(womensAges);

            Assert.Equal(60, result);

        }

        [Theory]
        [InlineData(10,6,2,2190)]
        [InlineData(20,4.90,44,78694)]
        public void Should_Return_Money_Spent_With_Cigarretes(double cigarettesPerDay,double walletPrice, double years, double quantity)
        {
            var exercises = new Exercises();

            var result = exercises.Exercise7(cigarettesPerDay, walletPrice, years);

            Assert.Equal(quantity, result);
        }

        [Theory]
        [InlineData(6, new int[10]{6, 12, 18, 24, 30, 36, 42, 48, 54, 60})]
        [InlineData(5, new int[10]{5, 10, 15, 20, 25, 30, 35, 40, 45, 50})]
        public void should_return_the_input_multiplied_by_1_to_10(int number, int[] expectedResult)
        {
            // Dado / Setup
            var exercises = new Exercises();
            
            // Quando / Ação
            var result = exercises.Exercise17(number);

            // Deve / Asserções
            Assert.Equal(result, expectedResult);
        }


        [Fact]
        public void should_not_create_candidates_when_password_is_incorrect()
        {
            var exercises = new Exercises();
            var candidates = new List <string> {"João"};

            var created = exercises.CreateCandidate(candidates, "Incorrect");

            Assert.Null(exercises.Candidates);
            Assert.False(created);
        }

        [Fact]
        public void should_create_candidates_when_password_is_correct()
        {
        //Given
        var exercises = new Exercises();
        var candidateJose = "Jose";
        var candidates = new List <string> {candidateJose};

        //When
        var created = exercises.CreateCandidate(candidates, "Pa$$w0rd");

        //Then

        Assert.True(created);

        Assert.Equal(1, exercises.Candidates.Count);
        Assert.Equal(candidateJose, exercises.Candidates[0].name);

        }

        [Fact]
        public void should_return_same_candidates()
        {
        //Given
        var exercises = new Exercises();
        string Jose = "Jose";
        string Ana = "Ana";
        var candidates = new List <string> {Jose, Ana};
        exercises.CreateCandidate(candidates, "Pa$$w0rd");
        
        //When
        var candidateJose = exercises.GetCandidateIdByName(Jose);
        var candidateAna = exercises.GetCandidateIdByName(Ana);

        Assert.NotEqual(candidateAna, candidateJose);
        }

        [Fact]
        public void should_vote_twice_in_candidate_Jose()
        {
            // Dado / Setup
            // OBJETO exercises
            var exercises = new Exercises();
            string Jose = "Jose";
            string ana = "Ana";
            var candidates = new List<string>{Jose, ana};
            exercises.CreateCandidate(candidates, "Pa$$w0rd");
            var joseId = exercises.GetCandidateIdByName(Jose);
            var anaId = exercises.GetCandidateIdByName(ana);

            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO exercises
            exercises.Vote(joseId);
            exercises.Vote(joseId);

            // Deve / Asserções
            var candidateJose = exercises.Candidates.Find(x => x.id == joseId);
            var candidateAna = exercises.Candidates.Find(x => x.id == anaId);
            Assert.Equal(2, candidateJose.votes);
            Assert.Equal(0, candidateAna.votes);
        }

        [Fact]
        public void should_return_Ana_as_winner_when_only_Ana_receives_votes()
        {
            // Dado / Setup
            // OBJETO exercises
            var exercises = new Exercises();
            string Jose = "Jose";
            string ana = "Ana";
            var candidates = new List<string>{Jose, ana};
            exercises.CreateCandidate(candidates, "Pa$$w0rd");
            var anaId = exercises.GetCandidateIdByName(ana);
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO exercises
            exercises.Vote(anaId);
            exercises.Vote(anaId);
            var winners = exercises.GetWinners();

            // Deve / Asserções
            Assert.Equal(1, winners.Count);
            Assert.Equal(anaId, winners[0].id);
            Assert.Equal(2, winners[0].votes);
        }

        [Fact]
        public void should_return_both_candidates_when_occurs_draw()
        {
            // Dado / Setup
            // OBJETO exercises
            var exercises = new Exercises();
            string Jose = "Jose";
            string ana = "Ana";
            var candidates = new List<string>{Jose, ana};
            exercises.CreateCandidate(candidates, "Pa$$w0rd");
            var joseId = exercises.GetCandidateIdByName(Jose);
            var anaId = exercises.GetCandidateIdByName(ana);
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO exercises
            exercises.Vote(anaId);
            exercises.Vote(joseId);
            var winners = exercises.GetWinners();

            // Deve / Asserções
            var candidateJose = winners.Find(x => x.id == joseId);
            var candidateAna = winners.Find(x => x.id == anaId);
            Assert.Equal(1, candidateJose.votes);
            Assert.Equal(1, candidateAna.votes);
        }
    }
}
