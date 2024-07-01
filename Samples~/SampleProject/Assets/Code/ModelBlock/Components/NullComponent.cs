// SPDX-License-Identifier: MIT

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class NullComponent : AbstractModelComponent<object> // TODO: <object>?
    {
        #region Methods

        public void Import() =>
            Import(null, null);

        public override void Import(object source, ModelImporter importer)
        {
            gameObject.name = "null";
            gameObject.SetActive(false);
        }

        public override object Export(ModelExporter exporter) => 
            null;

        #endregion
    }
}
