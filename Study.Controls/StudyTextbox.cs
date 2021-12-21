using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Controls
{
    public class StudyTextbox : TextBox
    {
        /// <summary>
        /// 숨겨진 값을 활용해야할때 사용
        /// </summary>
        public string? HiddenValue { get; set; }
    }
}
