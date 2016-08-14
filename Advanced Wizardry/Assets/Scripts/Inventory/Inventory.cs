using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{


    public static List<Item> slots = new List<Item>();
    public static List<Item> equips = new List<Item>();

    public static bool showToolTip = false;

    private bool inven = true;
    public static GameObject toolTip;
    public static GameObject[] slot,equip;
    public static GameObject invPanel;


    // Use this for initialization
    void Awake() {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            slot = new GameObject[44];
            equip = new GameObject[4];
            //Assign the slot objects to the slot array
            for (int i = 0; i < 44; i++)
            {
                slots.Add(new Item());
                slot[i] = GameObject.Find("Button (" + i.ToString() + ")");
            }

            for (int i = 0; i < 4; i++)
            {
                equips.Add(new Item());
            }
            //Assign game objects with these names to the equip array
            equip[0] = GameObject.Find("Head");
            equip[1] = GameObject.Find("Chest");
            equip[2] = GameObject.Find("Feet");
            equip[3] = GameObject.Find("Weapon");
            toolTip = GameObject.Find("ToolTip");
            invPanel = GameObject.Find("InventoryPanel");
        }
    }


    void Update()
    {

        if (SavaLoad.loaded == true)
        {
            Destroy(GameObject.Find("Canvas"));
            slot = new GameObject[44];
            equip = new GameObject[4];
            invPanel.SetActive(true);
            toolTip.SetActive(true);
            for (int i = 0; i < 44; i++)
            {
                slot[i] = GameObject.Find("Button (" + i.ToString() + ")");
            }
            //Assign game objects with these names to the equip array
            equip[0] = GameObject.Find("Head");
            equip[1] = GameObject.Find("Chest");
            equip[2] = GameObject.Find("Feet");
            equip[3] = GameObject.Find("Weapon");
            toolTip = GameObject.Find("ToolTip");
            //reference to the inventory panel
            invPanel = GameObject.Find("InventoryPanel");
            showToolTip = false;
            toolTip.SetActive(false);
            invPanel.SetActive(false);
            SavaLoad.loaded = false;
        }
        if (FreshGame.freshGame == true)
        {
            toolTip.SetActive(false);
            invPanel.SetActive(false);
        }
        if (showToolTip)
        {
            toolTip.SetActive(true);
        }
        else
        {
            toolTip.SetActive(false);
        }
        if (Input.GetButtonDown("Inventory"))
        {
            
            if (!inven && invPanel !=null)
            {
                invPanel.SetActive(false);
                Menu.pausebool = false;
            }
            else if(inven==true && invPanel !=null) {
                invPanel.SetActive(true);
                for (int i = 0; i < 44; i++)
                {
                    slot[i] = GameObject.Find("Button (" + i.ToString() + ")");
                }
                //Assign game objects with these names to the equip array
                equip[0] = GameObject.Find("Head");
                equip[1] = GameObject.Find("Chest");
                equip[2] = GameObject.Find("Feet");
                equip[3] = GameObject.Find("Weapon");
                Menu.pausebool = true;
            }
            inven = !inven;
        }

        if (inven)
        {
            for (int i = 0; i < 4; i++){
                if (equips[i].itemName != null && equip[i] != null) {
                    string temp = equips[i].itemName;
                    equip[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + temp);
                }
            } 
            for (int i = 0; i < 44; i++)
            {              
                if (slots[i].itemName != null && slot[i] !=null)
                {
                    //Get the name of the items in slot (list) and load the image for it on the slot (array/gameobject)
                    string temp=slots[i].itemName;
                    slot[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/"+temp);
                }
            }
        }
    }
}

  