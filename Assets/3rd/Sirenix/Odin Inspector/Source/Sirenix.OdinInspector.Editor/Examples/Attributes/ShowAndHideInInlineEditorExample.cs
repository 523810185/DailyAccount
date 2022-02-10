#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="ShowAndHideInInlineEditorExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using UnityEngine;

    [AttributeExample(typeof(ShowInInlineEditorsAttribute))]
    [AttributeExample(typeof(HideInInlineEditorsAttribute))]
    internal class ShowAndHideInInlineEditorExample
    {
        [InfoBox("Click the pen icon to open a new inspector window for the InlineObject too see the differences these attributes make.")]
        [InlineEditor(Expanded = true)]
        public MyInlineScriptableObject InlineObject = ExampleHelper.GetScriptableObject<MyInlineScriptableObject>();

        public class MyInlineScriptableObject : ScriptableObject
        {
            [ShowInInlineEditors]
            public string ShownInInlineEditor;

            [HideInInlineEditors]
            public string HiddenInInlineEditor;
        }
    }
}
#endif