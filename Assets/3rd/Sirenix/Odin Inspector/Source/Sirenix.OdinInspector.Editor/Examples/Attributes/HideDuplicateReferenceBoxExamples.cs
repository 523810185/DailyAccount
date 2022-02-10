#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="HideDuplicateReferenceBoxExamples.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using UnityEngine;
    using System.Collections.Generic;
    using Sirenix.Utilities.Editor;

    [AttributeExample(typeof(HideDuplicateReferenceBoxAttribute), "Indicates that Odin should hide the reference box, if this property would otherwise be drawn as a reference to another property, due to duplicate reference values being encountered."), ShowOdinSerializedPropertiesInInspector]
    internal partial class HideDuplicateReferenceBoxExamples
    {
        public ReferenceTypeClass firstObject;

        public ReferenceTypeClass withReferenceBox;

        [HideDuplicateReferenceBox]
        public ReferenceTypeClass withoutReferenceBox;

        public void Setup()
        {
            this.firstObject = new ReferenceTypeClass();
            this.withReferenceBox = this.firstObject;
            this.withoutReferenceBox = this.firstObject;
            this.firstObject.recursiveReference = this.firstObject;
        }

        public partial class ReferenceTypeClass
        {
            [HideDuplicateReferenceBox]
            public ReferenceTypeClass recursiveReference;
        }
    }

    internal partial class HideDuplicateReferenceBoxExamples
    {
        public HideDuplicateReferenceBoxExamples()
        {
            this.Setup();
        }

        [OnInspectorGUI, PropertyOrder(0)]
        private void MessageBox1()
        {
            SirenixEditorGUI.Title("The first reference will always be drawn normally", null, TextAlignment.Left, true);
        }

        [OnInspectorGUI, PropertyOrder(2)]
        private void MessageBox2()
        {
            GUILayout.Space(20);
            SirenixEditorGUI.Title("All subsequent references will be wrapped in a reference box", null, TextAlignment.Left, true);
        }

        [OnInspectorGUI, PropertyOrder(4)]
        private void MessageBox3()
        {
            GUILayout.Space(20);
            SirenixEditorGUI.Title("With the [HideDuplicateReferenceBox] attribute, this box is hidden", null, TextAlignment.Left, true);
        }

        public partial class ReferenceTypeClass
        {
            [OnInspectorGUI, PropertyOrder(-1)]
            private void MessageBox()
            {
                SirenixEditorGUI.WarningMessageBox("Recursively drawn references will always show the reference box regardless, to prevent infinite depth draw loops.");
            }
        }
    }
    
    internal class HideDuplicateReferenceBoxExamplesPropertyProcessor : OdinPropertyProcessor<HideDuplicateReferenceBoxExamples>
    {
        public override void ProcessMemberProperties(List<InspectorPropertyInfo> propertyInfos)
        {
            propertyInfos.Find("firstObject").GetEditableAttributesList().Add(new PropertyOrderAttribute(1));
            propertyInfos.Find("withReferenceBox").GetEditableAttributesList().Add(new PropertyOrderAttribute(3));
            propertyInfos.Find("withoutReferenceBox").GetEditableAttributesList().Add(new PropertyOrderAttribute(5));
        }
    }
}
#endif