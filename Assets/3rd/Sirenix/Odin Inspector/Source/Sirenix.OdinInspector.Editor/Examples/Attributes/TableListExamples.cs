#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="TableListExamples.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using UnityEngine;
    using Sirenix.OdinInspector;
    using System.Collections.Generic;
    using System;

    [AttributeExample(typeof(TableListAttribute))]
    internal class TableListExamples
    {
        [TableList(ShowIndexLabels = true)]
        public List<SomeCustomClass> TableListWithIndexLabels = new List<SomeCustomClass>()
        {
            new SomeCustomClass(),
            new SomeCustomClass(),
        };

        [TableList(DrawScrollView = true, MaxScrollViewHeight = 200, MinScrollViewHeight = 100)]
        public List<SomeCustomClass> MinMaxScrollViewTable = new List<SomeCustomClass>()
        {
            new SomeCustomClass(),
            new SomeCustomClass(),
        };

        [TableList(AlwaysExpanded = true, DrawScrollView = false)]
        public List<SomeCustomClass> AlwaysExpandedTable = new List<SomeCustomClass>()
        {
            new SomeCustomClass(),
            new SomeCustomClass(),
        };

        [TableList(ShowPaging = true)]
        public List<SomeCustomClass> TableWithPaging = new List<SomeCustomClass>()
        {
            new SomeCustomClass(),
            new SomeCustomClass(),
        };

        [Serializable]
        public class SomeCustomClass
        {
            [TableColumnWidth(57, Resizable = false)]
            [PreviewField(Alignment = ObjectFieldAlignment.Center)]
            public Texture Icon = ExampleHelper.GetTexture();

            [TextArea]
            public string Description = ExampleHelper.GetString();

            [VerticalGroup("Combined Column"), LabelWidth(22)]
            public string A, B, C;

            [TableColumnWidth(60)]
            [Button, VerticalGroup("Actions")]
            public void Test1() { }
        
            [TableColumnWidth(60)]
            [Button, VerticalGroup("Actions")]
            public void Test2() { }
        }
    }
}
#endif