using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PasekManager : MonoBehaviour
{
    public Slot[] slotywEkwipunku;

    private void Start()
    {
        slotywEkwipunku = GetComponentsInChildren<Slot>();
    }
    public void DodajPrzedmiot(Item przedmiot)
    {
       
        for (int i = 0; i < slotywEkwipunku.Length; i++)
        {
            if (slotywEkwipunku[i].przedmiotWslocie == null)
            {
                slotywEkwipunku[i].DodajPrzedmiotDoSlotu(przedmiot);
                print(przedmiot);
                if (przedmiot.Equals("Bron")) {
                    print("mieczdwea");
                }
                break;
            }
            if (i == slotywEkwipunku.Length - 1)
            {
               
                Debug.LogError("pasek pełny");
            }
        }
    }
    public void CzyWybranaBron() {
        
    }
}
