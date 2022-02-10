#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="OnInspectorInitExamples.cs" company="Sirenix IVS">
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

    [AttributeExample(typeof(OnInspectorInitAttribute), "The following example demonstrates how OnInspectorInit works.")]
    internal class OnInspectorInitExamples
    {
        // Display current time for reference.
        [ShowInInspector, DisplayAsString, PropertyOrder(-1)]
        public string CurrentTime { get { GUIHelper.RequestRepaint(); return DateTime.Now.ToString(); } }

        // OnInspectorInit executes the first time this string is about to be drawn in the inspector.
        // It will execute again when the example is reselected.
        [OnInspectorInit("@TimeWhenExampleWasOpened = DateTime.Now.ToString()")]
        public string TimeWhenExampleWasOpened;

        // OnInspectorInit will not execute before the property is actually "resolved" in the inspector.
        // Remember, Odin's property system is lazily evaluated, and so a property does not actually exist
        // and is not initialized before something is actually asking for it.
        // 
        // Therefore, this OnInspectorInit attribute won't execute until the foldout is expanded.
        [FoldoutGroup("Delayed Initialization", Expanded = false, HideWhenChildrenAreInvisible = false)]
        [OnInspectorInit("@TimeFoldoutWasOpened = DateTime.Now.ToString()")]
        public string TimeFoldoutWasOpened;
    }
}
#endif