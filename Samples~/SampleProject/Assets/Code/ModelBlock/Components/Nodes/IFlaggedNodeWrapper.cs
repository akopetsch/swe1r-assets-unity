// SPDX-License-Identifier: MIT

using UnityEngine;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public interface IFlaggedNodeWrapper
    {
        #region Properties

        GameObject gameObject { get; }

        #endregion

        #region Methods

        void Import(Swe1rFlaggedNode source, ModelBlockItemImporter importer);
        Swe1rFlaggedNode Export(ModelBlockItemExporter exporter);

        #endregion
    }
}
