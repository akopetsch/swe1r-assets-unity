// SPDX-License-Identifier: GPL-2.0-only

using UnityEngine;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.Components.Models.Types
{
    public interface IModelComponent
    {
        GameObject gameObject { get; }

        void Import(Swe1rModel model, ModelImporter modelImporter);
        Swe1rModel Export(ModelExporter modelExporter);
    }
}
