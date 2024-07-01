// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using UnityEngine;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using UnityMatrix4x4 = UnityEngine.Matrix4x4;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public abstract class FlaggedNodeComponent<T> : AbstractModelComponent<T>, IFlaggedNodeComponent 
        where T : Swe1rFlaggedNode, new()
    {
        #region Fields

        public int flags1;
        public int flags2;
        public short flags3;
        public short lightIndex;
        public int flags5;

        #endregion

        #region Methods

        public override void Import(T source, ModelBlockItemImporter importer)
        {
            flags1 = source.Flags1;
            flags2 = source.Flags2;
            flags3 = source.Flags3;
            lightIndex = source.LightIndex;
            flags5 = source.Flags5;
        }

        protected void ApplyMatrix(UnityMatrix4x4 matrix)
        {
            if (!matrix.ValidTRS())
                Debug.LogWarning("invalid RTS");
            else
            {
                //transform.localPosition = matrix.MultiplyPoint3x4(Vector3.one); // MultiplyVector?
                // TODO: Matrix application
                transform.FromMatrix(matrix);
            }
        }

        public override T Export(ModelBlockItemExporter exporter) =>
            new()
            {
                Flags1 = flags1,
                Flags2 = flags2,
                Flags3 = flags3,
                LightIndex = lightIndex,
                Flags5 = flags5
            };

        void IFlaggedNodeComponent.Import(Swe1rFlaggedNode source, ModelBlockItemImporter importer) =>
            Import((T)source, importer);

        Swe1rFlaggedNode IFlaggedNodeComponent.Export(ModelBlockItemExporter exporter) =>
            Export(exporter);

        #endregion
    }
}
