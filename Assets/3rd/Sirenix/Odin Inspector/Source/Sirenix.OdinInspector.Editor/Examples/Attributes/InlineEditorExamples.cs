#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="InlineEditorExamples.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using UnityEngine;
    using Sirenix.OdinInspector;

    [AttributeExample(typeof(InlineEditorAttribute))]
    internal class InlineEditorExamples
    {
        [InlineEditor]
        public ExampleTransform InlineComponent = ExampleHelper.GetScriptableObject<ExampleTransform>();

        [InlineEditor(InlineEditorModes.FullEditor)]
        public Material FullInlineEditor = ExampleHelper.GetMaterial();

        [InlineEditor(InlineEditorModes.GUIAndHeader)]
        public Material InlineMaterial = ExampleHelper.GetMaterial();

        [InlineEditor(InlineEditorModes.SmallPreview)]
        public Material[] InlineMaterialList = new Material[]
        {
            ExampleHelper.GetMaterial(),
            ExampleHelper.GetMaterial(),
            ExampleHelper.GetMaterial(),
        };

        [InlineEditor(InlineEditorModes.LargePreview)]
        public Mesh InlineMeshPreview = ExampleHelper.GetMesh();

        // You can also use the InlineEditor attribute directly on a class definition itself.
        //[InlineEditor]
        public class ExampleTransform : ScriptableObject
        {
            public Vector3 Position;
            public Quaternion Rotation;
            public Vector3 Scale = Vector3.one;
        }
    }
}
#endif