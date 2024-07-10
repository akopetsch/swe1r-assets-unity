// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.ModelBlock.Meshes;
using SWE1R.Assets.Blocks.ModelBlock.Meshes.Geometry;
using SWE1R.Assets.Blocks.Unity.Extensions;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Behaviours;
using SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2;
using SWE1R.Assets.Blocks.Unity.ModelBlock.Materials;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Swe1rMaterialTexture = SWE1R.Assets.Blocks.ModelBlock.Materials.MaterialTexture;
using Swe1rMaterialTextureChild = SWE1R.Assets.Blocks.ModelBlock.Materials.MaterialTextureChild;
using Swe1rMesh = SWE1R.Assets.Blocks.ModelBlock.Meshes.Mesh;
using Swe1rMeshMaterialExporter = SWE1R.Assets.Blocks.ModelBlock.Materials.Export.MeshMaterialExporter;
using Swe1rModelImporter = SWE1R.Assets.Blocks.Unity.ModelBlock.ModelBlockItemImporter;
using Swe1rPrimitiveType = SWE1R.Assets.Blocks.ModelBlock.Meshes.PrimitiveType;
using UnityMaterial = UnityEngine.Material;
using UnityMesh = UnityEngine.Mesh;
using UnityTexture2D = UnityEngine.Texture2D;
using UnityVector2 = UnityEngine.Vector2;
using UnityVector3 = UnityEngine.Vector3;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.Meshes
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshCollider))]
    public class MeshWrapper : ModelMonoBehaviourWrapper<Swe1rMesh>
    {
        #region Fields

        public MeshMaterialWrapper meshMaterial;
        [SerializeReference] public BehaviourWrapper behaviour;
        public UnityVector3 bounds0;
        public UnityVector3 bounds1;
        public short facesCount;
        public Swe1rPrimitiveType primitiveType;
        [SerializeReference] public List<int> facesVertexCounts;
        public MeshGroupNodeOrShortsWrapper meshGroupOrShorts;
        [SerializeReference] public CollisionVerticesWrapper collisionVertices;
        [SerializeReference] public GraphicsCommandListWrapper commandList;
        public List<VtxWrapper> vertices;
        public short unk_Count;

        #endregion

        #region Methods (import)

        public override void Import(Swe1rMesh source, Swe1rModelImporter importer)
        {
            gameObject.name = importer.GetName(source);

            meshMaterial = importer.GetMeshMaterialScriptableObject(source.MeshMaterial);
            
            if (source.Behaviour != null)
                behaviour = importer.GetBehaviourScriptableObject(source.Behaviour);
            
            bounds0 = source.Bounds0.ToUnityVector3();
            bounds1 = source.Bounds1.ToUnityVector3();
            facesCount = source.FacesCount;
            primitiveType = source.PrimitiveType;
            
            if (source.FacesVertexCounts != null)
                facesVertexCounts = source.FacesVertexCounts;
            
            meshGroupOrShorts = new MeshGroupNodeOrShortsWrapper();
            meshGroupOrShorts.Import(source.MeshGroupNodeOrShorts, importer);

            if (source.CollisionVertices != null)
            {
                collisionVertices = new CollisionVerticesWrapper();
                collisionVertices.Import(source.CollisionVertices, importer);
            }
            if (source.CommandList != null)
            {
                commandList = new GraphicsCommandListWrapper();
                commandList.Import(source.CommandList, importer);
            }
            if (source.Vertices != null)
                vertices = source.Vertices.Select(x => importer.GetVertexObject(x)).ToList();
            
            unk_Count = source.Unk_Count;

            AddLabelsToName(source);
            UpdateVisualization(source, importer);
        }

        #endregion

        #region Methods (export)

        public override Swe1rMesh Export(ModelBlockItemExporter exporter)
        {
            var result = new Swe1rMesh();

            result.MeshMaterial = exporter.GetMeshMaterial(meshMaterial);
            if (behaviour != null)
                result.Behaviour = exporter.GetBehaviour(behaviour);
            result.Bounds0 = bounds0.ToSwe1rVector3Single();
            result.Bounds1 = bounds1.ToSwe1rVector3Single();
            result.FacesCount = facesCount;
            result.PrimitiveType = primitiveType;
            if (facesVertexCounts.Count > 0)
                result.FacesVertexCounts = facesVertexCounts;
            result.MeshGroupNodeOrShorts = meshGroupOrShorts.Export(exporter);
            if (collisionVertices?.Count > 0) // TODO: nullable necessary? ([SerializeReference])
                result.CollisionVertices = collisionVertices.Export(exporter);
            if (vertices.Count > 0)
                result.Vertices = vertices.Select(v => exporter.GetVertex(v)).ToList();
            result.CommandList = commandList.Export(exporter, result.Vertices);
            result.Unk_Count = unk_Count;

            result.UpdateCounts();

            return result;
        }

        #endregion

        #region Methods (visualization)

        private void AddLabelsToName(Swe1rMesh source)
        {
            var labels = new List<string>();

            Swe1rMaterialTexture texture = source.MeshMaterial.MaterialTexture;
            if (texture != null)
            {
                labels.Add($"fmt:{((short)texture.Format):x4}");
                labels.Add($"i:{texture.TextureIndex}");
            }
            if (source.Behaviour != null)
            {
                labels.Add("B");
                if (source.Behaviour.Subs.Any(x => x.Trigger?.AffectedNode != null))
                    labels.Add("BTFn");
            }
            if (source.CollisionVertices != null)
                labels.Add("Cv");
            if (source.CommandList != null)
                labels.Add("Ic");
            if (source.Vertices != null)
                labels.Add("Vv");
            labels.Add($"A{source.MeshMaterial.Material.AlphaBpp}");

            gameObject.name += string.Join(string.Empty, labels.Select(x => $"[{x}]"));
        }

        private void UpdateVisualization(Swe1rMesh source, Swe1rModelImporter importer)
        {
            Swe1rMaterialTextureChild firstMaterialTextureChild = source.MeshMaterial.MaterialTexture?.Children.FirstOrDefault();
            gameObject.GetComponent<MeshFilter>().sharedMesh = GetUnityVisibleMesh(source, firstMaterialTextureChild);
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = GetUnityMaterial(source, firstMaterialTextureChild, importer);
            gameObject.GetComponent<MeshCollider>().sharedMesh = GetUnityCollisionMesh(source);
        }

        private UnityMesh GetUnityVisibleMesh(Swe1rMesh source, Swe1rMaterialTextureChild sourceMaterialTextureChild)
        {
            UnityMesh unityMesh = null;
            List<Triangle> triangles = source.CommandList?.GetTriangles();
            if (triangles != null)
            {
                List<UnityVector3> unityVertices = source.Vertices
                    .Select(v => v.Ob.ToUnityVector3()).ToList();
                List<UnityVector2> unityUvs = source.Vertices
                    .Select(v => v.GetEffectiveUV(sourceMaterialTextureChild).ToUnityVector2()).ToList();
                unityMesh = new UnityMesh() {
                    vertices = unityVertices.ToArray(),
                    uv = unityUvs.ToArray(),
                    triangles = triangles.SelectMany(t => t.GetIndices()).ToArray(),
                };
                unityMesh.RecalculateNormals();
                unityMesh.RecalculateBounds();
                if (!source.MeshMaterial.HasBackfaceCulling)
                    unityMesh = unityMesh.DoubleSided();
            }
            return unityMesh;
        }

        private UnityMaterial GetUnityMaterial(Swe1rMesh source, Swe1rMaterialTextureChild sourceMaterialTextureChild, Swe1rModelImporter importer)
        {
            Shader shader;
            if (source.MeshMaterial.Material.AlphaBpp == 8)
                shader = Shader.Find("Transparent/Diffuse");
            else
                shader = Shader.Find("Standard");
            var unityMaterial = new UnityMaterial(shader);
            int? swe1rTextureIndex = source.MeshMaterial.MaterialTexture?.TextureIndex;
            if (swe1rTextureIndex.HasValue)
            {
                UnityTexture2D unityTexture = null;
                if (swe1rTextureIndex == -1)
                    unityTexture = new TestTextureHelper().LoadTexture();
                else
                {
                    var sourceMaterialExporter = new Swe1rMeshMaterialExporter(source.MeshMaterial, importer.TextureBlock);
                    sourceMaterialExporter.Export();
                    unityTexture = sourceMaterialExporter.EffectiveImage.ToUnityTexture2D();
                }
                unityMaterial.SetTexture("_MainTex", unityTexture);
                unityMaterial.SetFloat("_Glossiness", 0); // TODO: necessary for "Standard" shader but also for "Transparent/Diffuse"?
            }
            unityMaterial.name = gameObject.name;
            return unityMaterial;
        }

        private UnityMesh GetUnityCollisionMesh(Swe1rMesh source)
        {
            if (source.CollisionVerticesCount > 2)
            {
                List<UnityVector3> unityVertices =
                    source.CollisionVertices.ShortVectors?.Select(v => v.ToUnityVector3()).ToList() ??
                    source.CollisionVertices.FloatVectors.Select(v => v.ToUnityVector3()).ToList();
                if (unityVertices.Distinct().Count() <= 2)
                {
                    Debug.LogWarning("Number of distinct collision vertices not greater than 2.", this);
                    return null;
                }

                List<int> unityIndices =
                    source.GetCollisionTriangles().SelectMany(t => t.GetIndices().Reverse()).ToList();
                if (unityIndices.Any(i => i >= unityVertices.Count))
                {
                    Debug.LogWarning("Out-of-bound collision vertex indices.", this);
                    return null;
                }

                var unityMesh = new UnityMesh() {
                    vertices = unityVertices.ToArray(),
                    triangles = unityIndices.ToArray(),
                };
                unityMesh.RecalculateNormals();
                unityMesh.RecalculateBounds();
                unityMesh.name = gameObject.name;
                return unityMesh;
            }
            return null;
        }

        #endregion
    }
}
