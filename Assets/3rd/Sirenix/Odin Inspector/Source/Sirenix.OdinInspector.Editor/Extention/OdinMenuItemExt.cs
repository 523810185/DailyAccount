#if UNITY_EDITOR
namespace Sirenix.OdinInspector.Editor
{
    using UnityEngine;
    using UnityEditor;
    using System;
    using System.Linq;
    using Sirenix.Utilities.Editor;
    using System.Collections.Generic;

    public class OdinMenuItemExt : OdinMenuItem
    {
        public string AssetPath;
        public string initName { get; set; }
        public event Action<OdinMenuItem> OnDragItem;
        public event Action<OdinMenuItem> OnDropItem;
        private float dragTimeStart = 0;

        //是否是文件夹
        public bool IsDirectory()
        {
            return (string.IsNullOrEmpty(AssetPath));
        }

        public OdinMenuItemExt(OdinMenuTree tree, string name, object value) : base(tree, name, value)
        {
            this.initName = name;
        }

        public new void Select(bool addToSelection = false)
        {
            if (addToSelection && this.menuTree.Selection.Count > 0)
            {
                if (Value == null && this.menuTree.Selection[0].Value != null)
                {
                    this.menuTree.Selection.Clear();
                }
                if (Value != null && this.menuTree.Selection[0].Value == null)
                {
                    this.menuTree.Selection.Clear();
                }
            }

            if (addToSelection == false)
            {
                this.menuTree.Selection.Clear();
            }

            this.menuTree.Selection.Add(this);
        }

        public override void DrawMenuItem(int indentLevel)
        {
            var e = OdinMenuTree.CurrentEvent;
            var eType = OdinMenuTree.CurrentEventType;
            if (eType == EventType.Ignore)
            {
                return;
            }

            base.DrawMenuItem(indentLevel);

            this.HandleMouseEvents(this.Rect, this.triangleRect);
        }

        /// <summary>
        /// Handles the mouse events.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="triangleRect">The triangle rect.</param>
        protected new void HandleMouseEvents(Rect rect, Rect triangleRect)
        {
            //Othen window mouse events 
            if (EditorWindow.mouseOverWindow != EditorWindow.focusedWindow)
            {
                return;
            }

            var e = Event.current.type;

            if (e == EventType.MouseDrag || e == EventType.DragPerform || e == EventType.DragUpdated || e == EventType.DragExited)
            {
                if (this.OnDragItem != null)
                {
                    this.OnDragItem(this);
                }
                //if (this.OnDropItem != null)
                //{
                //    this.OnDropItem(this);
                //}
            }


            if (e == EventType.Used && this.wasMouseDownEvent)
            {
                this.wasMouseDownEvent = false;
                handleClickEventOnMouseUp = this;
            }

            bool isMouseClick =
                (e == EventType.MouseDown) ||
                (e == EventType.MouseUp && handleClickEventOnMouseUp == this);

            if (isMouseClick)
            {
                handleClickEventOnMouseUp = null;
                this.wasMouseDownEvent = false;

                if (!rect.Contains(Event.current.mousePosition))
                {
                    return;
                }

                var hasChildren = this.ChildMenuItems.Any();
                var selected = this.IsSelected;

                // No more pining.
                // bool isUnityObjectInstance = instance as UnityEngine.Object;
                // if (selected && isUnityObjectInstance)
                // {
                //     var unityObject = instance as UnityEngine.Object;
                //     var behaviour = unityObject as Behaviour;
                //     if (behaviour)
                //     {
                //         unityObject = behaviour.gameObject;
                //     }
                //     EditorGUIUtility.PingObject(unityObject);
                // }

                if (Event.current.button == 1)
                {
                    if (this.OnRightClick != null)
                    {
                        this.OnRightClick(this);
                    }
                }

                if (Event.current.button == 0)
                {
                    bool toggle = false;

                    if (hasChildren)
                    {
                        if (selected && Event.current.modifiers == EventModifiers.None)
                        {
                            toggle = true;
                        }
                        else if (triangleRect.Contains(Event.current.mousePosition))
                        {
                            toggle = true;
                        }
                    }

                    if (toggle && triangleRect.Contains(Event.current.mousePosition))
                    {
                        var state = !this.Toggled;

                        if (Event.current.modifiers == EventModifiers.Alt)
                        {
                            foreach (var item in this.GetChildMenuItemsRecursive(true))
                            {
                                item.Toggled = state;
                            }
                        }
                        else
                        {
                            this.Toggled = state;
                        }
                    }
                    else
                    {
                        bool shiftSelect =
                            this.menuTree.Selection.SupportsMultiSelect &&
                            Event.current.modifiers == EventModifiers.Shift &&
                            this.menuTree.Selection.Count > 0;

                        if (shiftSelect)
                        {
                            var curr = this.menuTree.Selection.First();
                            var maxIterations = Mathf.Abs(curr.FlatTreeIndex - this.FlatTreeIndex) + 1;
                            var down = curr.FlatTreeIndex < this.FlatTreeIndex;
                            this.menuTree.Selection.Clear();

                            for (int i = 0; i < maxIterations; i++)
                            {
                                if (curr == null)
                                {
                                    break;
                                }

                                curr.Select(true);

                                if (curr == this)
                                {
                                    break;
                                }

                                curr = down ? curr.NextVisualMenuItem : curr.PrevVisualMenuItem;
                            }
                        }
                        else
                        {
                            var ctrl = Event.current.modifiers == EventModifiers.Control;
                            if (ctrl && selected && this.MenuTree.Selection.SupportsMultiSelect)
                            {
                                this.Deselect();
                            }
                            else
                            {
                                this.Select(ctrl);
                            }

                            if (this.MenuTree.Config.ConfirmSelectionOnDoubleClick && Event.current.clickCount == 2)
                            {
                                this.MenuTree.Selection.ConfirmSelection();
                            }
                        }
                    }
                }

                GUIHelper.RemoveFocusControl();
                Event.current.Use();
            }
            else
            {
                if (this.OnDropItem != null || this.OnDragItem != null)
                {
                    if (e == EventType.MouseDrag || e == EventType.DragPerform || e == EventType.DragUpdated || e == EventType.DragExited)
                    {
                        if (e == EventType.MouseDrag)
                        {
                            dragTimeStart = 0;
                        }
                        else if (e == EventType.DragExited)
                        {
                            dragTimeStart = 0;
                        }
                        else if (e == EventType.DragUpdated)
                        {
                            dragTimeStart++;
                        }

                        this.OnMenuItemDragUpdate();
                        if (this.OnDragItem != null)
                        {
                            this.OnDragItem(this);
                        }
                        this.OnDropItemHandles();
                    }
                }
            }
        }

