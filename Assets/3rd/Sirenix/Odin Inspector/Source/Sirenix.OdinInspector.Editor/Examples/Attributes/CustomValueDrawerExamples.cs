#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="CustomValueDrawerExamples.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using System;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEditor;
    using Sirenix.Utilities.Editor;

    [AttributeExample(typeof(CustomValueDrawerAttribute))]
    internal class CustomValueDrawerExamples
    {
        public float From = 2, To = 7;

        [CustomValueDrawer("MyCustomDrawerStatic")]
        public float CustomDrawerStatic;

        [CustomValueDrawer("MyCustomDrawerInstance")]
        public float CustomDrawerInstance;

        [CustomValueDrawer("MyCustomDrawerAppendRange")]
        public float AppendRange;

        [CustomValueDrawer("MyCustomDrawerArrayNoLabel")]
        public float[] CustomDrawerArrayNoLabel = new float[] { 3f, 5f, 6f };

        private static float MyCustomDrawerStatic(float value, GUIContent label)
        {
            return EditorGUILayout.Slider(label, value, 0f, 10f);
        }

        private float MyCustomDrawerInstance(float value, GUIContent label)
        {
            return EditorGUILayout.Slider(label, value, this.From, this.To);
        }

        private float MyCustomDrawerAppendRange(float value, GUIContent label, Func<GUIContent, bool> callNextDrawer)
        {
            SirenixEditorGUI.BeginBox();
            callNextDrawer(label);
            var result = EditorGUILayout.Slider(value, this.From, this.To);
            SirenixEditorGUI.EndBox();
            return result;
        }

        private float MyCustomDrawerArrayNoLabel(float value)
        {
            return EditorGUILayout.Slider(value, this.From, this.To);
        }

    }
}
#endif