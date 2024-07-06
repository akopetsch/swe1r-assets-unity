// SPDX-License-Identifier: MIT

using Swe1rTriggerReference = SWE1R.Assets.Blocks.ModelBlock.Behaviours.TriggerReference;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Behaviours
{
    public class TriggerReferenceWrapper : ModelScriptableObjectWrapper<Swe1rTriggerReference>
    {
        #region Fields

        public int int_0;
        public int int_1;
        public TriggerDescriptionWrapper trigger;

        #endregion

        #region Methods

        public override void Import(Swe1rTriggerReference source, ModelBlockItemImporter importer)
        {
            int_0 = source.Int_0;
            int_1 = source.Int_1;
            if (source.Trigger != null)
                trigger = importer.GetTriggerDescriptionScriptableObject(source.Trigger);
        }

        public override Swe1rTriggerReference Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rTriggerReference();
            result.Int_0 = int_0;
            result.Int_1 = int_1;
            if (trigger != null)
                result.Trigger = exporter.GetTriggerDescription(trigger);
            return result;
        }

        #endregion
    }
}
