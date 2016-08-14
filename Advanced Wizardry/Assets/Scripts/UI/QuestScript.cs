using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuestScript : MonoBehaviour {

    public static int quest,briefQuest;
    public static bool[] questComplete;
    private string[] paragraph;
    private GameObject[] buttonQuest;
    private GameObject questPanel;
    public static bool questLogOnOff = true;
    private Text textQ,briefQ;
    // Update is called once per frame

    void Awake() {
        questComplete = new bool[2];
        questComplete[0] = false;
        questComplete[1] = false;
        paragraph = new string[10];
        buttonQuest = new GameObject[2];
        buttonQuest[0] = GameObject.Find("Quest 2");      
        buttonQuest[1] = GameObject.Find("Quest 3");

        buttonQuest[0].SetActive(false);
        buttonQuest[1].SetActive(false);

        briefQ = GameObject.Find("Brief Quest").GetComponent<Text>();
        quest = 1;
        briefQuest = 1;

        //Quest 1 description
        //First Part
        paragraph[0] = "-Pick up the fire and ice scrolls-" + "\n" + "\n" +
            "You can use the E key to interact with or pick up items from the world"+"\n"+"\n";
        paragraph[1] = "-Use your spells to advance-"+"\n"+"\n"+
            "Some objects can react to your spells.Use the fire spell (key 1) to light up the torch and lower the platform.Use the ice spell (key 2) to make the platform return to its initial position.";
        paragraph[2] ="-Create a bridge to finish the level-" + "\n" + "\n" +
            "Use your spells to move the platforms and finish the level.";
        paragraph[3] = "-Create a path-" + "\n" + "\n" + "You can change the state of the white blocks from unwalkable to walkable from the panel.The black ones can't be changed.Use the panel to create a path and once you are done,press the green button to move the object to its destination.";

        textQ = GameObject.Find("Quest Info").GetComponent<Text>();
        questPanel = GameObject.Find("QuestLog");
        questPanel.SetActive(false);
        questLogOnOff = false;

    }
    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex > 0 && briefQ == null) {
            briefQ=GameObject.Find("Brief Quest").GetComponent<Text>();
        }
            
                if (Input.GetKeyDown("q"))
        {
            if (questLogOnOff == false)
            {
                questPanel.SetActive(true);
                questLogOnOff = true;
                Menu.pausebool = true;
            }
            else
            {
                questPanel.SetActive(false);
                questLogOnOff = false;
                Menu.pausebool = false;
            }
        }
        if (questComplete[0] == true)
        {
            buttonQuest[0].SetActive(true);
        }
        if (questComplete[1] == true)
        {
            buttonQuest[1].SetActive(true);
        }

        if (quest == 1)
        {
            textQ.text = paragraph[0] + paragraph[1];    

        }
        else if (quest == 2)
        {

            textQ.text = paragraph[2];
            
        }
        else if (quest == 3)
        {
            textQ.text = paragraph[3];
            briefQ.text = "-Create a path";
        }
        switch (briefQuest) {
            case 1:
                briefQ.text = "-Pick up the fire and ice spells" + "\n" + "(use the E key to pick up items)";
                break;
            case 2:
                briefQ.text = "-Create a bridge using your spells to move the platforms";
                break;
            case 3:
                briefQ.text = "-Create a path";
                break;
        }

    }

    public void ChangeQuest() {
        for (int i = 1; i < 4; i++) {
            string temp = "Quest " + i;
            if (temp == EventSystem.current.currentSelectedGameObject.name) {
                quest = i;
            }
        }
    }
}
