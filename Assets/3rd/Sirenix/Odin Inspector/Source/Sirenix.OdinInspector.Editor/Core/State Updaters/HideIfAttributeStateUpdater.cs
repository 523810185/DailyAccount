#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="HideIfAttributeStateUpdater.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

[assembly: Sirenix.OdinInspector.Editor.RegisterStateUpdater(typeof(Sirenix.OdinInspector.Editor.StateUpdaters.HideIfAttributeStateUpdater))]

namespace Sirenix.OdinInspector.Editor.StateUpdaters
{
#pragma warning disable

    using Sirenix.OdinInspector.Editor.Drawers;

    public sealed class HideIfAttributeStateUpdater : AttributeStateUpdater<HideIfAttribute>
    {
        private IfAttributeHelper helper;

        protected override void Initialize()
        {
            this.helper = new IfAttributeHelper(this.Property, this.Attribute.Condition, false);
            this.ErrorMessage = this.helper.ErrorMessage;
            this.Property.AnimateVisibility = this.Attribute.Animate;
        }

        public override void OnStateUpdate()
        {
            // 新版Odin中Showif的实现会导致以前的一些用法出错，先临时修改一下源码，后面把标签的用法改一改在删掉这些代码
            this.Property.State.Visible &= !this.helper.GetValue(this.Attribute.Value);
            // 新版Odin中Showif的实现会导致以前的一些用法出错，先临时修改一下源码，后面把标签的用法改一改在删掉这些代码

            // this.Property.State.Visible = !this.helper.GetValue(this.Attribute.Value);
            this.ErrorMessage = this.helper.ErrorMessage;
        }
    }
}
#endif