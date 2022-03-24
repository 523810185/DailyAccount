using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

#if UNITY_EDITOR
namespace Sirenix.OdinInspector.Custom
{
    [Serializable]
    [CreateAssetMenu(menuName = "Custom/Create DailyAccountData")]
    public class DailyAccountData : SerializedScriptableObject
    {
        public enum CostType
        {
            Default = 0,
            Card = 1, // 小卡片
            Book = 2, // 书籍
            ACG = 3, // 二次元相关
            Food = 4, // 饮食
            Movie = 5, // 电影
            Treat = 6, // 请客
            Present = 7, // 送礼
            Electronic = 8, // 电子设备
            Traffic = 9, // 交通
            Travel = 10, // 旅游
            Pet = 11, // 宠物
            Game = 12, // 游戏
            LifeMust = 13, // 生活必须
            ForFamily = 14, // 家里人
        }

        public class CostTypeToStringMgr
        {
            private static Dictionary<CostType, string> m_mapTypeToString = null;
            private static bool m_bIsInit = false;
            private static void EnsureInit()
            {
                if(!m_bIsInit)
                {
                    m_mapTypeToString = new Dictionary<CostType, string>();
                    m_mapTypeToString.Add(CostType.Default, "其它");
                    m_mapTypeToString.Add(CostType.Card, "小卡片");
                    m_mapTypeToString.Add(CostType.Book, "书籍");
                    m_mapTypeToString.Add(CostType.ACG, "二次元相关");
                    m_mapTypeToString.Add(CostType.Game, "游戏");
                    m_mapTypeToString.Add(CostType.Food, "饮食");
                    m_mapTypeToString.Add(CostType.Movie, "电影");
                    m_mapTypeToString.Add(CostType.Treat, "请客");
                    m_mapTypeToString.Add(CostType.Present, "送礼");
                    m_mapTypeToString.Add(CostType.Electronic, "电子设备");
                    m_mapTypeToString.Add(CostType.Traffic, "交通");
                    m_mapTypeToString.Add(CostType.Travel, "旅游");
                    m_mapTypeToString.Add(CostType.Pet, "宠物");
                    m_mapTypeToString.Add(CostType.LifeMust, "生活必须");
                    m_mapTypeToString.Add(CostType.ForFamily, "家里人");
                }
            }

            public static string GetString(CostType type) 
            {
                EnsureInit();
                string str = "undefined";
                m_mapTypeToString.TryGetValue(type, out str);
                return str;
            }
        }


        [Serializable]
        public class Item : IComparable<Item>, IEquatable<Item>
        {
            [LabelText("年"), LabelWidth(50), HorizontalGroup("data")]
            public int year;

            [LabelText("月"), LabelWidth(50), HorizontalGroup("data")]
            public int month;

            [LabelText("日"), LabelWidth(50), HorizontalGroup("data")]
            public int day;

            [LabelText("花费"), LabelWidth(50), HorizontalGroup("cost")]
            public float cost = 0;

            [LabelText("消费类型"), LabelWidth(50), HorizontalGroup("cost")]
            [ValueDropdown("OnCostTypeDropDown")]
            public CostType costType = CostType.Default;
            private ValueDropdownList<CostType> OnCostTypeDropDown = new ValueDropdownList<CostType>
            {
                {CostTypeToStringMgr.GetString(CostType.Default), CostType.Default},
                {CostTypeToStringMgr.GetString(CostType.Card), CostType.Card},
                {CostTypeToStringMgr.GetString(CostType.Book), CostType.Book},
                {CostTypeToStringMgr.GetString(CostType.ACG), CostType.ACG},
                {CostTypeToStringMgr.GetString(CostType.Game), CostType.Game},
                {CostTypeToStringMgr.GetString(CostType.Food), CostType.Food},
                {CostTypeToStringMgr.GetString(CostType.Movie), CostType.Movie},
                {CostTypeToStringMgr.GetString(CostType.Treat), CostType.Treat},
                {CostTypeToStringMgr.GetString(CostType.Present), CostType.Present},
                {CostTypeToStringMgr.GetString(CostType.Electronic), CostType.Electronic},
                {CostTypeToStringMgr.GetString(CostType.Traffic), CostType.Traffic},
                {CostTypeToStringMgr.GetString(CostType.Travel), CostType.Travel},
                {CostTypeToStringMgr.GetString(CostType.Pet), CostType.Pet},
                {CostTypeToStringMgr.GetString(CostType.LifeMust), CostType.LifeMust},
                {CostTypeToStringMgr.GetString(CostType.ForFamily), CostType.ForFamily},
            };

            [LabelText("备注"), LabelWidth(50)]
            public string remarks = "";

            public int CompareTo(Item other)
            {
                if(year != other.year) return year - other.year;
                if(month != other.month) return month - other.month;
                if(day != other.day) return day - other.day;
                return 0;
            }

            public bool Equals(Item other)
            {
                return this.CompareTo(other) == 0;
            }

            public override int GetHashCode()
            {
                return year * 233 + month * 71 + day * 37;
            }
        }

        [Searchable()]
        [OnValueChanged("OnListChange")]
        public List<Item> list;
        private int m_fLastCnt = -1;
        private void OnListChange()
        {
            if(m_fLastCnt == -1) 
            {
                m_fLastCnt = list.Count;
                return;
            }

            if(m_fLastCnt != list.Count) 
            {
                if(list.Count > m_fLastCnt) 
                {
                    var last = list[list.Count - 1];
                    if(last.year == 0 && last.month == 0 && last.day == 0) 
                    {
                        if(list.Count >= 2) 
                        {
                            var pre = list[list.Count - 2];
                            last.year = pre.year;
                            last.month = pre.month;
                            last.day = pre.day;
                        }
                    }
                }
                m_fLastCnt = list.Count;
            }
        }

        [Button("按照时间排序", ButtonSizes.Medium)]
        public void SortByTime()
        {
            list.Sort();
        }

        [ShowInInspector]
        public string guid
        {
            get 
            {
                string guid = "";
                long _;
                AssetDatabase.TryGetGUIDAndLocalFileIdentifier(this.GetInstanceID(), out guid, out _);
                return guid;
            }
        }
    }
}
#endif