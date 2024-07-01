// SPDX-License-Identifier: MIT

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components
{
    public class IntegerComponent : AbstractModelComponent<int>
    {
        #region Fields

        public int integer;

        #endregion

        #region Methods

        public override void Import(int integer, ModelImporter importer)
        {
            gameObject.name = integer.ToString("x8");
            this.integer = integer;
        }

        public override int Export(ModelExporter exporter) =>
            integer;

        #endregion
    }
}
