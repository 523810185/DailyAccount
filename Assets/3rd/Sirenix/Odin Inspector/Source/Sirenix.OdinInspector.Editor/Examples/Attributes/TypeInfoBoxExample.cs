#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="TypeInfoBoxExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using System;
    using UnityEngine;

    [AttributeExample(typeof(TypeInfoBoxAttribute))]
    internal class TypeInfoBoxExample
    {
        public MyType MyObject = new MyType();

        [InfoBox("Click the pen icon to open a new inspector for the Scripty object.")]
        [InlineEditor]
        public MyScripty Scripty = ExampleHelper.GetScriptableObject<MyScripty>();

        [Serializable]
        [TypeInfoBox("The TypeInfoBox attribute can be put on type definitions and will result in a InfoBox being drawn at the to of a property.")]
        public class MyType
        {
            public int Value;
        }

        [TypeInfoBox("The TypeInfoBox attribute can also be used to display a text at the top of, for example, MonoBehaviours or ScriptableObjects.")]
        public class MyScripty : ScriptableObject
        {
            public string MyText = ExampleHelper.GetString();
            [TextArea(10, 15)]
            public string Box;
        }
    }
}
#endif