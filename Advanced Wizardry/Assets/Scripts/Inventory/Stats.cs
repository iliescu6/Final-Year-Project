using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    private Text info;

    void Start() {
        info = transform.GetComponent<Text>();
    }
	// Update is called once per frame
	void Update () {

        info.text = "Level: " + (Player.lvl + 1)+"\n";
        info.text = info.text + "Max Health: "+Player.maxHP+ "\n";
        info.text = info.text + "Max Mana: " + Player.maxMana + "\n";
        info.text = info.text + "HP Regen: " + Player.hpRegen.ToString("F2") + "\n";
        info.text = info.text + "Mana Regen: " + Player.manaRegen.ToString("F2");
	}
}
