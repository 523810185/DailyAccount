#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="BigTitleGroupExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using System;
    using UnityEngine;

    [AttributeExample(typeof(BoxGroupAttribute), Order = 10)]
    [AttributeExample(typeof(ButtonGroupAttribute), Order = 10)]
    [AttributeExample(typeof(TitleGroupAttribute), Order = 10)]
    internal class BigTitleGroupExample
    {
        [BoxGroup("Titles", ShowLabel = false)]
        [TitleGroup("Titles/First Title")]
        public int A;

        [BoxGroup("Titles/Boxed")]
        [TitleGroup("Titles/Boxed/Second Title")]
        public int B;

        [TitleGroup("Titles/Boxed/Second Title")]
        public int C;

        [TitleGroup("Titles/Horizontal Buttons")]
        [ButtonGroup("Titles/Horizontal Buttons/Buttons")]
        public void FirstButton() { }

        [ButtonGroup("Titles/Horizontal Buttons/Buttons")]
        public void SecondButton() { }
    }
}
#endif