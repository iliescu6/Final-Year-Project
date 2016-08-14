using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Raycast : MonoBehaviour {
    private int rayHit = 0;
    public static bool change;


    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit item;
        //Raycast to detect items/pick-ups
        if (Physics.Raycast(transform.position, fwd, out item))
        {
            if (item.distance <= 3 && item.collider.gameObject.tag == "Scroll Fire")
            {
                rayHit = 1;
                if (Input.GetKeyDown("e"))
                {
                    Player.weapon[0] = true;
                    Managers.Inventory.AddItem(item.collider.gameObject.tag);
                    Destroy(item.collider.gameObject);
                    Player.castTime = Player.s1.CastingTime;
                    Player.manaCost = Player.s1.ManaCost;
                    Player.currentWeapon = 1;

                }
            }
            else if (item.distance <= 3 && item.collider.gameObject.tag == "Scroll Ice")
            {
                rayHit = 1;
                if (Input.GetKeyDown("e"))
                {
                    Player.weapon[1] = true;
                    Managers.Inventory.AddItem(item.collider.gameObject.tag);
                    Destroy(item.collider.gameObject);
                    Player.castTime = Player.s2.CastingTime;
                    Player.manaCost = Player.s2.ManaCost;
                    Player.currentWeapon = 2;
                    QuestScript.questComplete[0] = true;
                    QuestScript.briefQuest = 2;
                }
            }
            else if (item.distance <= 2 && item.collider.gameObject.tag == "Health")
            {
                rayHit = 2;
                if (Input.GetKeyDown("e"))
                {
                    Managers.Inventory.AddConsumable("Health");
                    Destroy(item.collider.gameObject);
                }
            }
            else

            //Finish gate
            if (item.distance <= 4 && item.collider.gameObject.tag == "Finish Level")
            {
                rayHit = 3;
                if (Input.GetKeyDown("e"))
                {
                    Application.LoadLevel("A_Star");
                    QuestScript.questComplete[1] = true;
                    QuestScript.briefQuest = 3;
                    Achievements.third = true;
                    change = true;
                }
            }
            else


            //Pick up item with info and add to inventory
                if (item.distance <= 5 && item.collider.gameObject.tag == "Item")
            {
                rayHit = 4;
                if (Input.GetKeyDown("e"))
                {
                    if (item.collider.gameObject.GetComponent<ItemInfo>().itemName == "Superior Chest") {
                        Achievements.second = true;
                    }
                    if (item.collider.gameObject.GetComponent<ItemInfo>().name == "Helmet")
                    {
                        Achievements.forth = true;
                    }
                    for (int i = 0; i < 44; i++) {
                        if (Inventory.slot[i].transform.GetChild(0).GetComponent<Image>().sprite.name == "blank" && i < 44)
                        {
                            //was unable to find a way to use a variable for the Enum type in the constructor and had to repeat code
                            string temp = item.collider.gameObject.GetComponent<ItemInfo>().type;
                            if (temp == "Chest")
                            {
                                Inventory.slots[i] = new Item(item.collider.gameObject.GetComponent<ItemInfo>().itemName, item.collider.gameObject.GetComponent<ItemInfo>().health,
                                    item.collider.gameObject.GetComponent<ItemInfo>().mana, item.collider.gameObject.GetComponent<ItemInfo>().healthRegen, item.collider.gameObject.GetComponent<ItemInfo>().manaRegen,
                                    Item.Type.Chest);
                                Destroy(item.collider.gameObject);
                                break;
                            }
                            else if (temp == "Head")
                            {
                                Inventory.slots[i] = new Item(item.collider.gameObject.GetComponent<ItemInfo>().itemName, item.collider.gameObject.GetComponent<ItemInfo>().health,
                                    item.collider.gameObject.GetComponent<ItemInfo>().mana, item.collider.gameObject.GetComponent<ItemInfo>().healthRegen, item.collider.gameObject.GetComponent<ItemInfo>().manaRegen,
                                    Item.Type.Head);
                                Destroy(item.collider.gameObject);
                                break;
                            }
                            else if (temp == "Feet")
                            {
                                Inventory.slots[i] = new Item(item.collider.gameObject.GetComponent<ItemInfo>().itemName, item.collider.gameObject.GetComponent<ItemInfo>().health,
                                    item.collider.gameObject.GetComponent<ItemInfo>().mana, item.collider.gameObject.GetComponent<ItemInfo>().healthRegen, item.collider.gameObject.GetComponent<ItemInfo>().manaRegen,
                                    Item.Type.Feet);
                                Destroy(item.collider.gameObject);
                                break;
                            }
                            else if (temp == "Weapon")
                            {
                                Inventory.slots[i] = new Item(item.collider.gameObject.GetComponent<ItemInfo>().itemName, item.collider.gameObject.GetComponent<ItemInfo>().health,
                                    item.collider.gameObject.GetComponent<ItemInfo>().mana, item.collider.gameObject.GetComponent<ItemInfo>().healthRegen, item.collider.gameObject.GetComponent<ItemInfo>().manaRegen,
                                    Item.Type.Weapon);
                                Destroy(item.collider.gameObject);
                                break;
                            }
                        } 
                    }               
                }               
            }
            else
            {
                rayHit = 0;
            }
        }
    }


	void OnGUI(){
        //Information is shown based on the value of rayhit
		if (rayHit == 1) {
			GUI.Box (new Rect (Screen.width / 2-50, Screen.height / 2-25, 100, 50), "Pick Scroll");
		}else
        if (rayHit == 2)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Pick Health");
        }else
        if (rayHit == 3)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Finish Level");
        }
        else
        if (rayHit == 4)
        {
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Pick up item");
        }
    }
}
	