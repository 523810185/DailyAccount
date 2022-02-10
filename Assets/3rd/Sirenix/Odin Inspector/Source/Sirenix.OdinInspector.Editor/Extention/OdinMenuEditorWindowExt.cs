#if UNITY_EDITOR
namespace Sirenix.OdinInspector.Editor
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    public class OdinMenuEditorWindowExt : OdinMenuEditorWindow
    {
        protected override OdinMenuTree BuildMenuTree()
        {
            throw new System.NotImplementedException();
        }
        public bool EnableDrawEditors { get; set; } = true;

        [NonSerialized]
        public static bool processStatus = false;
        [NonSerialized]
        public static bool lastProcessStatus = false;

        public Action OnAssetDynLoadFinish;


        protected override void DrawEditors()
        {
            if (EnableDrawEditors)
            {
                base.DrawEditors();
            }
        }

        [Flags]
        public enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        protected static extern int SetCursorPos(int x, int y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(MouseEventFlag dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        public static bool MoveTo(float x, float y)
        {
            if (!UnityEngine.Screen.fullScreen)
            {
                UnityEngine.Debug.LogError("need full screen");
                return false;
            }
            SetCursorPos((int)x, (int)y);
            return true;
        }

        protected override void DrawMenu()
        {
            base.DrawMenu();
            processStatus = false;
            if (lastProcessStatus && !processStatus)
            {
                if (OnAssetDynLoadFinish != null)
                {
                    OnAssetDynLoadFinish();
                }
                EditorUtility.ClearProgressBar();
                lastProcessStatus = false;
            }
        }
    }
}
#endif