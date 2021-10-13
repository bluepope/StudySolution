using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study01.Study
{
    class IfAndSwitch
    {
        public void Test()
        {
            bool bananaWinFlag = false;

            int bananaWidth = 15;
            int appleWidth = 10;

            //if 조건문 (AND 조건 &&) (OR 조건 ||)
            if (bananaWidth > appleWidth ) //바나나의 크기가 사과보다 크다면
            {
                bananaWinFlag = true;
            }
            else if (bananaWidth == appleWidth) //바나나의 크기가 사과와 같다면
            {

            }
            else //그게 아니라면
            {
              
            }

            //삼항 연산자                조건           ? 참일경우 : 거짓일 경우
            bananaWinFlag = (bananaWidth > appleWidth) ? true :
                (bananaWidth == appleWidth) ? false
                : false;


            string bananaType = "델몬트";

            //switch case
            switch (bananaType)
            {
                case "델몬트2": //or 조건이라고 생각해도 될듯
                case "델몬트":
                    bananaWinFlag = true;
                    break;
                case "돌":
                    bananaWinFlag = false;
                    break;
                default: //위에 case 에 해당되지 않는 경우
                    //바나나가 뭔지 모르겠다
                    break;
            }

            if (bananaType == "델몬트2" || bananaType == "델몬트")
            {
                bananaWinFlag = true;
            }
            else if (bananaType == "돌" || bananaWidth > 15) // 이런 경우에는 switch로는 구현이 안됨
            {
                bananaWinFlag = false;
            }
            else
            {
                //바나나가 뭔지 모르겠다
            }
        }
    }
}
