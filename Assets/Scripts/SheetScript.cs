using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SheetScript : MonoBehaviour
{
    [HideInInspector]
    public int _sheetNb;

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
    [Space(20)]

    [Header("Equipment")]
    public TMP_Text _item1Text;
    public TMP_Text _item2Text;
    public TMP_Text _item3Text;
    public TMP_Text _item4Text;
    public TMP_Text _item5Text;
    [Space(20)]

    [Header("Trait")]
    public TMP_Text _trait1Text;
    public TMP_Text _trait2Text;
    public TMP_Text _trait3Text;
    public TMP_Text _trait4Text;
    public TMP_Text _trait5Text;

    private void Start()
    {
        //
    }
}