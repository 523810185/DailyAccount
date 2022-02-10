#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="ExpandedStateExample.cs" company="Sirenix IVS">
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

    [AttributeExample(typeof(OnStateUpdateAttribute), "The following example shows how OnStateUpdate can be used to control the expanded state of a list.")]
	internal class ExpandedStateExample
	{
		[OnStateUpdate("@$property.State.Expanded = ExpandList")]
		public List<string> list;

		public bool ExpandList;
	}
}
#endif