using UnityEngine;
using System.Collections;


[System.Serializable]
public class Player
: MonoBehaviour {


    public static Vector3 spawn,loadPos;

	public static Spell_Info s1 =new Spell_Info();
	public static Spell_Info s2 =new Spell_Info();
	
	private GameObject hand;
	
    //Player stats
	public static float manaCost=0;
	public static float maxHP,maxMana, currentMaxXP;

    public static int[] maxXP = new int[15] { 50, 75, 100, 150, 200, 300, 400, 500, 650, 750, 875, 900, 1000, 1250, 1500 };

    public static int lvl;

    public static bool damaged = false, casting = false, lvled = false;
	public static float castTime=3.0f,bPressed=0.0f,currentHP,hpRegen,manaRegen,currentMana, currentXP;

	//Weapons
	public static bool[] weapon = new bool[4];
	public static int currentWeapon=0;
	/*
	 * s1-Fireball
	 * s2-Iceball
	*/	
	private void CreateSpell(Spell_Info s,int n,int mc,float ct,bool a,bool p){
		s.Number = n;
		s.ManaCost = mc;
		s.CastingTime = ct;

		s.Active = a;
		s.Picked = p;
	}
	void Awake () {
        spawn = GameObject.Find("StartingPosition").transform.position;
        transform.position = spawn;
        weapon [0] = false;
		weapon [1] = false;

		hand=GameObject.Find("hand_seam");
		hand.SetActive (false);
		CreateSpell (s1,1,10,3,false,false);         //Fireball
		CreateSpell (s2,2,5,1.5f,false,false);       //Iceball

        //If you lose the game and star a new game from main menu, the values of the player will be reseted, otherwise
        //he would have the same values as the one from the previous game

        currentMaxXP = maxXP[0];
        lvl = 0;
        currentXP = 0;
        currentHP = 30.0f;
        maxHP = 30f;
        currentMana =45f;
        maxMana = 45f;
        hpRegen = 0.3f;
        manaRegen = 0.5f;
    }





    // Update is called once per frame
    void Update () {
        if (Raycast.change == true) {
            spawn = GameObject.Find("StartingPosition").transform.position;
            transform.position = spawn;
            Raycast.change = false;
            SavaLoad.loaded = false;
        }
        if (SavaLoad.loaded==true)
        {
            transform.position = loadPos;
        }
        //Stats
        if (currentHP > maxHP) {
            currentHP = maxHP;
        }
        if (currentMana > maxMana) {
            currentMana = maxMana;
        }

        if (currentXP >= currentMaxXP) {
            lvled = true;
            currentXP = currentXP-currentMaxXP;
            lvl +=1;
            maxHP += 5;
            maxMana += 10;
            manaRegen += 0.1f;
            hpRegen += 0.1f;

            currentMaxXP = maxXP[lvl];
            lvled= false;
        }

        //Weapons
		if (weapon [0] == true && hand !=null ) {
			hand.SetActive(true);
		}

        //don't have more mana/hp than the maximum
		if (currentMana < maxMana) {
			currentMana=currentMana+(Time.deltaTime*manaRegen);
		}

        if (currentHP < maxHP)
        {
            currentHP = currentHP +(Time.deltaTime*hpRegen );
        }
        //use health potion
        if (Input.GetKey("r") && currentHP < maxHP && Managers.Inventory.GetConsumableCount("Health") > 0) {
            currentHP += 10;
            Managers.Inventory.ConsumeItem("Health");
        }
        if (Input.GetKeyDown (KeyCode.Alpha1) && weapon[0]==true) {
			s1.Active=true;
			castTime=s1.CastingTime;
			manaCost=s1.ManaCost;
			currentWeapon=1;
		}

		if (Input.GetKeyDown (KeyCode.Alpha2) && weapon[1]==true) {
			s2.Active=true;
			castTime=s2.CastingTime;
			manaCost=s2.ManaCost;
			currentWeapon=2;
		}
 
	}
	
	 
}
