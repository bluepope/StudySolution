using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study01.Study
{
    class VariableInfo
    {
        public void Test()
        {
            //자료형 변수이름 = 넣을 값;

            char alpha = 'a';
            string word = "abcdef";

            byte verySmallNumber = 255; // byte.MaxValue;
            short smallNumber = 32767; // short.MaxValue;
            int number = 213123123;
            long largeNumber = long.MaxValue;

            //uint --> 부호가 없는
            //ushort
            uint number2 = uint.MaxValue;
            //ulong

            decimal veryLargeNumber = decimal.MaxValue; //가장 강력하지만 성능이 느림

            //부동소수점은 정밀도에 따라 움직이며 정확한 값이 아닌 근사치로 저장됨
            float smallDotNumber = 0.1123456F;
            double dotNumber = 0.1123456D;

            bool flag = true; //false;


            //카멜케이스 -> 낙타
            //verySmallNumber

            //네임스페이스 클래스 메소드 프로퍼티 이벤트등 파스칼케이스 --> C# 만, java, javascript, python 같은 다른 언어는 camelcase로 통일
            //VerySmallNumber -- 최초가 대문자
        }
    }
}
