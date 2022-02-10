#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="TableMatrixExamples.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using UnityEngine;
    using Sirenix.OdinInspector;
    using Sirenix.Utilities;

    [ShowOdinSerializedPropertiesInInspector]
    [AttributeExample(typeof(TableMatrixAttribute), "Right-click and drag the column and row labels in order to modify the tables.")]
    internal class TableMatrixExamples
    {
        [TableMatrix(HorizontalTitle = "Square Celled Matrix", SquareCells = true)]
        public Texture2D[,] SquareCelledMatrix = new Texture2D[8, 4]
        {
            { ExampleHelper.GetTexture(), null, null, null }, 
            { null, ExampleHelper.GetTexture(), null, null },
            { null, null, ExampleHelper.GetTexture(), null },
            { null, null, null, ExampleHelper.GetTexture() },
            { ExampleHelper.GetTexture(), null, null, null },
            { null, ExampleHelper.GetTexture(), null, null },
            { null, null, ExampleHelper.GetTexture(), null },
            { null, null, null, ExampleHelper.GetTexture() },
        };

        [TableMatrix(SquareCells = true)]
        public Mesh[,] PrefabMatrix = new Mesh[8, 4]
        {
            { ExampleHelper.GetMesh(), null, null, null },
            { null, ExampleHelper.GetMesh(), null, null },
            { null, null, ExampleHelper.GetMesh(), null },
            { null, null, null, ExampleHelper.GetMesh() },
            { null, null, null, ExampleHelper.GetMesh() },
            { null, null, ExampleHelper.GetMesh(), null },
            { null, ExampleHelper.GetMesh(), null, null },
            { ExampleHelper.GetMesh(), null, null, null },
        };
    }
}
#endif