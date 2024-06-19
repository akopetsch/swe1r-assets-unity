// SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    [Serializable]
    public abstract class GraphicsCommandObject
    {
        #region Properties

        public abstract IEnumerable<int> Indices { get; }

        #endregion

        #region Methods (import/export)

        public abstract void Import(Swe1rGraphicsCommand source, ModelImporter importer);
        public abstract Swe1rGraphicsCommand Export(ModelExporter exporter, Swe1rMesh swe1rMesh);

        #endregion
    }

    [Serializable]
    public abstract class GraphicsCommandObject<T> : GraphicsCommandObject where T : Swe1rGraphicsCommand
    {
        #region Methods (import)

        public override void Import(Swe1rGraphicsCommand source, ModelImporter importer) => 
            Import((T)source, importer);

        public abstract void Import(T source, ModelImporter modelImporter);

        #endregion
    }
}
