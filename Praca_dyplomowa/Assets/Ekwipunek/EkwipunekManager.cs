using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EkwipunekManager : MonoBehaviour
{
    public Slot[] slotywEkwipunku;
    bool full = false;
    private void Start() {
        slotywEkwipunku = GetComponentsInChildren<Slot>();
    }
    public void DodajPrzedmiot(Item przedmiot) {
        full = false;
        for (int i = 0; i < slotywEkwipunku.Length; i++) {
            if (slotywEkwipunku[i].przedmiotWslocie == null) {
                slotywEkwipunku[i].DodajPrzedmiotDoSlotu(przedmiot);
                break;
            }
            if (i == slotywEkwipunku.Length-1) {
                Debug.LogError("Ekwipunek pełny");
                full = true;
            }
        }
    }

    public bool Fulleq(){ return full; }
}