        protected object OnMenuItemDragUpdate()
        {
            if (this.MenuTree == null)
            {
                return null;
            }
            bool isMutilSelect = this.MenuTree.Selection.Count > 1;
            if (!isMutilSelect)
            {
                return DragAndDropUtilities.DragZone(this.Rect, this.Value, true, false);
            }

            List<UnityEngine.Object> obj_list = new List<UnityEngine.Object>();
            for (int i = 0; i < this.MenuTree.Selection.Count; i++)
            {
                obj_list.Add((this.MenuTree.Selection[i].Value as UnityEngine.Object));
            }
            var id = DragAndDropUtilities.GetSelfDragAndDropId(this.Rect);
            return DragAndDropUtilities.DragZoneList(this.Rect, obj_list.ToArray(), typeof(UnityEngine.Object), true, false, id);
        }

        protected void OnDropItemHandles()
        {
            if (this.MenuTree == null)
            {
                return;
            }
            var id = DragAndDropUtilities.GetSelfDragAndDropId(this.Rect);
            bool isMutilSelect = this.MenuTree.Selection.Count > 1;
            if (!isMutilSelect)
            {
                object obj = DragAndDropUtilities.DropZone(this.Rect, null, typeof(UnityEngine.Object), true, id);
                if (obj != null && this.OnDropItem != null)
                {
                    if (dragTimeStart > 5)
                    {
                        this.OnDropItem(this);
                        dragTimeStart = 0f;
                    }
                }
                return;
            }

            object[] obj_array = DragAndDropUtilities.DropZoneList(this.Rect, this.Value, typeof(UnityEngine.Object), true, id);
            if (obj_array != null)
            {
                if (this.OnDropItem != null)
                {
                    if (dragTimeStart > 5)
                    {
                        this.OnDropItem(this);
                        dragTimeStart = 0f;
                    }
                }
                return;
            }
        }

    }
}
#endif