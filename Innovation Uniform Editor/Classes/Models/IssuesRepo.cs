using Innovation_Uniform_Editor.Classes.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Models
{
    public static class IssuesRepo
    {
        private static Dictionary<Code, string> Issues = new Dictionary<Code, string>() {
            { Code.DL_22, "Customs may not look like the Swagiform." },
            { Code.DL_81, "No more than 3 colors are allowed." },
            { Code.DL_82, "No more than 2 gradient colors are allowed." },
        };

        public static string GetIssueFromCode(Code code)
        {
            return Issues[code];
        }
    }
}
