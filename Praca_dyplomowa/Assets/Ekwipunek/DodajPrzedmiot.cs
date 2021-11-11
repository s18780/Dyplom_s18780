using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodajPrzedmiot : MonoBehaviour
{
    private const char V = 'e';
    public bool czyDodac;
    public bool openEkwipunek;
    public Item przedmiotDoDodania;
    public PasekManager pasek;
    public EkwipunekManager ekwipunek;  
    public GameObject ekwipunekShow;
    void PodniesPrzedmiot() 
    {
        ekwipunek.DodajPrzedmiot(przedmiotDoDodania);
        if (ekwipunek.Fulleq() == true)
        {
            pasek.DodajPrzedmiot(przedmiotDoDodania);
        }
      
    
        czyDodac = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (czyDodac == true) {
            PodniesPrzedmiot();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (openEkwipunek == false)
            {
                openEkwipunek = true;
                ekwipunekShow.SetActive(true);
            }
            else if (openEkwipunek == true)
            {
                openEkwipunek = false;
                ekwipunekShow.SetActive(false);
            }

        }

    }
}
