// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using Swe1rTransformedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.TransformedNode;
using UnityMatrix4x4 = UnityEngine.Matrix4x4;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public class TransformedNodeComponent : FlaggedNodeComponent<Swe1rTransformedNode>
    {
        #region Fields

        public UnityMatrix4x4 swe1rTransform;

        #endregion

        #region Methods

        public override void Import(Swe1rTransformedNode source, ModelBlockItemImporter importer)
        {
            base.Import(source, importer);
            swe1rTransform = source.Transform.ToUnity();
            ApplyMatrix(swe1rTransform);
        }

        public override Swe1rTransformedNode Export(ModelBlockItemExporter exporter)
        {
            var result = base.Export(exporter);
            result.Transform = swe1rTransform.ToSwe1r();
            return result;
        }

        #endregion
    }
}
