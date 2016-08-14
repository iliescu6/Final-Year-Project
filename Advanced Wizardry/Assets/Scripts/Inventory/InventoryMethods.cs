using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryMethods : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public void EquipChange()
    {
        //Get the current gameObject to verify it's name
        GameObject button;
        button = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
        
        
        for(int j = 0; j < 4; j++) { 
        for (int i = 0; i < 44; i++)
        {

                GameObject temp = Inventory.slot[i];
            if (button.name == temp.name )
            {
                if (button.transform.GetChild(0).GetComponent<Image>().sprite.name != "blank")
                {
                    //Get the type of item to determine where to equip it
                    string temp2 = Inventory.slots[i].type.ToString();

                    //Find the equip type button
                    GameObject temp3 = GameObject.Find(temp2);


                    if (temp2 == Inventory.equip[j].name && temp3.transform.GetChild(0).GetComponent<Image>().sprite.name == "blank")
                    {
                        Inventory.equips[j] = Inventory.slots[i];
                        ChangeImage(i, temp3, button);
                        AddStats(i);
                        Inventory.slots[i] = new Item();
                            Inventory.showToolTip = false;
                            break;
                    }
                    else if (temp2 == Inventory.equip[j].name && temp3.transform.GetChild(0).GetComponent<Image>().sprite.name != "blank")
                    {
                        Item t;
                        string tempN;
                            TakeStats(j);
                            AddStats(i);
                            //Switch image between equip and slot if there's already an equiped item
                            tempN = temp3.transform.GetChild(0).GetComponent<Image>().sprite.name;
                            temp3.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + Inventory.slots[i].itemName); //change equip image 
                            button.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + tempN);
                            t = Inventory.equips[j];
                        Inventory.equips[j] = Inventory.slots[i];
                        Inventory.slots[i] = t;

                        ToolTip.itemname = Inventory.slots[i].itemName;
                        ToolTip.health = Inventory.slots[i].health;
                        ToolTip.mana = Inventory.slots[i].mana;
                        ToolTip.mRegen = Inventory.slots[i].manaRegen;
                        ToolTip.hRegen = Inventory.slots[i].healthRegen;

                        
                            break;

                    }

                }
            }
        }
    }
    }

    public void Unequip() {
        
       GameObject button = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
        if (button.transform.GetChild(0).GetComponent<Image>().sprite.name != "blank")
        {
            for (int i = 0; i < 4; i++) {
                if (button.name == Inventory.equip[i].name) {
                    for (int j = 0; j < 44; j++) {
                        if (Inventory.slot[j].transform.GetChild(0).GetComponent<Image>().sprite.name == "blank") {
                            Inventory.slots[j] = Inventory.equips[i];
                            TakeStats(i);
                            Inventory.slot[j].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + Inventory.equips[i].itemName);
                            Inventory.equip[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/blank");
                            Inventory.equips[i] = new Item();
                            Inventory.showToolTip = false;
                            break;
                        }
                    }
                }
            }

        }
        }
    public void OnPointerEnter(PointerEventData evenData) {
        PoPUp();
    }

    public void OnPointerExit(PointerEventData evenData)
    {
        Inventory.showToolTip = false;
    }



    public void ChangeImage(int i,GameObject t,GameObject b) {
        t.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + Inventory.slots[i].itemName); //change equip image 
        b.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Blank");
        

    }

    private void AddStats(int i) {
        Player.maxHP += Inventory.slots[i].health;
        Player.maxMana += Inventory.slots[i].mana;
        Player.manaRegen += Inventory.slots[i].manaRegen;
        Player.hpRegen += Inventory.slots[i].healthRegen;
    }

    private void TakeStats(int i)
    {
        Player.maxHP -= Inventory.equips[i].health;
        Player.maxMana -= Inventory.equips[i].mana;
        Player.manaRegen -= Inventory.equips[i].manaRegen;
        Player.hpRegen -= Inventory.equips[i].healthRegen;
    }

    public void PoPUp()
    {

        for (int i = 0; i < 44; i++)
        {
            if (Inventory.slot[i] != null) { 
            GameObject temp = Inventory.slot[i];
            if (transform.name == temp.name)
            {
                    if (transform.GetChild(0).GetComponent<Image>().sprite.name != "blank")
                    {
                        Inventory.showToolTip = true;
                        ToolTip.itemname = Inventory.slots[i].itemName;
                        ToolTip.health = Inventory.slots[i].health;
                        ToolTip.mana = Inventory.slots[i].mana;
                        ToolTip.mRegen = Inventory.slots[i].manaRegen;
                        ToolTip.hRegen = Inventory.slots[i].healthRegen;
                        break;
                    }
                }
            }
        }
        for (int j = 0; j < 4; j++)
        {
            Item temp = Inventory.equips[j];
            if (transform.name == temp.type.ToString())
            {

                if (transform.GetChild(0).GetComponent<Image>().sprite.name != "blank")
                {
                    Inventory.showToolTip = true;
                    ToolTip.itemname = Inventory.equips[j].itemName;
                    ToolTip.health = Inventory.equips[j].health;
                    ToolTip.mana = Inventory.equips[j].mana;
                    ToolTip.mRegen = Inventory.equips[j].manaRegen;
                    ToolTip.hRegen = Inventory.equips[j].healthRegen;
                    break;
                }
            }
        }
    }   
}