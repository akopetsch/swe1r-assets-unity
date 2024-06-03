// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rN64GspCommand = SWE1R.Assets.Blocks.ModelBlock.Meshes.N64GspCommands.N64GspCommand;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public abstract class N64GspCommandObject
    {
        public abstract void Import(Swe1rN64GspCommand source, ModelImporter modelImporter);
        public abstract Swe1rN64GspCommand Export(ModelExporter modelExporter, Swe1rMesh swe1rMesh);

        public abstract IEnumerable<int> Indices { get; }
    }

    [Serializable]
    public abstract class N64GspCommandObject<T> : N64GspCommandObject where T : Swe1rN64GspCommand
    {
        public override void Import(Swe1rN64GspCommand source, ModelImporter modelImporter) => 
            Import((T)source, modelImporter);

        public abstract void Import(T source, ModelImporter modelImporter);
    }
}
