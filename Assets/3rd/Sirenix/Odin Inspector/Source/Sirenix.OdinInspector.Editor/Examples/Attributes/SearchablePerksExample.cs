#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="SearchablePerksExample.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable
namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [AttributeExample(typeof(SearchableAttribute), "The Searchable attribute can be applied to individual members in a type, to make only that member searchable.", Order = -2)]
    public class SearchablePerksExample
    {
        [Searchable]
        public List<Perk> Perks = new List<Perk>()
        {
            new Perk()
            {
                Name = "Old Sage",
                Effects = new List<Effect>()
                {
                    new Effect() { Skill = Skill.Wisdom, Value = 2, },
                    new Effect() { Skill = Skill.Intelligence, Value = 1, },
                    new Effect() { Skill = Skill.Strength, Value = -2 },
                },
            },
            new Perk()
            {
                Name = "Hardened Criminal",
                Effects = new List<Effect>()
                {
                    new Effect() { Skill = Skill.Dexterity, Value = 2, },
                    new Effect() { Skill = Skill.Strength, Value = 1, },
                    new Effect() { Skill = Skill.Charisma, Value = -2 },
                },
            },
            new Perk()
            {
                Name = "Born Leader",
                Effects = new List<Effect>()
                {
                    new Effect() { Skill = Skill.Charisma, Value = 2, },
                    new Effect() { Skill = Skill.Intelligence, Value = -3 },
                },
            },
            new Perk()
            {
                Name = "Village Idiot",
                Effects = new List<Effect>()
                {
                    new Effect() { Skill = Skill.Charisma, Value = 4, },
                    new Effect() { Skill = Skill.Constitution, Value = 2, },
                    new Effect() { Skill = Skill.Intelligence, Value = -3 },
                    new Effect() { Skill = Skill.Wisdom, Value = -3 },
                },
            },
        };

        [Serializable]
        public class Perk
        {
            public string Name;

            [TableList]
            public List<Effect> Effects;
        }

        [Serializable]
        public class Effect
        {
            public Skill Skill;
            public float Value;
        }

        public enum Skill
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma,
        }
    }
}
#endif