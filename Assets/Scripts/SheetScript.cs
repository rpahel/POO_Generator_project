using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SheetScript : MonoBehaviour
{
    [HideInInspector]
    public int _sheetNb;
    [HideInInspector]
    public bool _isLoadedSheet = false;

    [Header("Basic Info Texts")]
    public TMP_Text _characterNameText;
    public TMP_Text _sexText;
    public TMP_Text _alignementText;
    public TMP_Text _classText;
    public TMP_Text _raceText;
    public TMP_Text _strengthText;
    public TMP_Text _dexterityText;
    public TMP_Text _constitutionText;
    public TMP_Text _intelligenceText;
    public TMP_Text _charismaText;
    public TMP_Text _hairTypeText;
    public TMP_Text _hairLengthText;
    public TMP_Text _hairColorText;
    public TMP_Text _eyeColorText;
    public TMP_Text _bodyTypeText;
    public TMP_Text _heightText;
    public TMP_Text _weightText;
    private TMP_Text[] _skillsTexts;
    [Space(20)]

    [Header("Equipment")]
    public TMP_Text _item1Text;
    public TMP_Text _item2Text;
    public TMP_Text _item3Text;
    public TMP_Text _item4Text;
    public TMP_Text _item5Text;
    private TMP_Text[] _itemTexts;
    [Space(20)]

    [Header("Trait")]
    public TMP_Text _trait1Text;
    public TMP_Text _trait2Text;
    public TMP_Text _trait3Text;
    public TMP_Text _trait4Text;
    public TMP_Text _trait5Text;
    private TMP_Text[] _traitTexts;

    private void Awake()
    {
        _itemTexts = new TMP_Text[5]{ _item1Text, _item2Text, _item3Text, _item4Text, _item5Text};
        _traitTexts = new TMP_Text[5]{ _trait1Text, _trait2Text, _trait3Text, _trait4Text, _trait5Text};
        _skillsTexts = new TMP_Text[5]{ _strengthText, _dexterityText, _constitutionText, _intelligenceText, _charismaText};
        
        BasicHoverable script = _classText.gameObject.GetComponent<BasicHoverable>();
        script._index = _sheetNb;
        script._fromLoadedSheet = _isLoadedSheet;
        script._name = "characterClass";

        script = _raceText.gameObject.GetComponent<BasicHoverable>();
        script._index = _sheetNb;
        script._fromLoadedSheet = _isLoadedSheet;
        script._name = "characterRace";

        for (int i = 0; i < 5; i++)
        {
            _itemTexts[i].text = "";
            
            _traitTexts[i].text = "";
        }
    }

    public void UpdateBasicInfo()
    {
        int[] baseSkills = new int[5] { 0, 0, 0, 0, 0 };

        foreach (var info in GlobalManager.GameInstance.GeneratedCharacters[_sheetNb].GetCharacteristics)
        {
            switch (info.Name)
            {
                case "characterName":
                    _characterNameText.text = info.Value;
                    break;

                case "characterAlignment":
                    _alignementText.text = info.Value;
                    break;

                case "characterClass":
                    _classText.text = info.Value;
                    ClassRace yop = info as ClassRace;
                    for (int i = 0; i < baseSkills.Length; i++)
                    {
                        baseSkills[i] += yop.BaseSkills[i];
                    }
                    break;

                case "characterRace":
                    _raceText.text = info.Value;
                    ClassRace poy = info as ClassRace;
                    for (int i = 0; i < baseSkills.Length; i++)
                    {
                        baseSkills[i] += poy.BaseSkills[i];
                    }
                    break;

                case "characterBody":
                    Body bodyInfo = info as Body;
                    _sexText.text = bodyInfo._sex.ToString();
                    _hairTypeText.text = "Hair type: " + bodyInfo._hairType.ToString();
                    _hairLengthText.text = "Hair length: " + bodyInfo._hairLength.ToString();
                    _hairColorText.text = "Hair color: " + bodyInfo._hairColor;
                    _eyeColorText.text = "Eye color: " + bodyInfo._eyeColor;
                    _bodyTypeText.text = "Body type: " + bodyInfo._bodyType.ToString();
                    _heightText.text = "Height: " + bodyInfo._height.ToString("F2") + " cm";
                    _weightText.text = "Weight: " + bodyInfo._weight.ToString("F2") + " kg";
                    break;

                default:
                    break;
            }
        }

        for (int i = 0; i < _skillsTexts.Length; i++)
        {
            _skillsTexts[i].text = baseSkills[i].ToString();
        }
    }


    public void UpdateEquipment()
    {
        int itemNb = 0;
        foreach (var info in GlobalManager.GameInstance.GeneratedCharacters[_sheetNb].GetCharacteristics)
        {
            if(info.Name == "weapon")
            {
                BasicHoverable script = _itemTexts[itemNb].gameObject.GetComponent<BasicHoverable>();
                script._index = _sheetNb;
                script._fromLoadedSheet = _isLoadedSheet;
                script._name = "weapon";
            }

            if(info.Name == "armor")
            {
                BasicHoverable script = _itemTexts[itemNb].gameObject.GetComponent<BasicHoverable>();
                script._index = _sheetNb;
                script._fromLoadedSheet = _isLoadedSheet;
                script._name = "armor";
            }

            if (info.Name == "weapon" || info.Name == "armor")
            {
                _itemTexts[itemNb].text = info.Value;
                itemNb++;
            }
        }
    }

    public void UpdateTraits()
    {
        int traitNb = 0;
        foreach (var info in GlobalManager.GameInstance.GeneratedCharacters[_sheetNb].GetCharacteristics)
        {
            if(info.Name == "characterTrait")
            {
                _traitTexts[traitNb].text = info.Value;
                BasicHoverable script = _traitTexts[traitNb].gameObject.GetComponent<BasicHoverable>();
                script._index = _sheetNb;
                script._fromLoadedSheet = _isLoadedSheet;
                script._name = "characterTrait";
                traitNb++;
            }
        }
    }

    public void SelectSheet()
    {
        GlobalManager.UIInstance.ShowSelectedSheet(_sheetNb);
    }

    public void LoadInfo(int position)
    {
        _sheetNb = position;
        int[] baseSkills = new int[5]{0,0,0,0,0};
        int itemNb = 0;
        int traitNb = 0;
        foreach (var info in GlobalManager.GameInstance._keptCharacters[position].GetCharacteristics)
        {
            switch (info.Name)
            {
                case "characterName":
                    _characterNameText.text = info.Value;
                    break;

                case "characterAlignment":
                    _alignementText.text = info.Value;
                    break;

                case "characterClass":
                    _classText.text = info.Value;
                    ClassRace yop = info as ClassRace;
                    for(int i = 0; i < baseSkills.Length; i++)
                    {
                        baseSkills[i] += yop.BaseSkills[i];
                    }
                    break;

                case "characterRace":
                    _raceText.text = info.Value;
                    ClassRace poy = info as ClassRace;
                    for (int i = 0; i < baseSkills.Length; i++)
                    {
                        baseSkills[i] += poy.BaseSkills[i];
                    }
                    break;

                case "characterBody":
                    Body bodyInfo = info as Body;
                    _sexText.text = bodyInfo._sex.ToString();
                    _hairTypeText.text = "Hair type: " + bodyInfo._hairType.ToString();
                    _hairLengthText.text = "Hair length: " + bodyInfo._hairLength.ToString();
                    _hairColorText.text = "Hair color: " + bodyInfo._hairColor;
                    _eyeColorText.text = "Eye color: " + bodyInfo._eyeColor;
                    _bodyTypeText.text = "Body type: " + bodyInfo._bodyType.ToString();
                    _heightText.text = "Height: " + bodyInfo._height.ToString("F2") + " cm";
                    _weightText.text = "Weight: " + bodyInfo._weight.ToString("F2") + " kg";
                    break;

                default:
                    break;
            }


            if (info.Name == "weapon")
            {
                BasicHoverable script = _itemTexts[itemNb].gameObject.GetComponent<BasicHoverable>();
                script._index = _sheetNb;
                script._fromLoadedSheet = _isLoadedSheet;
                script._name = "weapon";
            }

            if (info.Name == "armor")
            {
                BasicHoverable script = _itemTexts[itemNb].gameObject.GetComponent<BasicHoverable>();
                script._index = _sheetNb;
                script._fromLoadedSheet = _isLoadedSheet;
                script._name = "armor";
            }
            
            if (info.Name == "weapon" || info.Name == "armor")
            {
                _itemTexts[itemNb].text = info.Value;
                itemNb++;
            }

            if (info.Name == "characterTrait")
            {
                _traitTexts[traitNb].text = info.Value;
                BasicHoverable script = _traitTexts[traitNb].gameObject.GetComponent<BasicHoverable>();
                script._index = _sheetNb;
                script._fromLoadedSheet = _isLoadedSheet;
                script._name = "characterTrait";
                traitNb++;
            }

            for(int i = 0; i < _skillsTexts.Length; i++)
            {
                _skillsTexts[i].text = baseSkills[i].ToString();
            }
        }
    }
}