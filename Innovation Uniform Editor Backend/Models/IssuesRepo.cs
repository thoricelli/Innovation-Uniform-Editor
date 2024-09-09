using Innovation_Uniform_Editor_Backend.Models.Enums;
using System.Collections.Generic;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public static class IssuesRepo
    {
        private static Dictionary<Code, string> Issues = new Dictionary<Code, string>() {
            { Code.DL_11_NEON, "The custom is too neon." },
            { Code.DL_11_DARK, "The custom is too dark." },
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
