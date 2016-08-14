using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Achievements : MonoBehaviour {

    public static bool firstAchiev = false, level1;
    public static bool first = false,second=false, third = false,forth = false, fifth = false;

	// Use this for initialization
	void Awake () {

        level1 = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (fifth == true)
        {
            Destroy(GameObject.Find("Canvas"));
            Destroy(GameObject.Find("FPSController(Clone)"));
            Destroy(GameObject.Find("Consumable Manager"));
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Ending");
            EndScreen.won = true;
            fifth = false;
        }else
        if (GameObject.Find("FPSController(Clone)") != null && Player.currentHP <= 0)
        {
            Destroy(GameObject.Find("Canvas"));
            Destroy(GameObject.Find("FPSController(Clone)"));
            Destroy(GameObject.Find("Consumable Manager"));
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Ending");
        }

        //Achievement completed when first 2 spells are picked
        if (Player.weapon[0] == true && Player.weapon[1] == true && firstAchiev==false && first !=true) {
            first = true;
            firstAchiev = true;
            Player.currentXP += 100;           
        }

	}
}
