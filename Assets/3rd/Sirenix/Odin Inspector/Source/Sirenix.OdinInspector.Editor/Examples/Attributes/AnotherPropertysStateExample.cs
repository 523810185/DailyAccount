#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="AnotherPropertysStateExample.cs" company="Sirenix IVS">
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

    [AttributeExample(typeof(OnStateUpdateAttribute), "The following example shows how OnStateUpdate can be used to control the state of another property.")]
	internal class AnotherPropertysStateExample
	{
		public List<string> list;
		
		[OnStateUpdate("@#(list).State.Expanded = $value")]
		public bool ExpandList;
	}
}
#endif