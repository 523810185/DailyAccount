#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="DisableInInlineEditorExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using UnityEngine;

    [AttributeExample(typeof(DisableInInlineEditorsAttribute))]
    internal class DisableInInlineEditorExample
    {
        [InfoBox("Click the pen icon to open a new inspector window for the InlineObject too see the difference this attribute make.")]
        [InlineEditor(Expanded = true)]
        public MyInlineScriptableObject InlineObject = ExampleHelper.GetScriptableObject<MyInlineScriptableObject>();

        public class MyInlineScriptableObject : ScriptableObject
        {
            public string AlwaysEnabled;

            [DisableInInlineEditors]
            public string DisabledInInlineEditor;
        }
    }
}
#endif