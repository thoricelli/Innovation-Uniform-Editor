﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models.Interfaces
{
    public interface IOverlayAssets
    {
        Guid? HolsterId { get; set; }
        Guid? ArmbandId { get; set; }
        //Shoes and gloves.
        Guid? BottomId { get; set; }
    }
}
