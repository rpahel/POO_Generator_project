using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Basic Character Info")]
    [SerializeField]
    private List<string> _firstNames;
    [SerializeField]
    private List<string> _familyNames;
    [SerializeField]
    private List<CharacterClass> _characterClasses;
    [SerializeField]
    private List<CharacterRace> _characterRaces;
    [SerializeField]
    private List<string> _colors;
    [Space(20)]

    [Header("Equipments")]
    [SerializeField]
    private List<WeaponInfo> _weapons;
    [SerializeField]
    private List<ArmorInfo> _armors;
    [SerializeField]
    private List<string> _enchantments;
    [Space(20)]

    [Header("Traits")]
    [SerializeField]
    private List<Trait> _traits;

    private Character[] _generatedCharacters = new Character[3];

    public List<Character> _keptCharacters = new List<Character>();

    public Character[] GeneratedCharacters { get { return _generatedCharacters; } }

    public void GenerateBasicInfo()
    {
        for(int i = 0; i < 3; i++)
        {
            Character character;
            if(_generatedCharacters[i] != null)
            {
                _generatedCharacters[i].ClearBasicInfo();
                character = _generatedCharacters[i];
            }
            else
            {
                character = new Character();
            }

            string characterNameString = _firstNames[Random.Range(0, _firstNames.Count)] + " " + _familyNames[Random.Range(0, _familyNames.Count)];
            BaseStuff characterName = new BaseStuff("characterName", characterNameString);
            character.AddNew(characterName);

            string characterAlignementString = ((LawChaos)Random.Range(0, 3)).ToString() + " " + ((GoodEvil)Random.Range(0, 3)).ToString();
            BaseStuff characterAlignement = new BaseStuff("characterAlignment", characterAlignementString);
            character.AddNew(characterAlignement);

            CharacterClass newClass = _characterClasses[Random.Range(0, _characterClasses.Count)];
            BaseStuff characterClass = new ClassRace("characterClass", newClass.value, newClass.description, newClass.baseSkills);
            character.AddNew(characterClass);

            CharacterRace newRace = _characterRaces[Random.Range(0, _characterRaces.Count)];
            BaseStuff characterRace = new ClassRace("characterRace", newRace.value, newRace.description, newRace.baseSkills);
            character.AddNew(characterRace);

            BaseStuff characterBody = new Body((HairLength)Random.Range(1, 5), (HairType)Random.Range(1, 4), _colors[Random.Range(0, _colors.Count)], _colors[Random.Range(0, _colors.Count)], (BodyType)Random.Range(1, 5), Random.Range(100.0f, 250.0f), Random.Range(0.1f, 120.0f), (Sex)Random.Range(1, 4));
            character.AddNew(characterBody);

            _generatedCharacters[i] = character;
        }
    }

    public void GenerateTraits()
    {
        for (int i = 0; i < 3; i++)
        {
            Character character;
            _generatedCharacters[i].ClearTraits();
            character = _generatedCharacters[i];

            for (int o = 0; o < 5; o++)
            {
                int X = Random.Range(0, _traits.Count);
                BaseStuff newTrait = new BaseStuff("characterTrait", _traits[X].value, _traits[X].description);
                character.AddNew(newTrait);
            }

            _generatedCharacters[i] = character;
        }
    }

    public void GenerateEquipment()
    {
        for (int i = 0; i < 3; i++)
        {
            Character character;
            _generatedCharacters[i].ClearEquipment();
            character = _generatedCharacters[i];

            for (int o = 0; o < 5; o++)
            {
                int X = Random.Range(0, _weapons.Count);
                if (Random.Range(0, 2) == 0)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        BaseStuff newWeapon = new Weapon(_weapons[X].value, _weapons[X].description, Random.Range(.0f, 100.0f), Random.Range(.0f, 100.0f));
                        character.AddNew(newWeapon);
                    }
                    else
                    {
                        BaseStuff newWeapon = new Weapon(_weapons[X].value, _weapons[X].description, Random.Range(.0f, 100.0f), Random.Range(.0f, 100.0f), _enchantments[Random.Range(0, _enchantments.Count)]);
                        character.AddNew(newWeapon);
                    }
                }
                else
                {
                    X = Random.Range(0, _armors.Count);
                    if (Random.Range(0, 2) == 0)
                    {
                        BaseStuff newArmor = new Armor(_armors[X].value, _armors[X].description, Random.Range(.0f, 100.0f));
                        character.AddNew(newArmor);
                    }
                    else
                    {
                        BaseStuff newArmor = new Armor(_armors[X].value, _armors[X].description, Random.Range(.0f, 100.0f), _enchantments[Random.Range(0, _enchantments.Count)]);
                        character.AddNew(newArmor);
                    }
                }
            }
            _generatedCharacters[i] = character;
        }
    }
}
