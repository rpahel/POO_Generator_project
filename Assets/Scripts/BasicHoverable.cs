using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHoverable : MonoBehaviour
{
    public string _name;
    public int _index;

    // On hover, va chercher le character à l'index ainsi que la classe contenant le name
    // demande à la classe de creer un string moreInfo avec toutes les infos essentielles
    // creer une boite sous le gameObject avec les infos essentielles lorsque la souris passe dessus
    // detruis la boite lorsque la souris sors
}