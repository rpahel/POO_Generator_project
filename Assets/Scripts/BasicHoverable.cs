using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class BasicHoverable : MonoBehaviour
{
    //[HideInInspector]
    public string _name;
    //[HideInInspector]
    public int _index;
    public int _position;
    //[HideInInspector]
    public bool _fromLoadedSheet;

    BaseStuff fatig;
    string moreInfo;

    public void UpdateInfoBox()
    {
        if (_fromLoadedSheet)
        {
            if(_name == "characterTrait" || _name == "armor" || _name == "weapon")
            {
                // faire en sorte de prendre d'utiliser la position du texte pour retreouver le fatig correspondant (findall ?)
            }

            fatig = GlobalManager.GameInstance._keptCharacters[_index].GetCharacteristics.Find(x => x.Name == _name);
        }
        else
        {
            fatig = GlobalManager.GameInstance.GeneratedCharacters[_index].GetCharacteristics.Find(x => x.Name == _name);
        }

        moreInfo = fatig.MoreInfo();
    }

    public void OnMouseEnter()
    {
        if (_name != "")
        {
            UpdateInfoBox();

            GlobalManager.UIInstance.CreateInfoBox(GetComponent<RectTransform>(), moreInfo);
        }
    }

    public void OnMouseExit()
    {
        if (_name != "")
        {
            GlobalManager.UIInstance.DeleteInfoBox();
        }
    }
}