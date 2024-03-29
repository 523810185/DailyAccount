﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

#if UNITY_EDITOR
namespace Sirenix.OdinInspector.Custom
{
    [Serializable]
    public class WindowShowerSupport
    {
        public WindowShowerSupport(DailyAccountData data) 
        {
            this.SetContext(data);
        }

        private DailyAccountData m_stData = null;
        public void SetContext(DailyAccountData data)
        {
            m_stData = data;
            m_stData.Init();
        }

        private bool IsInit()
        {
            return m_stData != null;
        }

        private List<DailyAccountData.Item> m_stShowData = new List<DailyAccountData.Item>();
        private void GenShowDataByDateLimit()
        {
            bool Cmp(Vector3Int v3, DailyAccountData.Item x, bool isLess)
            {
                int sign = isLess ? 1 : -1;
                // v3 < x => v3 - x < 0
                if((v3.x - x.year) * sign < 0)
                {
                    return true;
                }
                else if(v3.x - x.year == 0) 
                {
                    if((v3.y - x.month) * sign < 0) 
                    {
                        return true;
                    }
                    else if(v3.y - x.month == 0)
                    {
                        return (v3.z - x.day) * sign <= 0;
                    }
                }
                return false;
            }
            m_stShowData = m_stData.list.Where(
                (x) => {
                    return Cmp(stDate, x, isLess: true) && Cmp(edDate, x, isLess: false);
                }
            ).ToList();
        }

        private void SetTitle()
        {
            if(!IsInit())
            {
                return;
            }

            m_fAllCost = 0f;
            m_stData.SortByTime();
            m_stShowData.ForEach(x => m_fAllCost += x.cost);
            // foreach (var item in m_stData.list)
            // {
            //     // TODO.. 暂时先这么过滤一下非法数据
            //     if(item.year < 2022) 
            //     {
            //         continue;
            //     }
                
            //     m_fAllCost += item.cost;
            // }

            mainTitle = $"总花费：{m_fAllCost}";
            // var firstItem = m_stData.list[0];
            // var lastItem = m_stData.list[m_stData.list.Count - 1];
            // subTitle = $"从 {firstItem.year}-{firstItem.month}-{firstItem.day} 到 {lastItem.year}-{lastItem.month}-{lastItem.day}";
            subTitle = $"从 {stDate.x}-{stDate.y}-{stDate.z} 到 {edDate.x}-{edDate.y}-{edDate.z}";
        }

        #region 数据层（显示层）
        
        private float m_fAllCost = 0;
        private string mainTitle { get; set; }
        private string subTitle { get; set; }

        [Title("$mainTitle", "$subTitle", titleAlignment:TitleAlignments.Centered)]
        public List<ProgressItem> progressItems = new List<ProgressItem>();
        
        [LabelText("起始日期"), HorizontalGroup("endBarDateHor"), OnValueChanged("OnDateChange")]
        public Vector3Int stDate;

        [LabelText("结束日期"), HorizontalGroup("endBarDateHor"), OnValueChanged("OnDateChange")]
        public Vector3Int edDate;

        public DateTime xxx;

        private void OnDateChange()
        {
            GenShowDataByDateLimit();
            SetTitle();
        }

        #endregion

        #region 数据结构
        [Serializable]
        public class ProgressItem
        {
            public const float MAX = 100f;

            [HideLabel, LabelWidth(5)]
            [DisplayAsString]
            [HorizontalGroup("hor")]
            public string title = "";

            [HideLabel]
            [ReadOnly, ProgressBar(0, "MAX", ColorGetter = "GetColor", CustomValueStringGetter = "$strOnBar")]
            [HorizontalGroup("hor")]
            public float progerss = 0f;

            public string strOnBar { get; set; }

            public float val { get; set; }

            private Color GetColor()
            {
                return Color.Lerp(Color.green, Color.red, 1f * progerss / MAX);
            }
        }
        #endregion

        [Button("按照日期排序", ButtonSizes.Medium)]
        public void ShowProgressByDate()
        {
            if(!IsInit())
            {
                return;
            }

            SetTitle();

            m_stData.SortByTime();
            Dictionary<DailyAccountData.Item, float> dateToCost = new Dictionary<DailyAccountData.Item, float>();

            foreach (var item in m_stData.list)
            {
                var key = item;
                if(!dateToCost.ContainsKey(item))
                {
                    key = new DailyAccountData.Item();
                    key.year = item.year;
                    key.month = item.month;
                    key.day = item.day;
                    dateToCost.Add(key, 0);
                }

                dateToCost[key] = dateToCost[key] + item.cost;
            }

            float max = 0.001f;
            float all = 0f;
            foreach (var kv in dateToCost)
            {
                max = Mathf.Max(max, kv.Value);
                all += kv.Value;
            }

            progressItems.Clear();
            foreach (var kv in dateToCost)
            {
                var item = kv.Key;
                var cost = kv.Value;
                var newProgressItem = new ProgressItem();
                newProgressItem.progerss = ProgressItem.MAX * cost / max; 
                float rate = (float)Math.Round((double)100 * cost / all, 2);
                newProgressItem.strOnBar = $"{cost} ({rate}%)";
                newProgressItem.title = $"{item.year}-{item.month}-{item.day}: ";
                progressItems.Add(newProgressItem);
            }
        }

        [Button("按照类型排序", ButtonSizes.Medium), HorizontalGroup("SortByTypeHor")]
        public void ShowProgressByType()
        {
            if(!IsInit())
            {
                return;
            }

            // SetTitle();
            
            // m_stData.SortByTime();
            Dictionary<DailyAccountData.CostType, float> typeAllCost = new Dictionary<DailyAccountData.CostType, float>();

            // foreach (var item in m_stData.list)
            foreach (var item in m_stShowData)
            {
                // TODO.. 暂时先这么过滤一下非法数据
                if(item.year < 2022) 
                {
                    continue;
                }

                var costType = item.costType;
                var cost = item.cost;
                if(!typeAllCost.ContainsKey(costType))
                {
                    typeAllCost.Add(costType, 0f);
                }
                typeAllCost[costType] = typeAllCost[costType] + cost;
            }

            float max = 0.001f;
            float all = 0f;
            foreach (var kv in typeAllCost)
            {
                max = Mathf.Max(max, kv.Value);
                all += kv.Value;
            }

            progressItems.Clear();
            foreach (var kv in typeAllCost)
            {
                var costType = kv.Key;
                var cost = kv.Value;
                var newProgressItem = new ProgressItem();
                newProgressItem.progerss = ProgressItem.MAX * cost / max; 
                newProgressItem.val = cost;
                float rate = (float)Math.Round((double)100 * cost / all, 2);
                newProgressItem.strOnBar = $"{cost} ({rate}%)";
                newProgressItem.title = $"{DailyAccountData.CostTypeToStringMgr.GetString(costType)}: ";
                progressItems.Add(newProgressItem);
            }

            // 按照花费从高到低排序
            progressItems.Sort((a, b) => { var diff = a.val - b.val; return diff < 0f ? 1 : diff > 0f ? -1 : 0;} );
        }

        [Button("前进一个月", ButtonSizes.Medium), HorizontalGroup("SortByTypeHor")]
        private void ShowTypeAndStepOneMonth()
        {
            stDate.y += 1;
            edDate.y += 1;
            OnDateChange();
            ShowProgressByType();
        }
    }
}
#endif