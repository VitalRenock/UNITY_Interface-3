using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Améliorer le nombre de fois que l'on fait apelle à la MajUI().
// BUG sur Raffinage quand on veut raffiner sans minerai ds le slot 0.

public class Raffinerie : MonoBehaviour
{
    #region SINGLETON
    public static Raffinerie instanceRaff;

    private void Awake()
    {
        if (instanceRaff != null)
        {
            Debug.LogWarning("Trop d'instance trouvée pour" + this.name);
            return;
        }
        instanceRaff = this;
    }
    #endregion

    public SOItem prefabLingotMetal;

    public GameObject grilleSlotsEntree;
    public GameObject grilleSlotsSortie;
    
    public Slot[] tablRaffEntree = new Slot[8];
    public Slot[] tablRaffSortie = new Slot[8];

    public MajUI UiMajInterfaces;


    private void Start()
    {
        UiMajInterfaces = GameObject.Find("Canvas").GetComponent<MajUI>();

        for (int i = 0; i < grilleSlotsEntree.transform.childCount; i++)
        {
            tablRaffEntree[i] = grilleSlotsEntree.transform.GetChild(i).GetComponent<Slot>();
        }

        for (int i = 0; i < grilleSlotsSortie.transform.childCount; i++)
        {
            tablRaffSortie[i] = grilleSlotsSortie.transform.GetChild(i).GetComponent<Slot>();
        }
    }

    public void MajInvERaff(int index)
    {
        Debug.Log("Début Maj Inv E Raffinerie() - Raffinerie");
        tablRaffEntree[index] = grilleSlotsEntree.transform.GetChild(index).GetComponent<Slot>();
        UiMajInterfaces.MajInterfaces();
    }

    public void MajInvSRaff(int index)
    {
        Debug.Log("Début Maj Inv S Raffinerie() - Raffinerie");
        tablRaffSortie[index] = grilleSlotsSortie.transform.GetChild(index).GetComponent<Slot>();
        UiMajInterfaces.MajInterfaces();
    }

    public void Raffinage()
    {
        for (int i = 0; i < tablRaffEntree.Length; i++)
        {
            if (tablRaffEntree[i] != null)
            {
                if(tablRaffEntree[i].itemDsSlot.nomItem == "Minerai de fer")
                {
                    if(SlotSortieLibre(out int index) == true)
                    {
                        Debug.Log("Je SUIS UN TEST" + index);
                        // TRANSACTION
                        tablRaffSortie[index].itemDsSlot = prefabLingotMetal;
                        tablRaffEntree[i].itemDsSlot = null;
                        MajInvERaff(i); //?
                        MajInvSRaff(index); //?
                    }
                    else { Debug.Log("Pas de place dans l'inventaire de sortie"); }
                }     
            }
            else { Debug.Log("Aucun minerai de fer dans l'inventaire d'entrée de la Raffinerie"); }
        }
    }

    public bool SlotSortieLibre(out int index)
    {
        bool slotTrouver = false;
        index = 0;

        for (int i = 0; i < tablRaffSortie.Length; i++)
        {
            if (tablRaffSortie[i].itemDsSlot == null)
            {
                slotTrouver = true;
                index = i;
                break;
            }
        }

        if(slotTrouver == false) { Debug.Log("Aucune place dans l'inventaire de sortie de la Raffinerie"); }

        return slotTrouver;
    }
}
