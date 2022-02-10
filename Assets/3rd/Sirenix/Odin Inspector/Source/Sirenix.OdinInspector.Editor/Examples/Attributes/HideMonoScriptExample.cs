#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="HideMonoScriptExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using UnityEngine;

    [AttributeExample(
        typeof(HideMonoScriptAttribute),
        Description = "The HideMonoScript attribute lets you hide the script reference at the top of the inspector of Unity objects." +
        "You can use this to reduce some of the clutter in your inspector.\n" +
        "You can also eanble this behaviour globally from the general options in Tools > Odin Inspector > Preferences > General.")]
    internal class HideMonoScriptExample
    {
        [InfoBox("Click the pencil icon to open new inspector for these fields.")]
        public HideMonoScript Hidden = ExampleHelper.GetScriptableObject<HideMonoScript>();

        // The script will also be hidden for the ShowMonoScript object if MonoScripts are hidden globally.
        public ShowMonoScript Shown = ExampleHelper.GetScriptableObject<ShowMonoScript>();

        [HideMonoScript]
        public class HideMonoScript : ScriptableObject
        {
            public string Value;
        }

        public class ShowMonoScript : ScriptableObject
        {
            public string Value;
        }
    }
}
#endif