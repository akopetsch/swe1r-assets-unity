// SPDX-License-Identifier: MIT

namespace SWE1R.Assets.Blocks.Unity.ModelBlock
{
    public class IntegerWrapper : AbstractModelComponent<int>
    {
        #region Fields

        public int integer;

        #endregion

        #region Methods

        public override void Import(int integer, ModelBlockItemImporter importer)
        {
            gameObject.name = integer.ToString("x8");
            this.integer = integer;
        }

        public override int Export(ModelBlockItemExporter exporter) =>
            integer;

        #endregion
    }
}
