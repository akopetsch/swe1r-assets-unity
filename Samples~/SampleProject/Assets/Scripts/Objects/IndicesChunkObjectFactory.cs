﻿// SPDX-License-Identifier: GPL-2.0-only

using SWE1R.Assets.Blocks.ModelBlock.Meshes.VertexIndices;
using System;
using System.Collections.Generic;

namespace SWE1R.Assets.Blocks.Unity.Objects
{
    public class IndicesChunkObjectFactory
    {
        public static IndicesChunkObjectFactory Instance { get; } = new IndicesChunkObjectFactory();
        private IndicesChunkObjectFactory() { }

        private readonly
            Dictionary<byte, Type> typeByFlag =
            new Dictionary<byte, Type>()
        {
            { 01, typeof(IndicesChunk01Object) },
            { 03, typeof(IndicesChunk03Object) },
            { 05, typeof(IndicesChunk05Object) },
            { 06, typeof(IndicesChunk06Object) },
        };

        public IndicesChunkObject CreateIndicesChunkObject(IndicesChunk indicesChunk, ModelImporter modelImporter)
        {
            var indicesChunkObject = (IndicesChunkObject)Activator.CreateInstance(typeByFlag[indicesChunk.Tag]);
            indicesChunkObject.Import(indicesChunk, modelImporter);
            return indicesChunkObject;
        }
    }
}
