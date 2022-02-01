using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public enum BodyType
    {
        NONE,
        SKINNY,
        AVERAGE,
        MUSCULAR,
        FAT
    }
    
    public enum HairType
    {
        NONE,
        STRAIGHT,
        CURLY,
        WAVY
    }
    
    public enum HairLength
    {
        NONE,
        BALD,
        SHORT,
        MEDIUM,
        LONG
    }
    
    public enum Sex
    {
        NONE,
        M,
        F,
        O
    }

    public class BaseStuff
    {
        protected string _name;
        protected string _value;
        protected string _description;

        public BaseStuff(string name, string value, string description)
        {
            _name = name;
            _value = value;
            _description = description;
        }
        public BaseStuff(string name, string value)
        {
            _name = name;
            _value = value;
            _description = null;
        }
        protected BaseStuff(){}

        public string Name { get => _name; }
        public string Value { get => _value; set{ _value = value; } }
        public string Description { get => _description; set { _description = value; } }
    }

    public class ClassRace : BaseStuff
    {
        public int[] _baseSkills = new int[5];

        public ClassRace(string name, string value, string description, int[] baseSkills)
        {
            _name = name;
            _value = value;
            _description = description;
            _baseSkills = baseSkills;
        }

        public int[] GetBaseSkills { get; set; }
    }

    public class Body : BaseStuff
    {
        public HairLength _hairLength;
        public HairType _hairType;
        public string _hairColor;
        public string _eyeColor;
        public BodyType _bodyType;
        public float _height;
        public float _weight;
        public Sex _sex;

        public Body(HairLength hairLength, HairType hairType, string hairColor, string eyeColor, BodyType bodyType, float height, float weight, Sex sex)
        {
            _name = "characterBody";
            _value = null;
            _description = null;
            _hairLength = hairLength;
            _hairType = hairType;
            _hairColor = hairColor;
            _eyeColor = eyeColor;
            _bodyType = bodyType;
            _height = height;
            _weight = weight;
            _sex = sex;
        }
    }

    public class Equipment : BaseStuff
    {
        protected string _enchantment;

        public string Enchantment { get { return _enchantment; } }
    }

    public class Weapon : Equipment
    {
        public float _damage;
        public float _range;

        public Weapon(string value, string description, float damage, float range, string enchantment)
        {
            _name = "weapon";
            _value = value;
            _description = description;
            _enchantment = enchantment;
            _damage = damage;
            _range = range;
        }
        public Weapon(string value, string description, float damage, float range)
        {
            _name = "weapon";
            _value = value;
            _description = description;
            _enchantment = null;
            _damage = damage;
            _range = range;
        }
    }

    public class Armor : Equipment
    {
        public float _defense;
        public Armor(string value, string description, float defense, string enchantment)
        {
            _name = "armor";
            _value = value;
            _description = description;
            _defense = defense;
            _enchantment = enchantment;
        }

        public Armor(string value, string description, float defense)
        {
            _name = "armor";
            _value = value;
            _description = description;
            _defense = defense;
            _enchantment = null;
        }
    }

    public class Character
    {
        private List<BaseStuff> Characteristics;
        public Character()
        {
            Characteristics = new List<BaseStuff>();
        }
        public void AddNew(BaseStuff stuff)
        {
            Characteristics.Add(stuff);
        }

        public List<BaseStuff> GetCharacteristics{ get => Characteristics; }
        
        public void ClearBasicInfo()
        {
            Characteristics.RemoveAll(x => x.Name == "characterName");
            Characteristics.RemoveAll(x => x.Name == "characterAlignment");
            Characteristics.RemoveAll(x => x.Name == "characterClass");
            Characteristics.RemoveAll(x => x.Name == "characterRace");
            Characteristics.RemoveAll(x => x.Name == "characterBody");
        }
        public void ClearEquipment()
        {
            Characteristics.RemoveAll(x => x.Name == "weapon");
            Characteristics.RemoveAll(x => x.Name == "armor");
        }
        public void ClearTraits()
        {
            Characteristics.RemoveAll(x => x.Name == "characterTrait");
        }
    }

    // CODE FOR GAMEMANAGER

    public enum LawChaos
    {
        LAWFUL,
        NEUTRAL,
        CHAOTIC
    }

    public enum GoodEvil
    {
        GOOD,
        NEUTRAL,
        EVIL
    }

    [Serializable]
    public struct CharacterClass
    {
        public string value;
        public string description;
        public int[] baseSkills;
    }

    [Serializable]
    public struct CharacterRace
    {
        public string value;
        public string description;
        public int[] baseSkills;
    }

    [Serializable]
    public struct WeaponInfo
    {
        public string value;
        public string description;
    }

    [Serializable]
    public struct ArmorInfo
    {
        public string value;
        public string description;
    }

    [Serializable]
    public struct Trait
    {
        public string value;
        public string description;
    }
}
