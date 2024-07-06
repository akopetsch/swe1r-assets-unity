// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Nodes;
using Swe1rTriggerDescription = SWE1R.Assets.Blocks.ModelBlock.Behaviours.TriggerDescription;
using Swe1rTriggerType = SWE1R.Assets.Blocks.ModelBlock.Behaviours.TriggerType;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Behaviours
{
    public class TriggerDescriptionWrapper : ModelScriptableObjectWrapper<Swe1rTriggerDescription>
    {
        #region Fields

        public UnityVector3 center;
        public UnityVector3 direction;
        public short word_18;
        public byte byte_1a;
        public byte byte_1b;
        public short word_1c;
        public byte byte_1e;
        public byte byte_1f;
        public IFlaggedNodeWrapper affectedNode;
        public Swe1rTriggerType triggerType;
        public short word_26;
        public TriggerDescriptionWrapper next;

        #endregion

        #region Methods

        public override void Import(Swe1rTriggerDescription source, ModelBlockItemImporter importer)
        {
            center = source.Center.ToUnityVector3();
            direction = source.Direction.ToUnityVector3();
            word_18 = source.Word_18;
            byte_1a = source.Byte_1a;
            byte_1b = source.Byte_1b;
            word_1c = source.Word_1c;
            byte_1e = source.Byte_1e;
            byte_1f = source.Byte_1f;
            triggerType = source.TriggerType;
            word_26 = source.Word_26;
            if (source.Next != null)
                next = importer.GetTriggerDescriptionScriptableObject(source.Next);
        }

        public void ImportFlaggedNode(Swe1rTriggerDescription source, ModelBlockItemImporter importer)
        {
            if (source.AffectedNode != null)
                affectedNode = importer.GetFlaggedNodeComponent<IFlaggedNodeWrapper>(
                    source.AffectedNode);
        }

        public override Swe1rTriggerDescription Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rTriggerDescription();
            result.Center = center.ToSwe1rVector3Single();
            result.Direction = direction.ToSwe1rVector3Single();
            result.Word_18 = word_18;
            result.Byte_1a = byte_1a;
            result.Byte_1b = byte_1b;
            result.Word_1c = word_1c;
            result.Byte_1e = byte_1e;
            result.Byte_1f = byte_1f;
            if (affectedNode != null)
                result.AffectedNode = exporter.GetFlaggedNode(affectedNode.gameObject);
            result.TriggerType = triggerType;
            result.Word_26 = word_26;
            if (next != null)
                result.Next = exporter.GetTriggerDescription(next);
            return result;
        }

        #endregion
    }
}
