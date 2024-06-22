// SPDX-License-Identifier: MIT

using UnityEngine;

namespace SWE1R.Assets.Blocks.Unity.Editor
{
    internal static class BlockEditorLogHelper
    {
        internal static void LogImport(int modelIndex) =>
            Debug.Log($"Import model {modelIndex}...");

        internal static void LogImported(int modelIndex) =>
            Debug.Log($"Imported model {modelIndex}.");

        internal static void LogExport(int modelIndex) =>
            Debug.Log($"Export model {modelIndex}...");

        internal static void LogExported(int modelIndex) =>
            Debug.Log($"Exported model {modelIndex}.");

        internal static void LogExportToModelBlock(int modelIndex) =>
            Debug.Log($"Export model {modelIndex} to block...");

        internal static void LogExportedToModelBlock(int modelIndex) =>
            Debug.Log($"Exported model {modelIndex} to block.");

        internal static void LogTestReExport(int modelIndex) =>
            Debug.Log($"Test re-export of model {modelIndex}...");

        internal static void LogTestReExportSuccessful(int modelIndex) =>
            Debug.Log($"Test re-export of model {modelIndex} successful.");

        internal static void LogTestReExportFailed(int modelIndex) =>
            Debug.LogError($"Test re-export of model {modelIndex} failed.");

        internal static void LogTestReExportAll() =>
            Debug.Log($"Test re-export all.");

        internal static void LogTestedReExportAllFinished() =>
            Debug.Log($"Test re-export all finished.");
    }
}
