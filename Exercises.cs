using System;
using System.Collections.Generic;
using System.Linq;


namespace entra21_tests
{
    class Exercises
    {
        public int Exercise2()
        {


            var sum = 0;

            for (int i = 1; i < 101; i++)
            {
                //sum = 1
                //sum = 3
                sum += i;
            }
            return sum;
        }

        public int[] Exercise3()
        {

            var numbers = new int[100];
            var count = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = count;
                count += 2;
            }

            return numbers;
        }

        public double Exercise4(List<int> ages)
        {
            double sum = 0.0;
            var a = ages.Count;

            foreach (var item in ages)
            {
                sum += item;
            }

            var average = sum / a;

            return average;
        }

        public double Exercise5(int[] ages)
        {
            var percent = 0.0;

            foreach (var womensAge in ages)
            {
                percent = (womensAge > 17 && womensAge < 36) ? percent += 1 : percent;    
            }

            return Math.Floor((percent/ages.Length)*100);
        }

        public double Exercise7(double cigarettesPerDay, double walletPrice,  double years)
        {
            const int walletCigarettes = 20;
            var cigarettePrice = walletPrice / walletCigarettes;
            var daysSmoking = years * 365;
            return Math.Floor (daysSmoking * cigarettesPerDay * cigarettePrice);
        }

         public IEnumerable<int> Exercise17(int number)
		{
            // Imprimir a tabuada de qualquer número fornecido pelo usuário.
            // DADO que a aplicação esteja pronta, QUANDO o usuário informar um número
            // DEVE retornar a tabuada de 1 a 10

            var multiplicationTable = new List<int>(){
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

                                      //  é tipo um foreach,cada vez que
                                     // \/passa o item(que começa na posição 0)sobe 1 posição.
                                     // \/ E NAO ALTERA A LISTA (multiplicationTable)
            return multiplicationTable.Select(item => item * number);
		}


        public List <(int id, string name, int votes)> Candidates {get ; set;}

        public bool CreateCandidate(List<(int id,string name)> candidates,string password)
        {
            if(password == "Pa$$w0rd")
            {
                Candidates = candidates.Select(item => {
                    return (item.id, item.name,0);
                }).ToList();

                return true;
            }
                return false;
        }

    }

     
}       