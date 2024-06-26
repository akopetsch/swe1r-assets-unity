// SPDX-License-Identifier: MIT

using SWE1R.Assets.Blocks.Unity.ModelBlock;
using System.Collections;
using System.IO;
using System.Linq;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;
using Swe1rModelBlockItem = SWE1R.Assets.Blocks.ModelBlock.ModelBlockItem;
using Swe1rSplineBlockItem = SWE1R.Assets.Blocks.SplineBlock.SplineBlockItem;
using Swe1rSpriteBlockItem = SWE1R.Assets.Blocks.SpriteBlock.SpriteBlockItem;
using Swe1rTextureBlockItem = SWE1R.Assets.Blocks.TextureBlock.TextureBlockItem;

namespace SWE1R.Assets.Blocks.Unity.Editor
{
    public class BlockEditorWindow : EditorWindow
    {
        #region Constants

        private const string gameName = "Star Wars Episode I: Racer";
        private const string editorWindowName = "Block Editor";
        private static readonly string titleString = $"{gameName} {editorWindowName}";

        #endregion

        #region Fields

        private string blocksPath = @"C:/apps/swe1r/gog-hotfix3/data/lev01"; // TODO: configurable blocksPath

        private string modelBlockFilename = BlockDefaultFilenames.ModelBlock;
        private string textureBlockFilename = BlockDefaultFilenames.TextureBlock;
        private string splineBlockFilename = BlockDefaultFilenames.SplineBlock;
        private string spriteBlockFilename = BlockDefaultFilenames.SpriteBlock;

        private int modelIndex = 0;

        private Block<Swe1rModelBlockItem> modelBlock;
        private Block<Swe1rTextureBlockItem> textureBlock;
        private Block<Swe1rSplineBlockItem> splineBlock;
        private Block<Swe1rSpriteBlockItem> spriteBlock;

        private EditorCoroutine importAllCoroutine;

        #endregion

        #region Methods (gui)

        [MenuItem("Window/" + gameName + "/" + editorWindowName)]
        public static void Init() =>
            GetWindow<BlockEditorWindow>().titleContent = new GUIContent(titleString);

        public void OnGUI()
        {
            EditorGUILayout.Space();
            GuiDeleteAllAssets();
            EditorGUILayout.Space();
            GuiBlocksPath();
            EditorGUILayout.Space();
            GuiModelBlock();
            EditorGUILayout.Space();
            GuiTextureBlock();
            EditorGUILayout.Space();
            GuiSplineBlock();
            EditorGUILayout.Space();
            GuiSpriteBlock();
            EditorGUILayout.Space();
        }

        private void GuiDeleteAllAssets()
        {
            if (GuiButton("Delete All Assets"))
                AssetsHelper.DeleteAllAssets();
        }

        private void GuiBlocksPath()
        {
            const string label = "Blocks Path";
            EditorGUILayout.BeginHorizontal();
            blocksPath = EditorGUILayout.TextField(label, blocksPath);
            if (GuiButton("..."))
            {
                string newBlocksPath = EditorUtility.OpenFolderPanel(label, blocksPath, "");
                if (!string.IsNullOrEmpty(newBlocksPath))
                    blocksPath = newBlocksPath;
            }
            EditorGUILayout.EndHorizontal();
        }

