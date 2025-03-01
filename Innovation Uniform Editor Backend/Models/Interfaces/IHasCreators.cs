using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models.Interfaces
{
    public interface IHasCreators
    {
        int[] CreatorIds { get; set; }
        List<Creator> Creators { get; }
    }
}
