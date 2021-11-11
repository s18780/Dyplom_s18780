using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject przedmiotWslocie {
        get {
            if (transform.childCount > 0) {

                return transform.GetChild(0).gameObject;
            }return null;
        
        }
    }
    public GameObject prefabItem;
    public void DodajPrzedmiotDoSlotu(Item przedmiot) {
        GameObject newItem = Instantiate(prefabItem);
        newItem.transform.SetParent(this.transform);
        newItem.GetComponent<ItemPrefab>().item = przedmiot;
        newItem.GetComponent<Image>().sprite = przedmiot.ikona;
        
    }
  

    public void OnDrop(PointerEventData eventData)
    {
        if (przedmiotWslocie == null)
        {
            ItemPrefab.iteminSlot.transform.SetParent(this.transform, false);
            ItemPrefab.ifDrop = true;
            ItemPrefab.iteminSlot.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
