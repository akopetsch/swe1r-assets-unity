// SPDX-License-Identifier: MIT

using UnityEditor;
using UnityEngine;
using Swe1rGraphicsCommand = SWE1R.Assets.Blocks.ModelBlock.F3DEX2.GraphicsCommand;

namespace SWE1R.Assets.Blocks.Unity.ModelBlock.F3DEX2.Editor
{
    public abstract class GraphicsCommandWrapperPropertyDrawer<TSource> : PropertyDrawer
        where TSource : Swe1rGraphicsCommand
    {
        #region Properties

        protected string MacroName => 
            Swe1rGraphicsCommand.GetMacroName<TSource>();

        protected abstract string[] PropertyNames { get; }

        #endregion

        #region Methods

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            //position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // backup indent level
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0; // do not indent

            // macro name
            var macroNameGuiContent = new GUIContent(MacroName);
            var textDimensions = GUI.skin.label.CalcSize(macroNameGuiContent);
            var previousRect = new Rect(position.x, position.y, textDimensions.x, position.height);
            EditorGUI.LabelField(position, macroNameGuiContent);
            
            // macro arguments
            foreach (string propertyName in PropertyNames)
            {
                previousRect = new Rect(previousRect.xMax + 5, position.y, 30, position.height);
                EditorGUI.PropertyField(previousRect, property.FindPropertyRelative(propertyName), GUIContent.none);
            }

            // restore indent level
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }

        #endregion
    }
}
