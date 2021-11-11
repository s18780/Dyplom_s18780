using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NowyPrzedmiot", menuName="Ekwipunek/NowyPrzedmiot")]
public class Item : ScriptableObject
{
    public int id;
    public string nazwa = "nowy przedmiot";
    public Sprite ikona = null;
    public TypPrzedmiotu typPrzedmiotu = TypPrzedmiotu.Inne;
    public enum TypPrzedmiotu { 
    Jedzenie,
    Bron,
    Inne,
    }
}
