// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.Extensions;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Behaviours;
using System.Collections.Generic;
using Swe1rAnimation = SWE1R.Assets.Blocks.ModelBlock.Animations.Animation;
using Swe1rFlaggedNodeOrInteger = SWE1R.Assets.Blocks.ModelBlock.FlaggedNodeOrInteger;
using Swe1rFlaggedNodeOrLodSelectorNodeChildReference = SWE1R.Assets.Blocks.ModelBlock.FlaggedNodeOrLodSelectorNodeChildReference;
using Swe1rHeaderData = SWE1R.Assets.Blocks.ModelBlock.HeaderData;
using Swe1rModel = SWE1R.Assets.Blocks.ModelBlock.Model;
using Swe1rTriggerDescription = SWE1R.Assets.Blocks.ModelBlock.Behaviours.TriggerDescription;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Types
{
    public abstract class ModelWrapper<T> : 
        ModelMonoBehaviourWrapper<T>, IModelWrapper where T : Swe1rModel, new()
    {
        #region Fields

        public NodesWrapper nodesComponent;
        public HeaderDataWrapper dataComponent;
        public AnimationsWrapper animationsComponent;
        public AltNWrapper altNComponent;

        #endregion

        #region Methods (import)

        public override void Import(T source, ModelBlockItemImporter importer)
        {
            nodesComponent = ImportProperty<List<Swe1rFlaggedNodeOrInteger>, NodesWrapper>(source.Nodes, importer);
            
            if (source.Data != null)
                dataComponent = ImportProperty<Swe1rHeaderData, HeaderDataWrapper>(source.Data, importer);
            if (source.Animations != null)
                animationsComponent = ImportProperty<List<Swe1rAnimation>, AnimationsWrapper>(source.Animations, importer);
            if (source.AltN != null)
                altNComponent = ImportProperty<List<Swe1rFlaggedNodeOrLodSelectorNodeChildReference>, AltNWrapper>(source.AltN, importer);
            
            ImportTriggerDescriptionPostponedReferences(importer);
        }

        private TWrapper ImportProperty<TSource, TWrapper>(TSource source, ModelBlockItemImporter importer)
            where TWrapper : ModelMonoBehaviourWrapper<TSource>
        {
            var result = gameObject.AddChild().AddComponent<TWrapper>();
            result.Import(source, importer);
            return result;
        }

        private void ImportTriggerDescriptionPostponedReferences(ModelBlockItemImporter importer)
        {
            foreach (Swe1rTriggerDescription source in importer.GetSourceObjects<Swe1rTriggerDescription>())
            {
                var scriptableObject = importer
                    .GetScriptableObject<TriggerDescriptionWrapper, Swe1rTriggerDescription>(source);
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
