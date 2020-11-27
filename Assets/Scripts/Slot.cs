using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bug sur la position de l'icone quand icone déplacer en dehors d'un slot.
// Voir surement avec la méthode EndDrag().

public class Slot : MonoBehaviour
{
    public SOItem itemDsSlot;
    public int indexSlot;

    Color couleurSlot;
    public Color couleurSurvol;

    // Position curseur/icone
    public MajUI scriptMajUI;
    

    private void Start()
    {
        indexSlot = this.transform.GetSiblingIndex();

        // Position curseur/icone
        scriptMajUI = GameObject.Find("Canvas").GetComponent<MajUI>();

        couleurSlot = this.GetComponent<Image>().color;
    }

    public void MajIconeSlot(Sprite iconeRecu)
    {
        //Debug.Log("Début MajIconeSlot() - " + this.transform.parent.parent.name);
        this.transform.GetChild(0).GetComponent<Image>().sprite = iconeRecu;
        this.transform.GetChild(0).GetComponent<Image>().enabled = true;
    }

    public void SupIconeItem()
    {
        //Debug.Log("Début SupIconeSlot() - " + this.transform.parent.parent.name);
        this.transform.GetChild(0).GetComponent<Image>().sprite = null;
        this.transform.GetChild(0).GetComponent<Image>().enabled = false;
    }

    public void SurvolSlot()
    {
        Inventaire.instanceInv.slotSurvoler = this;
        this.GetComponent<Image>().color = couleurSurvol;

    }

    public void EndSurvolSlot()
    {
        Inventaire.instanceInv.slotSurvoler = null;
        this.GetComponent<Image>().color = couleurSlot;
    }

    public void BeginDragSlot()
    {
        Debug.Log("Début BeginDragSlot()");
        Inventaire.instanceInv.slotDrager = this;
    }

    public void DragSlot()
    {
        Debug.Log("Début DragSlot()");

        // Position curseur/icone
        if (scriptMajUI.eventActuel != null) { this.transform.GetChild(0).position = scriptMajUI.mousePos; }
        else { Debug.Log("EVENT est vide"); }
    }

    public void EndDragSlot()
    {
        if (Inventaire.instanceInv.DragItem())
        {
            Inventaire.instanceInv.slotDrager = null;
        }
        else
        {
            Debug.LogWarning("Impossible de Drag");
        }

        // Position curseur/icone
        this.transform.GetChild(0).localPosition = Vector3.zero;
        Debug.Log("Fin EndDragSlot()");
    }
}
