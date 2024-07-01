// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using SWE1R.Assets.Blocks.Unity.ModelBlock.ScriptableObjects;
using Swe1rMappingChild = SWE1R.Assets.Blocks.ModelBlock.Meshes.Behaviours.MappingChild;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Components.Types
{
    public abstract class ModelComponent<T> : 
        AbstractModelComponent<T>, IModelComponent where T : Swe1rModel, new()
    {
        #region Fields

        public NodesComponent nodesComponent;
        public DataComponent dataComponent;
        public AnimationsComponent animationsComponent;
        public AltNComponent altNComponent;

        #endregion

        #region Methods (import)

        public override void Import(T source, ModelBlockItemImporter importer)
        {
            // Nodes
            nodesComponent = gameObject.AddChild().AddComponent<NodesComponent>();
            nodesComponent.Import(source.Nodes, importer);
            
            // Data
            if (source.Data != null)
            {
                dataComponent = gameObject.AddChild().AddComponent<DataComponent>();
                dataComponent.Import(source.Data, importer);
            }

            // Animations
            if (source.Animations != null)
            {
                animationsComponent = gameObject.AddChild().AddComponent<AnimationsComponent>();
                animationsComponent.Import(source.Animations, importer);
            }

            // AltN
            if (source.AltN != null)
            {
                altNComponent = gameObject.AddChild().AddComponent<AltNComponent>();
                altNComponent.Import(source.AltN, importer);
            }

            ImportMappingChildPostponedReferences(importer);
        }

        private void ImportMappingChildPostponedReferences(ModelBlockItemImporter importer)
        {
            foreach (Swe1rMappingChild source in importer.GetSourceObjects<Swe1rMappingChild>())
            {
                var scriptableObject = importer
                    .GetScriptableObject<MappingChildScriptableObject, Swe1rMappingChild>(source);
                scriptableObject.ImportFlaggedNode(source, importer);
            }
        }

        void IModelComponent.Import(Swe1rModel model, ModelBlockItemImporter importer) =>
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

        Swe1rModel IModelComponent.Export(ModelBlockItemExporter exporter) =>
            Export(exporter);

        #endregion
    }
}
