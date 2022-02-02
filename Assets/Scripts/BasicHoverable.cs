using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class BasicHoverable : MonoBehaviour
{
    [HideInInspector]
    public string _name;
    [HideInInspector]
    public int _index;
    [HideInInspector]
    public int _position;
    [HideInInspector]
    public bool _fromLoadedSheet;

    private BaseStuff _fatig;
    private List<BaseStuff> _fatigs = new List<BaseStuff>();
    string _moreInfo;

    public void UpdateInfoBox()
    {
        if (_fromLoadedSheet)
        {
            if(_name == "characterTrait")
            {
                _fatigs = GlobalManager.GameInstance._keptCharacters[_index].GetCharacteristics.FindAll(x => x.Name == _name);
            }

            if (_name == "weapon" || _name == "armor")
            {
                _fatigs = GlobalManager.GameInstance._keptCharacters[_index].GetCharacteristics.FindAll(x => (x.Name == "weapon" || x.Name == "armor"));
            }

            _fatig = GlobalManager.GameInstance._keptCharacters[_index].GetCharacteristics.Find(x => x.Name == _name);
        }
        else
        {
            if (_name == "characterTrait")
            {
                _fatigs = GlobalManager.GameInstance.GeneratedCharacters[_index].GetCharacteristics.FindAll(x => x.Name == _name);
            }

            if (_name == "weapon" || _name == "armor")
            {
                _fatigs = GlobalManager.GameInstance.GeneratedCharacters[_index].GetCharacteristics.FindAll(x => (x.Name == "weapon" || x.Name == "armor"));
            }

            _fatig = GlobalManager.GameInstance.GeneratedCharacters[_index].GetCharacteristics.Find(x => x.Name == _name);
        }

        if(_fatigs.Count == 0)
        {
            _moreInfo = _fatig.MoreInfo();
        }
        else
        {
            _moreInfo = _fatigs[_position].MoreInfo();
        }
    }

    public void OnMouseEnter()
    {
        if (_name != "")
        {
            UpdateInfoBox();

            GlobalManager.UIInstance.CreateInfoBox(GetComponent<RectTransform>(), _moreInfo);
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