using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
namespace Sirenix.OdinInspector.Custom
{
    using UnityEditor;
    using Sirenix.OdinInspector.Editor;

    public class DailyAccountDataWindow : OdinEditorWindow
    {
        [MenuItem("账单/打开")]
        public static void Open()
        {  
            var window = GetWindow<DailyAccountDataWindow>();
            window.Init();
            window.Show();
        }

        #region 内部成员
        private DailyAccountData m_stData = null;
        private WindowShowerSupport m_stShower = null;
        #endregion

        private void Init()
        {
            this.titleContent = new GUIContent("账单查看");
            LoadData();

            // Show
            m_stShower.ShowProgressByDate();
        }

        private void LoadData()
        {
            m_stData = AssetDatabase.LoadAssetAtPath<DailyAccountData>("Assets/Scripts/DailyAccountData.asset");
            m_stShower = new WindowShowerSupport(m_stData);
        }

        protected override object GetTarget()
        {
            return m_stShower;
        }
    }
}
#endif