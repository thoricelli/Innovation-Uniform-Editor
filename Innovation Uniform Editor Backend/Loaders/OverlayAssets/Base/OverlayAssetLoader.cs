﻿using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Loaders.Base;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Innovation_Uniform_Editor_Backend.Loaders.OverlayAssets.Base
{
    public abstract class OverlayAssetLoader<TType> : Loader<TType, Guid> where TType : ItemBase<Guid>, IIdentifier<Guid>
    {
        private const string InfoName = "Info.json";
        protected OverlayAssetLoader(string path) : base(path)
        {
        }
        public override void Load()
        {
            base.Load();

            string infoPath = $"{_path}/{InfoName}";

            Set(JsonUtils.LoadList<TType>(infoPath));
        }
    }
}
