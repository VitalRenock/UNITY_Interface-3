using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajUI : MonoBehaviour
{
    Inventaire instanceInv;
    Raffinerie instanceRaff;

    public Event eventActuel;
    public Vector2 mousePos;
    public Vector2 offsetIcone;

    private void Start()
    {
        instanceInv = Inventaire.instanceInv;
        instanceRaff = Raffinerie.instanceRaff;
    }

    private void OnGUI()
    {
        eventActuel = Event.current;
        mousePos.x = eventActuel.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - eventActuel.mousePosition.y;
        mousePos -= offsetIcone;
    }

    public void MajInterfaces()
    {
        MajUiInventaire();
        MajUiRaffinerie();
    }

    public void MajUiInventaire()
    {
        Debug.Log("Début MajUIInventaire() - Inventaire");
        for (int i = 0; i < instanceInv.tablInventaire.Length; i++)
        {
            if (instanceInv.tablInventaire[i].itemDsSlot != null)
            {
                instanceInv.tablInventaire[i].MajIconeSlot(instanceInv.tablInventaire[i].itemDsSlot.iconeItem);
            }
            else { instanceInv.tablInventaire[i].SupIconeItem(); }
        }
    }

    public void MajUiRaffinerie()
    {
        Debug.Log("Début MajUIRaffinerie() - Raffinerie");
        for (int i = 0; i < instanceRaff.tablRaffEntree.Length; i++)
        {
            if (instanceRaff.tablRaffEntree[i].itemDsSlot != null)
            {
                instanceRaff.tablRaffEntree[i].MajIconeSlot(instanceRaff.tablRaffEntree[i].itemDsSlot.iconeItem);
            }
            else { instanceRaff.tablRaffEntree[i].SupIconeItem(); }
        }

        for (int i = 0; i < instanceRaff.tablRaffSortie.Length; i++)
        {
            if (instanceRaff.tablRaffSortie[i].itemDsSlot != null)
            {
                instanceRaff.tablRaffSortie[i].MajIconeSlot(instanceRaff.tablRaffSortie[i].itemDsSlot.iconeItem);
            }
            else { instanceRaff.tablRaffSortie[i].SupIconeItem(); }
        }
    }

}
