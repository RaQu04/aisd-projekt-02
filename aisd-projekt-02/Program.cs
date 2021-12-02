using System;
using System.Collections;
using System.Numerics;

namespace aisd_projekt_02
{
    class Program
    {
    static ulong DivsNum;
    static ArrayList arrayList = new ArrayList();

       
        static bool AlgorytmPrzykładowy(BigInteger Num)
        {
            DivsNum = 1; //ustawiamy wartość jeden, ponieważ jedna operacja zostanie wykonana w linii 18
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    DivsNum++;
                    if (Num % u == 0) return false;
                }
            return true;
        }
        static bool AlgorytmPrzyzwoity(BigInteger Num)
        {
            DivsNum = 1; //ustawiamy wartość jeden, ponieważ jedna operacja zostanie wykonana
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < SqrtBig(Num); u += 2)
                {
                    DivsNum++;
                    if (Num % u == 0) return false;
                }
            return true;
        }

        static bool AlgorytmOptymalnyProsty(BigInteger number)
        {
            DivsNum = 0; 
            arrayList.Clear();
            sitoEratostenesa(number);
            foreach (BigInteger var in arrayList)
            {
                if (number % var == 0) return true;
                DivsNum++;
              }

            return false;
        }

      
        static ArrayList sitoEratostenesa(BigInteger gornyZakres)
        {
            fillArrayList(SqrtBig(gornyZakres), arrayList);

            for(BigInteger i = 2; i <= SqrtBig(gornyZakres); i++)
            {
                for(BigInteger j = i; j<= gornyZakres; j+=i)
                {
                    if (j != i) arrayList.Remove(j);
                }
            }

            return arrayList; 
            
        }

        private static void fillArrayList(BigInteger gornyZakres, ArrayList arrayList)
        {
            for (BigInteger i = 2; i <= gornyZakres; i++)
            {
                arrayList.Add(i);
            }
        }


        static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root*root;
            BigInteger upperBound = (root + 1)*(root + 1);

            return (n >= lowerBound && n < upperBound);
        }

        static BigInteger SqrtBig(BigInteger n)
        {

            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");

        }

        static void Main(string[] args)
        {


            BigInteger[] PrimeNums = new BigInteger[]
            { 101, 1009, 10091, 100913, 1009139, 10091401, 100914061,1009140611, 10091406133, 100914061337, 1009140613399 };
           // { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

            Console.WriteLine("Liczba\t\tPrzykładowy\tPrzyzwoity\tOptymalny");
            

            //ArrayList tmp = sitoEratostenesa(1009);

            //foreach(var value in tmp)
            //{
            //    Console.Write(value + " ");
            //}

            //AlgorytmOptymalnyProsty(1009);

            foreach (BigInteger var in PrimeNums)
            {
                AlgorytmPrzykładowy(var);
                Console.Write(var + "\t\t" + DivsNum);
                AlgorytmPrzyzwoity(var);
                Console.Write("\t\t" + DivsNum);
                AlgorytmOptymalnyProsty(var);
                Console.Write("\t\t" + DivsNum);
                Console.WriteLine();
            }

        }
    }
}
