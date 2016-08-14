using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


//The save and load method for simple variables was inspired by https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/persistence-data-saving-loading, accessed on 9th of April 2016
// The instantiation of new prefab and destroying the old ones was done by me, however the method used for the Canvas, Resources.Load("Canvas") was used after someone
//recommended it on the unity forums: http://forum.unity3d.com/threads/reference-to-prefab-changing-to-clone-self-reference.57312/ - KyleStaves, accessed on 15th of April 2016
public class SavaLoad : MonoBehaviour {

    public GameObject player,canvas,achievements,consumableMangager;
    public static bool loaded=false;
    private GameObject playerDestroy,eventSystemDestroy;


    //Saving values to GameData object
    public void Save()
    {
       BinaryFormatter bf = new BinaryFormatter();
       FileStream file = File.Create(Application.persistentDataPath + "/saves.dat");
        
        //Player info
        GameData data = new GameData();
        data.manaCost = Player.manaCost;
        data.maxHp = Player.maxHP;
        data.maxMana = Player.maxMana;
        data.currentMaxXP = Player.currentMaxXP;
        data.currentXP = Player.currentXP;
        data.lvl = Player.lvl;
        //Bools
        data.damaged = Player.damaged;
        data.casting = Player.casting;
        data.lvled = Player.lvled;
        //Floats
        data.castTime = Player.castTime;
        data.bPressed = Player.bPressed;
        data.currentHP = Player.currentHP;
        data.hpRegen = Player.hpRegen;
        data.manaRegen = Player.manaRegen;
        data.currentMana = Player.currentMana;
        data.currentXP = Player.currentXP;
        data.weapon[0] = Player.weapon[0];
        data.weapon[1] = Player.weapon[1];
        data.currentWeapon = Player.currentWeapon;
        data.scene = SceneManager.GetActiveScene().name;
        data.x = GameObject.Find("FPSController(Clone)").transform.position.x;
        data.y = GameObject.Find("FPSController(Clone)").transform.position.y;
        data.z = GameObject.Find("FPSController(Clone)").transform.position.z;

        //Inventory
        for (int i = 0; i < 44; i++) {
            data.slots.Insert(i,Inventory.slots[i]);
        }

        for (int i = 0; i < 4; i++) {
            data.equips.Insert(i,Inventory.equips[i]);
        }

        //Achiev
        data.first = Achievements.first;
        data.second = Achievements.second;
        data.third = Achievements.third;
        data.forth = Achievements.forth;
        data.fifth = Achievements.fifth;


        bf.Serialize(file, data);
        file.Close();
    }
    //Loading values from the saved file to the new game objects
    public void Load(){
        if (File.Exists(Application.persistentDataPath + "/saves.dat")) {

            Destroy(GameObject.Find("FPSController(Clone)"));
            Destroy(GameObject.Find("/Achievements"));
            Destroy(GameObject.Find("Consumable Manager"));

            if (GameObject.Find("Canvas") != null)
            {
                Destroy(GameObject.Find("Canvas"));
            }
            BinaryFormatter bf =new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saves.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            //Player info
            SceneManager.LoadScene(data.scene, LoadSceneMode.Single);
            Instantiate(player, new Vector3(data.x,data.y,data.z), GameObject.Find("StartingPosition").transform.rotation);
            Instantiate(achievements, Vector3.zero, Quaternion.identity);
            Instantiate(consumableMangager, Vector3.zero, Quaternion.identity);
            Instantiate(Resources.Load("Canvas"), Vector3.zero,Quaternion.identity);
            
            Player.manaCost = data.manaCost;
            Player.maxHP = data.maxHp;
            Player.maxMana = data.maxMana;
            Player.currentMaxXP = data.currentMaxXP;
            Player.currentXP = data.currentXP;
            Player.lvl = data.lvl;
            //Bools
            Player.damaged = data.damaged;
            Player.casting = data.casting;
            Player.lvled = data.lvled;
            //Floats
            Player.castTime = data.castTime;
            Player.bPressed = data.bPressed;
            Player.currentHP = data.currentHP;
            Player.hpRegen = data.hpRegen;
            Player.manaRegen = data.manaRegen;
            Player.currentMana = data.currentMana;
            Player.weapon[0] = data.weapon[0];
            Player.weapon[1] = data.weapon[1];
            Player.currentWeapon = data.currentWeapon;
            //position
            Player.loadPos=new Vector3(data.x,data.y,data.z);

            //Inventory
            for (int i = 0; i < 44; i++)
            {
                Inventory.slots[i] = data.slots[i];
            }

            for (int i = 0; i < 4; i++)
            {
                Inventory.equips[i] = data.equips[i];
            }
            //Achievs
            Achievements.first = data.first;
            Achievements.second = data.second;
            Achievements.third = data.third;
            Achievements.forth = data.forth;
            Achievements.fifth = data.fifth;

            loaded = true;

        }
        }
}

[Serializable]
class GameData
{
    //Player info
    public float manaCost;
    public float maxHp, maxMana, currentMaxXP;
    public int lvl;
    public bool damaged, casting, lvled;
    public float castTime, bPressed, currentHP, hpRegen, manaRegen, currentMana, currentXP;

    public bool[] weapon = new bool[2];
    public int currentWeapon;
    public string scene;
    public float x,y,z;
    public List<Item> slots=new List<Item>();
    public List<Item> equips = new List<Item>();

    //Achievs
    public bool first,second,third,forth,fifth;
}



