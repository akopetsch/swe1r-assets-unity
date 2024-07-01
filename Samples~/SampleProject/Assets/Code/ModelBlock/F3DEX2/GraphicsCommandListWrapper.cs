// SPDX-License-Identifier: MIT

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Swe1rGraphicsCommandList = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommandList;
using Swe1rGspVertexCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GspVertexCommand;
using Swe1rVtx = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.Vtx;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2
{
    public class GraphicsCommandListWrapper : ModelObjectWrapper<Swe1rGraphicsCommandList>
    {
        #region Fields

        [SerializeReference] public List<IGraphicsCommandWrapper> commandList;

        #endregion

        #region Methods

        public override void Import(Swe1rGraphicsCommandList source, ModelBlockItemImporter importer) =>
            commandList = source.Select(x => importer.GetGraphicsCommandObject(x)).ToList();

        public override Swe1rGraphicsCommandList Export(ModelBlockItemExporter exporter)
        {
            if (commandList.Count > 0)
                return new Swe1rGraphicsCommandList(
                    commandList.Select(x => x.Export(exporter)).ToList());
            else
                return null;
        }

        public Swe1rGraphicsCommandList Export(ModelBlockItemExporter exporter, IList<Swe1rVtx> vertices)
        {
            // TODO: maybe this should be moved to the repo 'swe1r-assets'.
            Swe1rGraphicsCommandList result = Export(exporter);
            if (result != null)
                foreach (var gspVertexCommand in result.OfType<Swe1rGspVertexCommand>())
                    gspVertexCommand.Vertices = vertices;
            return result;
        }

        #endregion
    }
}
