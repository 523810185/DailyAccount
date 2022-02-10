#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="TableColumnWidthExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using Sirenix.Utilities.Editor;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [AttributeExample(typeof(TableColumnWidthAttribute))]
    internal class TableColumnWidthExample
    {
        [TableList]
        public List<MyItem> List = new List<MyItem>()
        {
            new MyItem(),
            new MyItem(),
            new MyItem(),
        };

        [Serializable]
        public class MyItem
        {
            [PreviewField(Height = 20)]
            [TableColumnWidth(30, Resizable = false)]
            public Texture2D Icon = ExampleHelper.GetTexture();

            [TableColumnWidth(60)]
            public int ID;

            public string Name;
        }
    }
}
#endif