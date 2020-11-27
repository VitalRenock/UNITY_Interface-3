using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionJoueur : MonoBehaviour
{
    public SOItem itemChoisi;
    public SOItem item1;
    public SOItem item2;
    public SOItem item3;

    private void Start()
    {
        itemChoisi = item1;
    }

    void Update()
    {
        // Pour tester l'inventaire.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(itemChoisi != null)
            {
                if (Inventaire.instanceInv.AjoutItem(itemChoisi) == false) { Debug.LogWarning("Plus d'espace dans l'inventaire"); }
            }
            else { Debug.LogWarning("Choisir item d'abord"); }
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(itemChoisi == item1) { itemChoisi = item2; }
            else if(itemChoisi == item2) { itemChoisi = item3; }
            else if(itemChoisi == item3) { itemChoisi = item1; }
        }
    }

    
}
