using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    private Text info;
    public static float mana=0, health=0, hRegen=0, mRegen=0;
    public static string itemname="";

    void Start() {
        info = transform.GetComponentInChildren<Text>();
    }

	// Update is called once per frame
	void Update () {

        transform.position =new Vector3 (Input.mousePosition.x+75,Input.mousePosition.y-85,Input.mousePosition.z);
        //If the tooltip appears it will have its information updated
        if (Inventory.showToolTip) {

            info.text = itemname + "\n";
            if (health != 0) {
                info.text =info.text+ "Health: " + health.ToString("0") + "\n";
            }
            if (mana != 0) {
                info.text = info.text + "Mana: " + mana.ToString("0") + "\n";
            }
            if (hRegen != 0) {
                info.text = info.text + "Health Regen: " + hRegen.ToString("F2") + "\n";
            }
            if (mRegen != 0) {
                info.text = info.text + "Mana Regen: " + mRegen.ToString("F2") + "\n";
            }
        }   
}
}
