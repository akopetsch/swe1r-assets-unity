// SPDX-License-Identifier: MIT

using UnityEngine;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public interface IFlaggedNodeComponent
    {
        #region Properties

        GameObject gameObject { get; }

        #endregion

        #region Methods

        void Import(Swe1rFlaggedNode source, ModelImporter importer);
        Swe1rFlaggedNode Export(ModelExporter exporter);

        #endregion
    }
}
