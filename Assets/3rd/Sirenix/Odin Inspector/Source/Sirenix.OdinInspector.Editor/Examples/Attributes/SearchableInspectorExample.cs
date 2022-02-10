#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="SearchableInspectorExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [AttributeExample(typeof(SearchableAttribute), "The Searchable attribute can be applied to a root inspected type, like a Component, ScriptableObject or OdinEditorWindow, to make the whole type searchable.")]
    [Searchable]
    internal class SearchableInspectorExample
    {
        public List<string> strings = new List<string>(Enumerable.Range(1, 10).Select(i => "Str Element " + i));

        public List<ExampleStruct> searchableList = new List<ExampleStruct>(Enumerable.Range(1, 10).Select(i => new ExampleStruct(i)));

        [Serializable]
        public struct ExampleStruct
        {
            public string Name;
            public int Number;
            public ExampleEnum Enum;

            public ExampleStruct(int nr)
            {
                this.Name = "Element " + nr;
                this.Number = nr;
                this.Enum = (ExampleEnum)UnityEngine.Random.Range(0, 5);
            }
        }

        public enum ExampleEnum
        {
            One, Two, Three, Four, Five
        }
    }
}
#endif