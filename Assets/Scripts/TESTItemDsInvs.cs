using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTItemDsInvs : MonoBehaviour
{
    public SOItem[] TESTInventaire = new SOItem[20];
    public SOItem[] TESTRaffEntree = new SOItem[8];
    public SOItem[] TESTRaffSortie = new SOItem[8];

    Inventaire instanceInv;
    Raffinerie instanceRaff;

    private void Start()
    {
        instanceInv = GameObject.Find("Inventaire").GetComponent<Inventaire>();
        instanceRaff = GameObject.Find("Raffinerie").GetComponent<Raffinerie>();
    }

    private void Update()
    {
        for (int i = 0; i < TESTInventaire.Length; i++)
        {
            TESTInventaire[i] = instanceInv.tablInventaire[i].itemDsSlot;
        }

        for (int i = 0; i < TESTRaffEntree.Length; i++)
        {
            TESTRaffEntree[i] = instanceRaff.tablRaffEntree[i].itemDsSlot;
        }

        for (int i = 0; i < TESTRaffSortie.Length; i++)
        {
            TESTRaffSortie[i] = instanceRaff.tablRaffSortie[i].itemDsSlot;
        }
    }
}
