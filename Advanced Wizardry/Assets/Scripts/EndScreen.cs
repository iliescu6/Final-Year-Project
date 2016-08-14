using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {
    public Text end;
    public static bool won = false;
    // Update is called once per frame
    void Update()
    {
        //display if the player won or not 
            if (won)
            {
                end.color = Color.green;
                end.text = "You win!";
                won = true;
                Achievements.fifth = false;
            }
            else
            {
                end.color = Color.red;
                end.text = "You lose!";
            }
        }
    
    //return to main menu to quit or start a new game
    public void MainMenu() {
        Destroy(GameObject.Find("Achievements"));
        SceneManager.LoadScene("Main Menu");
    }
}
