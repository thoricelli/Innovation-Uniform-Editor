using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Enums
{
    public enum UpdaterVersioningResult
    {
        /// <summary>
        /// Item is already up-to-date.
        /// </summary>
        NO_UPDATE_NEEDED,
        /// <summary>
        /// Item is out of date
        /// </summary>
        OUT_OF_DATE,
        /// <summary>
        /// New item is not compatible with this tool.
        /// </summary>
        NOT_COMPATIBLE,
        /// <summary>
        /// An error occured.
        /// </summary>
        SOMETHING_WENT_WRONG
    }
}
