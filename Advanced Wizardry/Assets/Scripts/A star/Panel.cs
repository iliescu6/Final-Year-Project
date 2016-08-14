using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {

    private GameObject[] wall=new GameObject[31];
    private bool[] press = new bool[31];
    private GameObject[] button = new GameObject[31];
    private bool reset = false,start=true;
    public static bool move = false;


    Ray ray;
    RaycastHit hit;

	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 31; i++)
        {
            //Save the wall and button game object in their respective array and position
            string temp = "/Walls/Wall_unit" + i;
            string temp2 = "/Panel/Buttons/Button" + i;
            wall[i] = GameObject.Find(temp);
            button[i] = GameObject.Find(temp2);
        }


        if (start == true)
        {
            for (int i = 0; i < 31; i++)
            {
                press[i] = false;
            }
            start = false;
        }

        if (Input.GetKeyDown("e"))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < 31; i++)
                {
                    //If the ray hits a button that wasn't pushed 
                    //it'll change its position by subtractiong 0.2 and setting the boolean with the same position in the bool array to true
                    //otherwise it will add to it 0.2 and change the bool to false
                    string temp = "Button" + i;
                    if (hit.collider.name == temp && press[i] == false)
                    {
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z - 0.2f);
                        press[i] = true;
                        wall[i].transform.position= new Vector3(wall[i].transform.position.x, wall[i].transform.position.y-4, wall[i].transform.position.z);
                        wall[i].layer = 0;
                        wall[i].transform.GetChild(0).gameObject.layer = 0;
                        wall[i].transform.GetChild(1).gameObject.layer = 0;
                        wall[i].transform.GetChild(2).gameObject.layer = 0;

                        reset = true;
                    }
                    else
                    if (hit.collider.name == temp && press[i] == true)
                    {
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z + 0.2f);
                        press[i] = false;
                        wall[i].transform.position = new Vector3(wall[i].transform.position.x, wall[i].transform.position.y + 4, wall[i].transform.position.z);
                        wall[i].layer = 8;
                        wall[i].transform.GetChild(0).gameObject.layer = 8;
                        wall[i].transform.GetChild(1).gameObject.layer = 8;
                        wall[i].transform.GetChild(2).gameObject.layer = 8;
                    }
                }
                //Check if the reset button was hit by the ray
                //if so check the boolean array to see which button have to be reseted
                if (hit.collider.name == "Reset" && reset==true)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        if (press[j] == true)
                        {
                            button[j].transform.position = new Vector3(button[j].transform.position.x, button[j].transform.position.y, button[j].transform.position.z + 0.2f);
                            press[j] = false;
                            wall[j].transform.position = new Vector3(wall[j].transform.position.x, wall[j].transform.position.y + 4, wall[j].transform.position.z);
                            wall[j].layer = 8;
                            wall[j].transform.GetChild(0).gameObject.layer = 8;
                            wall[j].transform.GetChild(1).gameObject.layer = 8;
                            wall[j].transform.GetChild(2).gameObject.layer = 8;
                        }
                    }
                    reset = false;
                }
                //Move becomes true and a path is created
                if (hit.collider.name == "Move") {
                    move = true;
                }


            }
        }
    
	}
}
