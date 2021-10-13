using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study01.Study
{
    class 구구단
    {
        public void Run()
        {
            //구구단 for통해서 구구단을 만들어보자

            /*
             i x j = i*j
             2 x 1 = 2
             2 x 2 = 4
             ~~~~
             */

            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine($"{i} x {j} = {i * j}");
                }
            }
        }
    }

}
