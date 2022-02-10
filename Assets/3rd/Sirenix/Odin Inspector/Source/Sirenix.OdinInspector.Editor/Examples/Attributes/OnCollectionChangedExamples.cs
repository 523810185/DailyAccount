#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="OnCollectionChangedExamples.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using Sirenix.Serialization;
    using System.Collections.Generic;
    using UnityEngine;

    [AttributeExample(typeof(OnCollectionChangedAttribute), "The following example shows how OnCollectionChanged can be used to get callbacks when a collection is being changed.")]
    [ShowOdinSerializedPropertiesInInspector]
    internal class OnCollectionChangedExamples
    {
        [InfoBox("Change the collection to get callbacks detailing the changes that are being made.")]
        [OnCollectionChanged("Before", "After")]
        public List<string> list = new List<string>() { "str1", "str2", "str3" };

        [OnCollectionChanged("Before", "After")]
        public HashSet<string> hashset = new HashSet<string>() { "str1", "str2", "str3" };

        [OnCollectionChanged("Before", "After")]
        public Dictionary<string, string> dictionary = new Dictionary<string, string>() { { "key1", "str1" }, { "key2", "str2" }, { "key3", "str3" } };

        public void Before(CollectionChangeInfo info, object value)
        {
            Debug.Log("Received callback BEFORE CHANGE with the following info: " + info + ", and the following collection instance: " + value);
        }
        
        public void After(CollectionChangeInfo info, object value)
        {
            Debug.Log("Received callback AFTER CHANGE with the following info: " + info + ", and the following collection instance: " + value);
        }
    }
}
#endif