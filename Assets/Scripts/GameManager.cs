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

    private void Awake()
    {
        for(int i = 0; i < 3; i++)
        {
            Character character = new Character();

            string characterNameString = _firstNames[Random.Range(0, _firstNames.Count)] + " " + _familyNames[Random.Range(0, _familyNames.Count)];
            BaseStuff characterName = new BaseStuff("characterName", characterNameString);
            character.AddNew(characterName);

            CharacterClass newClass = _characterClasses[Random.Range(0,_characterClasses.Count)];
            BaseStuff characterClass = new ClassRace("characterClass", newClass.value, newClass.description, newClass.baseSkills);
            character.AddNew(characterClass);
            
            CharacterRace newRace = _characterRaces[Random.Range(0,_characterRaces.Count)];
            BaseStuff characterRace = new ClassRace("characterRace", newRace.value, newRace.description, newRace.baseSkills);
            character.AddNew(characterRace);

            BaseStuff characterBody = new Body((HairLength)Random.Range(1, 5), (HairType)Random.Range(1, 4), _colors[Random.Range(0, _colors.Count)], _colors[Random.Range(0, _colors.Count)], (BodyType)Random.Range(1, 5), Random.Range(100.0f, 250.0f), Random.Range(0.1f, 300.0f), (Sex)Random.Range(1, 4));

            Body bodyInfo = characterBody as Body;
            Debug.Log(characterName.Value + ", class: " + characterClass.Value + ", race: " + characterRace.Value + ", hair length: " + bodyInfo._hairLength + ", hair type: " + bodyInfo._hairType + ", hair color: " + bodyInfo._hairColor + ", eye color: " + bodyInfo._eyeColor + ", body type: " + bodyInfo._bodyType + ", height: " + bodyInfo._height + " cm, weight: " + bodyInfo._weight + " kg, sex: " + bodyInfo._sex + ".");

            _generatedCharacters[i] = character;
        }
    }
}
