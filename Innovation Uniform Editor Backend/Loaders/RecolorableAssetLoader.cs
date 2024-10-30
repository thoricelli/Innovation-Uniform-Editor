using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public abstract class RecolorableAssetLoader<TType, TId> : Loader<TType, TId> where TType : IIdentifier<TId>
    {
        public RecolorableAssetLoader(string path) : base(path)
        {
        }

        public override void Load()
        {
            base.Load();

            /*
            Structure of a recolorable item (for now just a the logos):
            - Folder with Id
              * Inside folder: Overlay, Selection_Template, Selection_Template_Secondary, Selection_Template_3, ...
             */

            
        }
    }
}
