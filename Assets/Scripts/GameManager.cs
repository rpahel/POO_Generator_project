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

    private void Awake()
    {

    }
}
