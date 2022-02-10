#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="InlineEditorModesExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using UnityEngine;
    using Sirenix.OdinInspector;

    [AttributeExample(
        typeof(InlineEditorAttribute),
        Name = "Modes",
        Description = "The InlineEditor has various modes that can be used for different use cases.")]
    internal class InlineEditorModesExample
    {
        [Title("Boxed / Default")]
        [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
        public ExampleTransform Boxed = ExampleHelper.GetScriptableObject<ExampleTransform>();

        [Title("Foldout")]
        [InlineEditor(InlineEditorObjectFieldModes.Foldout)]
        public ExampleTransform Foldout = ExampleHelper.GetScriptableObject<ExampleTransform>();

        [Title("Hide ObjectField")]
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        public ExampleTransform CompletelyHidden = ExampleHelper.GetScriptableObject<ExampleTransform>();

        [Title("Show ObjectField if null")]
        [InlineEditor(InlineEditorObjectFieldModes.Hidden)]
        public ExampleTransform OnlyHiddenWhenNotNull = ExampleHelper.GetScriptableObject<ExampleTransform>();

        public class ExampleTransform : ScriptableObject
        {
            public Vector3 Position;
            public Quaternion Rotation;
            public Vector3 Scale = Vector3.one;
        }
    }
}
#endif