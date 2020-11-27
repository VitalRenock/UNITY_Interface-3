using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvel item", menuName = "Item/Nouvel Item")]
public class SOItem : ScriptableObject
{
    new public string nomItem = "Nom par défaut";
    public Sprite iconeItem;

    public void ActionItem()
    {
        // Fonction à venir...
    }
}
