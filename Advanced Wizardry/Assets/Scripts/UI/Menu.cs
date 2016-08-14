using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    private GameObject pause, achievements_panel;

    //GameObjects achievements for color change
    private GameObject first, second, third, forth, fifth;

    private bool achievements;
    public static bool pausebool, introMenuBool = true;
    public GameObject player,canvas,eventSystem,consumableManager;

    // Use this for initialization
    void Awake()
    {
        //run this only if it isn't the first scene
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            pausebool = true;
            achievements = false;
            introMenuBool = false;
            


            if (GameObject.Find("Canvas") != null )
            {
                pause = GameObject.Find("Pause");
                first = GameObject.Find("First");
                second = GameObject.Find("Second");
                third = GameObject.Find("Third");
                forth = GameObject.Find("Forth");
                fifth = GameObject.Find("Fifth");
            }

            achievements_panel = GameObject.Find("Menus/Achievements");

                

            if (SavaLoad.loaded == false)
            {
                pause.SetActive(false);
                
            }
            else if(SavaLoad.loaded == true) {

                pause.SetActive(true);
                first.SetActive(false);
                second.SetActive(false);
                third.SetActive(false);
                forth.SetActive(false);
                fifth.SetActive(false);
                achievements_panel.SetActive(false);
                
            }
        }
    }

    //create new game
    public void NewGame() {
        Application.LoadLevel("Level1");
        FreshGame.freshGame = true;

    }
    //resume game
    public void Resume()
    {
        if (pause != null)
        {
            pause.SetActive(false);
            pausebool = false;
        }
        else if (pause == null) {
            pause = GameObject.Find("Pause");
            pause.SetActive(false);
            pausebool = false;
        }
    }

    public void AchievementsMethod()
    {
        pause.SetActive(false);
        achievements = true;
    }

    public void BackFromAchievements()
    {
        pause.SetActive(true);
        achievements_panel.SetActive(false);
        achievements = false;
    }


    public void Quit() {
        Application.Quit();
    }

    //If a prefab was created, the old object is destroyed and the prefab's name changes to be the same as the old one
    public void FindAndReplace(string x)
    {
        if (GameObject.Find(x+"(Clone)") != null)
        {
            Destroy(GameObject.Find("/"+x));
            GameObject.Find(x + "(Clone)").name = x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            //Check if object are null after load, if they are null create the references again
            if (pause == null)
            {
                pause = GameObject.Find("Pause");
            }

            //delete the old objects and rename the new ones
            FindAndReplace("Canvas");
            FindAndReplace("Achievements");
            FindAndReplace("Consumable Manager");

            if (FreshGame.freshGame == true )
            {
                Instantiate(player, GameObject.Find("StartingPosition").transform.position, GameObject.Find("StartingPosition").transform.rotation);

                Inventory.toolTip.SetActive(false);
                Inventory.invPanel.SetActive(false);

                FreshGame.freshGame = false;
                
                pausebool = false;
                achievements_panel.SetActive(false);
            }

            if (Input.GetKeyDown("escape"))
            {
                pausebool = !pausebool;
                if (pausebool && pause != null)
                {
                    pause.SetActive(true);
                }
                else if (!pausebool && pause != null)
                {
                    pause.SetActive(false);
                }
                
            }
            //cursor becomes visible and time stops
            if (pausebool == true)
            {
                Cursor.visible = true;
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None;
            }
            //cursor is invisible and always in the middle
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1.0f;
            }
            //if the achievements menu is on check what achievements are completed and change their color
            if (achievements == true)
            {
                achievements_panel.SetActive(true);              
                first.SetActive(true);
                second.SetActive(true);
                third.SetActive(true);
                forth.SetActive(true);
                fifth.SetActive(true);
                Debug.Log(Achievements.first);
                if (Achievements.first == true)
                {
                    first.GetComponent<Image>().color = Color.green;
                }
                if (Achievements.second == true)
                {
                    second.GetComponent<Image>().color = Color.green;
                }
                if (Achievements.third == true)
                {
                    third.GetComponent<Image>().color = Color.green;
                }
                if (Achievements.forth == true)
                {
                    forth.GetComponent<Image>().color = Color.green;
                }
                if (Achievements.fifth == true)
                {
                    fifth.GetComponent<Image>().color = Color.green;
                }
            }
        }
    }
}
   