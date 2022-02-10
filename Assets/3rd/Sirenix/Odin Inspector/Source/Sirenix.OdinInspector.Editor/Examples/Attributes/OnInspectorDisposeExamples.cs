#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="OnInspectorDisposeExamples.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using Sirenix.Serialization;
    using Sirenix.Utilities.Editor;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [AttributeExample(typeof(OnInspectorDisposeAttribute), "The following example demonstrates how OnInspectorDispose works.")]
    internal class OnInspectorDisposeExamples
    {
        [OnInspectorDispose("@UnityEngine.Debug.Log(\"Dispose event invoked!\")")]
        [ShowInInspector, InfoBox("When you change the type of this field, or set it to null, the former property setup is disposed. The property setup will also be disposed when you deselect this example."), DisplayAsString]
        public BaseClass PolymorphicField;

        public abstract class BaseClass { public override string ToString() { return this.GetType().Name; } }
        public class A : BaseClass { }
        public class B : BaseClass { }
        public class C : BaseClass { }
    }
}
#endif