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
        }


        [Serializable]
        public class Item : IComparable<Item>
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
                {"其它", CostType.Default},
                {"小卡片", CostType.Card},
                {"书籍", CostType.Book},
                {"二次元相关", CostType.ACG},
                {"饮食", CostType.Food},
                {"电影", CostType.Movie},
                {"请客", CostType.Treat},
                {"送礼", CostType.Present},
                {"电子设备", CostType.Electronic},
                {"交通", CostType.Traffic},
                {"旅游", CostType.Travel},
                {"宠物", CostType.Pet},
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
        }

        [Searchable()]
        public List<Item> list;

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