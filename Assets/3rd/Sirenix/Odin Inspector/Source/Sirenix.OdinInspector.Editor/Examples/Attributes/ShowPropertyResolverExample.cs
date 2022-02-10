#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="ShowPropertyResolverExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [ShowOdinSerializedPropertiesInInspector]
    [AttributeExample(typeof(ShowPropertyResolverAttribute),
        Description = "The ShowPropertyResolver attribute allows you to debug how your properties are handled by Odin behind the scenes.")]
    internal class ShowPropertyResolverExample
    {
        [ShowPropertyResolver]
        public string MyString;

        [ShowPropertyResolver]
        public List<int> MyList;

        [ShowPropertyResolver]
        public Dictionary<int, Vector3> MyDictionary;
    }
}
#endif