using UnityEngine;
using System.Collections;

public class Spell_Info {
	private int number;   //Keyboard number for spell
	private int mCost;    //Mana cost to caste
	private float cTime; //Casting time
	private bool active;  //Current weapon
	private bool picked;  //Weapon was picked

	public float CastingTime{
		get{return cTime;}
		set{cTime=value;}
	}

	public int ManaCost{
		get{return mCost;}
		set{mCost=value;}
	}

	public int Number{
		get{return number;}
		set{number=value;}
	}

	public bool Active{
		get{return active;}
		set{active=value;}
	}

	public bool Picked{
		get{return picked;}
		set{picked=value;}
	}
}









