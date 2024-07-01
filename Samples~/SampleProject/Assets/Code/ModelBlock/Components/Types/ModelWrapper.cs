// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using SWE1R.Assets.Blocks.Unity.ModelBlock.ScriptableObjects;
using Swe1rMappingChild = SWE1R.Assets.Blocks.ModelBlock.Meshes.Behaviours.MappingChild;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Types
{
    public abstract class ModelWrapper<T> : 
        AbstractModelComponent<T>, IModelWrapper where T : Swe1rModel, new()
    {
        #region Fields

        public NodesWrapper nodesComponent;
        public DataWrapper dataComponent;
        public AnimationsWrapper animationsComponent;
        public AltNWrapper altNComponent;

        #endregion

        #region Methods (import)

        public override void Import(T source, ModelBlockItemImporter importer)
        {
            // Nodes
            nodesComponent = gameObject.AddChild().AddComponent<NodesWrapper>();
            nodesComponent.Import(source.Nodes, importer);
            
            // Data
            if (source.Data != null)
            {
                dataComponent = gameObject.AddChild().AddComponent<DataWrapper>();
                dataComponent.Import(source.Data, importer);
            }

            // Animations
            if (source.Animations != null)
            {
                animationsComponent = gameObject.AddChild().AddComponent<AnimationsWrapper>();
                animationsComponent.Import(source.Animations, importer);
            }

            // AltN
            if (source.AltN != null)
            {
                altNComponent = gameObject.AddChild().AddComponent<AltNWrapper>();
                altNComponent.Import(source.AltN, importer);
            }

            ImportMappingChildPostponedReferences(importer);
        }

        private void ImportMappingChildPostponedReferences(ModelBlockItemImporter importer)
        {
            foreach (Swe1rMappingChild source in importer.GetSourceObjects<Swe1rMappingChild>())
            {
                var scriptableObject = importer
                    .GetScriptableObject<MappingChildWrapper, Swe1rMappingChild>(source);
                scriptableObject.ImportFlaggedNode(source, importer);
            }
        }

        void IModelWrapper.Import(Swe1rModel model, ModelBlockItemImporter importer) =>
            Import((T)model, importer);

        #endregion

        #region Methods (export)

        public override T Export(ModelBlockItemExporter exporter) =>
            new()
            {
                Nodes = nodesComponent.Export(exporter),
                Data = dataComponent?.Export(exporter),
                Animations = animationsComponent?.Export(exporter),
                AltN = altNComponent?.Export(exporter),

                BlockItem = exporter.ModelBlockItem
            };

        Swe1rModel IModelWrapper.Export(ModelBlockItemExporter exporter) =>
            Export(exporter);

        #endregion
    }
}
