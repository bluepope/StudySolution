using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study01.Study
{
    class 반복문
    {
        public void Run()
        {
            /*
           //for (초기화; 조건; cycle 실행)
           for (int i=0; i < 10; i++) // i++ ==     i = i + 1;
           {
               Console.WriteLine($"Hello World {i}");

               //continue; //다음 루틴으로 건너뜀
               //break; //이 반복문을 중지하겠다
           }
           */

            /*
            int j = 0;
            while (j < 10)
            {
                Console.WriteLine($"Hello World {j}");
                j++;
            }
            */

            string[] stringArr = new string[] { "bluepope", "ChoiSuHyuk", "Donn", "joo" };
            /*
            for (int i = 0; i < stringArr.Length; i++) // i++ ==     i = i + 1;
            {
                string userName = stringArr[i];

                Console.WriteLine(userName);
            }
            */
            foreach (string userName in stringArr)
            {
                Console.WriteLine(userName);
            }
        }
    }
}