        private void GuiModelBlock()
        {
            EditorGUILayout.LabelField("Model Block");

            // title
            modelBlockFilename = GuiFilenameField(modelBlockFilename);

            // index int field, import/export buttons
            EditorGUILayout.BeginHorizontal();
            modelIndex = GuiIntField("Index", modelIndex, 3);
            if (GuiButton("Import"))
                EditorCoroutineUtility.StartCoroutine(ImportCoroutine(modelIndex), this);
            if (GuiButton("Export"))
                EditorCoroutineUtility.StartCoroutine(ExportCoroutine(modelIndex), this);
            if (GuiButton("Export (Block)"))
                EditorCoroutineUtility.StartCoroutine(ExportToBlockCoroutine(modelIndex), this);
            if (GuiButton("Test Re-Export"))
                EditorCoroutineUtility.StartCoroutine(TestReExportCoroutine(modelIndex), this);

            EditorGUILayout.EndHorizontal();

            // import all
            EditorGUILayout.LabelField("Test Re-Export All");
            EditorGUILayout.BeginHorizontal();
            if (importAllCoroutine == null)
            {
                if (GuiButton("Start"))
                    importAllCoroutine = EditorCoroutineUtility.StartCoroutine(TestReExportAllCoroutine(), this);
            }
            else if (importAllCoroutine != null)
            {
                if (GuiButton("Stop"))
                {
                    EditorCoroutineUtility.StopCoroutine(importAllCoroutine);
                    importAllCoroutine = null;
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        private void GuiTextureBlock()
        {
            EditorGUILayout.LabelField("Texture Block");
            textureBlockFilename = GuiFilenameField(textureBlockFilename);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.EndHorizontal();
        }

        private void GuiSplineBlock()
        {
            EditorGUILayout.LabelField("Spline Block");
            splineBlockFilename = GuiFilenameField(splineBlockFilename);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.EndHorizontal();
        }

        private void GuiSpriteBlock()
        {
            EditorGUILayout.LabelField("Sprite Block");
            spriteBlockFilename = GuiFilenameField(splineBlockFilename);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.EndHorizontal();
        }

        #endregion

        #region Methods (GUI helper)

        private int GuiIntField(string label, int value, int digits)
        {
            // return EditorGUILayout.IntField(label, value);

            GUIStyle style = new(EditorStyles.numberField);
            style.stretchWidth = false;
            return EditorGUILayout.IntField(label, value, style);
        }

        private string GuiFilenameField(string filename) =>
            EditorGUILayout.TextField("Filename", filename);

        private bool GuiButton(string s)
        {
            // return GUILayout.Button(s);

            GUIContent content = new(s);

            GUIStyle style = new(GUI.skin.button);
            style.stretchWidth = false;

            Vector2 size = style.CalcSize(content);

            return GUI.Button(GUILayoutUtility.GetRect(size.x, size.y, style), content, style);
        }

        #endregion

        // TODO: use synchronous nested coroutines to re-use code
        // https://www.alanzucconi.com/2017/02/15/nested-coroutines-in-unity/

        #region Methods (import)

        private IEnumerator ImportCoroutine(int modelIndex)
        {
            ModelBlockItemImporter importer = GetModelImporter(modelIndex);
            BlockEditorLogHelper.LogImport(importer.ModelIndex); yield return null;
            ImportAndSelect(importer);
            BlockEditorLogHelper.LogImported(importer.ModelIndex); yield return null;
        }

        private void ImportAndSelect(ModelBlockItemImporter importer)
        {
            importer.Import();
            Selection.activeGameObject = importer.GameObject;
        }

        #endregion

        #region Methods (export)

        private IEnumerator ExportCoroutine(int modelIndex)
        {
            ModelBlockItemExporter exporter = GetModelExporter(modelIndex);

            BlockEditorLogHelper.LogExport(modelIndex); yield return null;
            exporter.Export();
            BlockEditorLogHelper.LogExported(modelIndex); yield return null;
        }

        private IEnumerator ExportToBlockCoroutine(int modelIndex)
        {
            ModelBlockItemExporter exporter = GetModelExporter(modelIndex);
            if (exporter != null)
            {
                BlockEditorLogHelper.LogExport(modelIndex); yield return null;
                exporter.Export();
                BlockEditorLogHelper.LogExported(modelIndex); yield return null;

                if (exporter.ModelBlockItem != null)
                {
                    BlockEditorLogHelper.LogExportToModelBlock(modelIndex); yield return null;
                    LoadBlocks(); // TODO: only load modelblock
                    modelBlock[modelIndex] = exporter.ModelBlockItem;
                    SaveBlocks(); // TODO: only save modelblock
                    BlockEditorLogHelper.LogExportedToModelBlock(modelIndex); yield return null;
                }
            }
        }

        #endregion

        #region Methods (re-export)

        private IEnumerator TestReExportCoroutine(int modelIndex)
        {
            ModelBlockItemImporter importer = GetModelImporter(modelIndex);

            BlockEditorLogHelper.LogTestReExport(modelIndex); yield return null;

            BlockEditorLogHelper.LogImport(modelIndex); yield return null;
            ImportAndSelect(importer);
            BlockEditorLogHelper.LogImported(modelIndex); yield return null;

            ModelBlockItemExporter exporter = GetModelExporter(modelIndex);
            bool successful = false;
            if (exporter != null)
            {
                BlockEditorLogHelper.LogExport(modelIndex); yield return null;
                exporter.Export();
                BlockEditorLogHelper.LogExported(modelIndex); yield return null;

                if (exporter.ModelBlockItem != null)
                {
                    successful = Enumerable.SequenceEqual(importer.ModelBlockItem.Bytes, exporter.ModelBlockItem.Bytes);
                    if (successful)
                    {
                        importer.AssetsHelper.DeleteAssets();
                        DestroyImmediate(Selection.objects.SingleOrDefault() as GameObject);
                        BlockEditorLogHelper.LogTestReExportSuccessful(modelIndex); yield return null;
                    }
                }
            }
            if (!successful)
            {
                BlockEditorLogHelper.LogTestReExportFailed(modelIndex);
                yield return null;
            }
        }

        private IEnumerator TestReExportAllCoroutine()
        {
            BlockEditorLogHelper.LogTestReExportAll();
            LoadBlocks();
            for (int i = 0; i < modelBlock.Count; i++)
                yield return EditorCoroutineUtility.StartCoroutine(TestReExportCoroutine(i), this);
            BlockEditorLogHelper.LogTestedReExportAllFinished();
            importAllCoroutine = null;
        }

        #endregion

        #region Methods (get importer/exporter)

        private ModelBlockItemImporter GetModelImporter(int modelIndex)
        {
            LoadBlocks();
            return new ModelBlockItemImporter(modelBlock, modelIndex, textureBlock);
        }

        private ModelBlockItemExporter GetModelExporter(int modelIndex)
        {
            ModelBlockItemWrapper modelComponent = 
                SelectionHelper.GetSelectedGameObjectComponent<ModelBlockItemWrapper>();
            if (modelComponent == null)
                return null;
            else
                return new ModelBlockItemExporter(modelComponent, modelIndex);
        }

        #endregion

        #region Methods (LoadBlocks() / SaveBlocks())

        private void LoadBlocks()
        {
            modelBlock = BlockLoader.Load<Swe1rModelBlockItem>(Path.Combine(blocksPath, modelBlockFilename));
            textureBlock = BlockLoader.Load<Swe1rTextureBlockItem>(Path.Combine(blocksPath, textureBlockFilename));
            splineBlock = BlockLoader.Load<Swe1rSplineBlockItem>(Path.Combine(blocksPath, splineBlockFilename));
            spriteBlock = BlockLoader.Load<Swe1rSpriteBlockItem>(Path.Combine(blocksPath, spriteBlockFilename));
        }

        private void SaveBlocks()
        {
            if (!Directory.Exists(blocksPath))
                Debug.LogError($"Directory \"{blocksPath}\" does not exist.");

            modelBlock?.Save(Path.Combine(blocksPath, modelBlockFilename));
            textureBlock?.Save(Path.Combine(blocksPath, textureBlockFilename));
            splineBlock?.Save(Path.Combine(blocksPath, splineBlockFilename));
            spriteBlock?.Save(Path.Combine(blocksPath, spriteBlockFilename));
        }

        #endregion
    }
}
