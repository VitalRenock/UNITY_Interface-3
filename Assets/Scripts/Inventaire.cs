using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    #region SINGLETON
    public static Inventaire instanceInv;

    private void Awake()
    {
        if (instanceInv != null)
        {
            Debug.LogWarning("Trop d'instance trouvée pour" + this.name);
            return;
        }
        instanceInv = this;
    }
    #endregion

    public Slot slotSurvoler;
    public Slot slotDrager;

    public GameObject grilleSlots;

    public Slot[] tablInventaire = new Slot[20];

    public MajUI UiMajInterfaces;


    private void Start()
    {
        UiMajInterfaces = GameObject.Find("Canvas").GetComponent<MajUI>();

        for (int i = 0; i < grilleSlots.transform.childCount; i++)
        {
            tablInventaire[i] = grilleSlots.transform.GetChild(i).GetComponent<Slot>();
        }
    }

    public void MajInventaire(int index)
    {
        Debug.Log("Début MajInventaire() - Inventaire");
        tablInventaire[index] = grilleSlots.transform.GetChild(index).GetComponent<Slot>();
        UiMajInterfaces.MajInterfaces();
    }

    public bool AjoutItem(SOItem itemRecu)
    {
        Debug.Log("Début AjoutItem() - Inventaire");
        bool slotVideTrouver = false;
        for (int i = 0; i < tablInventaire.Length; i++)
        {
            if (tablInventaire[i].itemDsSlot == null)
            {
                // TRANSACTION
                tablInventaire[i].itemDsSlot = itemRecu;
                slotVideTrouver = true;
                
                // MAJ UI
                UiMajInterfaces.MajInterfaces();

                break;
            }
        }
        return slotVideTrouver;
    }

    public bool DragItem()
    {
        Debug.Log("Début DragItem() - Inventaire");
        if(slotSurvoler != null && slotSurvoler.itemDsSlot == null)
        {
            slotSurvoler.itemDsSlot = slotDrager.itemDsSlot;
            slotDrager.itemDsSlot = null;

            if (slotSurvoler.transform.parent.parent.name == "Inventaire")
            {
                MajInventaire(slotSurvoler.indexSlot);
            }

            else if (slotSurvoler.transform.parent.parent.name == "Raffinerie")
            {
                Raffinerie.instanceRaff.MajInvERaff(slotSurvoler.indexSlot);
            }

            if (slotDrager.transform.parent.parent.name == "Inventaire")
            {
                MajInventaire(slotDrager.indexSlot);
            }

            else if (slotDrager.transform.parent.parent.name == "Raffinerie")
            {
                Raffinerie.instanceRaff.MajInvERaff(slotDrager.indexSlot);
            }
            return true;
        }
        else { return false; }
    }
}
