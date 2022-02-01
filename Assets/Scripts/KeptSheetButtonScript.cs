using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeptSheetButtonScript : MonoBehaviour
{
    [HideInInspector]
    public int _buttonNb;

    public void Select()
    {
        GlobalManager.UIInstance.LoadKeptSheet(_buttonNb);
    }
}
