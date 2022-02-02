using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public enum BodyType
    {
        NONE,
        Skinny,
        Average,
        Muscular,
        Fat
    }

    public enum HairType
    {
        NONE,
        Straight,
        Curly,
        Wavy
    }

    public enum HairLength
    {
        NONE,
        Bald,
        Short,
        Medium,
        Long
    }

    public enum Sex
    {
        NONE,
        M,
        F,
        O
    }

    [Serializable]
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
        protected BaseStuff() { }

        public string Name { get => _name; }
        public string Value { get => _value; set { _value = value; } }
        public string Description { get => _description; set { _description = value; } }

        public virtual string MoreInfo()
        {
            string moreInfo;
            moreInfo = Description;
            return moreInfo;
        }
    }

    [Serializable]
    public class ClassRace : BaseStuff
    {
        private int[] _baseSkills = new int[5];

        public ClassRace(string name, string value, string description, int[] baseSkills)
        {
            _name = name;
            _value = value;
            _description = description;
            _baseSkills = baseSkills;
        }

        public int[] BaseSkills { get => _baseSkills; set { _baseSkills = value; } }

        public override string MoreInfo()
        {
            string moreInfo;
            moreInfo = Description + "\n" + "Strength: " + BaseSkills[0].ToString() + "\n" + "Dexterity: " + BaseSkills[1].ToString() + "\n" + "Constituton: " + BaseSkills[2].ToString() +
                "\n" + "Intelligence: " + BaseSkills[3].ToString() + "\n" + "Charisma: " + BaseSkills[4].ToString();
            return moreInfo;
        }
    }

    [Serializable]
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

    [Serializable]
    public class Equipment : BaseStuff
    {
        protected string _enchantment;

        public string Enchantment { get { return _enchantment; } }

    }

    [Serializable]
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

        public override string MoreInfo()
        {
            string moreInfo;
            moreInfo = Description + "\n" + "Damage: " + _damage.ToString("F1") + "\n" + "Range: " + _range.ToString("F1");
            return moreInfo;
        }
    }

    [Serializable]
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

        public override string MoreInfo()
        {
            string moreInfo;
            moreInfo = Description + "\n" + "Defense: " + _defense.ToString("F1");
            return moreInfo;
        }
    }

    [Serializable]
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

        public List<BaseStuff> GetCharacteristics { get => Characteristics; }

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
        Lawful,
        Neutral,
        Chaotic
    }

    public enum GoodEvil
    {
        Good,
        Neutral,
        Evil
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

    // Le code ci-dessous vient de www.codeproject.com/Articles/23832/Implementing-Deep-Cloning-via-Serializing-objects
    // Je voulais faire Class A = Class B mais apparemment c'est pas possible vu que ça crée une référence
    // Et moi je voulais faire une vraie copie
    // Donc apparemment faut faire une deep copy et ce code permet de le faire parce que y'a pas de manière simple de le faire

    public static class ObjectCopier
    {
        public static Character Clone<Character>(Character source)
        {
            if (!typeof(Character).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (source is null)
            {
                return default(Character);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (Character)formatter.Deserialize(stream);
            }
        }
    }
}
