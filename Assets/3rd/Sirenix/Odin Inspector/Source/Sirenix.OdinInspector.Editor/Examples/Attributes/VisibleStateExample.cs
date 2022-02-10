#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="VisibleStateExample.cs" company="Sirenix IVS">
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

	[AttributeExample(typeof(OnStateUpdateAttribute), "The following example shows how OnStateUpdate can be used to control the visible state of a property.")]
	internal class VisibleStateExample
	{
		[OnStateUpdate("@$property.State.Visible = ToggleMyInt")]
		public int MyInt;
		
		public bool ToggleMyInt;
	}
}
#endif