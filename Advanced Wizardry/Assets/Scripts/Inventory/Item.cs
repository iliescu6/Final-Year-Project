using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Item  {
    public string itemName;
    public float health;
    public float mana;
    public float healthRegen;
    public float manaRegen;
    public Type type;


    public  enum Type {
        Head,
        Chest,
        Feet,
        Weapon
    }


    public Item (string name, float hp, float m, float hr, float mr,Type t) {
    itemName = name;
    health = hp;
    mana = m;
    healthRegen = hr;
    manaRegen = mr;
    type = t;

}
    public Item() {}
    }