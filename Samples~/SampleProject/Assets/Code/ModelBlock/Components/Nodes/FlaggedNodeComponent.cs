// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using UnityEngine;
using Swe1rFlaggedNode = SWE1R.Assets.Blocks.ModelBlock.Nodes.FlaggedNode;
using UnityMatrix4x4 = UnityEngine.Matrix4x4;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Nodes
{
    public abstract class FlaggedNodeComponent : MonoBehaviour
    {
        #region Fields (serialized)

        public int flags1;
        public int flags2;
        public short flags3;
        public short lightIndex;
        public int flags5;

        #endregion

        #region Methods (import/export)

        public abstract void Import(Swe1rFlaggedNode source);

        public abstract Swe1rFlaggedNode Export(ModelExporter modelExporter);

        #endregion
    }

    public abstract class FlaggedNodeComponent<T> : FlaggedNodeComponent 
        where T : Swe1rFlaggedNode, new()
    {
        #region Methods (import)

        public override void Import(Swe1rFlaggedNode source) =>
            Import((T)source);

        public virtual void Import(T source)
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

        #endregion

        #region Methods (export)

        public override Swe1rFlaggedNode Export(ModelExporter modelExporter)
        {
            var result = new T();

            result.Flags1 = flags1;
            result.Flags2 = flags2;
            result.Flags3 = flags3;
            result.LightIndex = lightIndex;
            result.Flags5 = flags5;

            return result;
        }

        #endregion
    }
}
