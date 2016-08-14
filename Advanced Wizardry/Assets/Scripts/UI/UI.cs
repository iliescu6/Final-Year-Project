using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	private Vector3 hpStartPos,manaStartPos,castStartPos,xpStartPos;
	private Vector3 currentHPPos,currentManaPos,currentCastPos,currentXPBarPos;
	private float percentageHPLeft,percentageManaLeft,percentageCastLeft,percentageXPLeft;
	private float moveXHPBar,moveXManaBar,moveXCastBar,moveXXPBar;

    

	public RectTransform hpBarCoords,manaBarCoords,castBarCoords,xpBarCoords;
	public CanvasGroup castBar;
	public CanvasGroup ui;
    public Text health, mana,spell,xp,hpPotion,mPotion;



    

    void Awake() {
        
    }
	void Start(){

        hpStartPos = hpBarCoords.position;
		manaStartPos = manaBarCoords.position;
		castStartPos = castBarCoords.position;
        xpStartPos = xpBarCoords.position;

		currentHPPos = hpBarCoords.position;
		currentManaPos = manaBarCoords.position;
		currentCastPos = castBarCoords.position;
        currentXPBarPos = xpBarCoords.position;

        gameObject.GetComponent<AudioSource>().Play();
    }


	void Update () {
		if (Player.weapon [0] == false) {
			ui.alpha = 0;		
		} else {
			ui.alpha=1;
		}


        
        //TEXT UI
        health.text = Player.currentHP.ToString("0") + "/" + Player.maxHP.ToString("0");
        mana.text = Player.currentMana.ToString("0") + "/" + Player.maxMana.ToString("0");
        xp.text = "XP: " + Player.currentXP.ToString("0") + "/" + Player.currentMaxXP.ToString("0");
        hpPotion.text= "R(" + Managers.Inventory.GetConsumableCount("Health")+")";
        mPotion.text = "T(" + Managers.Inventory.GetConsumableCount("Mana") + ")";


        //HP,MANA,CAST BARS
        if (Player.currentWeapon == 1)
        {
            spell.text = "Current Spell: Fireball" +"\n" + "Mana cost: " + Player.manaCost.ToString("0");
        }
        else if (Player.currentWeapon == 2) {
            spell.text = "Current Spell: Iceball" + "\n" + "Mana cost: " + Player.manaCost.ToString("0");
        }

        //Hp bar
		percentageHPLeft=Percentage (Player.maxHP,Player.currentHP);
		moveXHPBar=ChangeBarPos(percentageHPLeft,150);
		currentHPPos=new Vector3(hpBarCoords.position.x-moveXHPBar,hpBarCoords.position.y,hpBarCoords.position.z);

        //XP Bar
            percentageXPLeft = Percentage(Player.currentMaxXP, Player.currentXP);
            moveXXPBar = ChangeBarCastPos(percentageXPLeft, 720);
            currentXPBarPos = new Vector3(xpBarCoords.position.x + moveXXPBar, xpBarCoords.position.y, xpBarCoords.position.z);
        


        //Cast bar

			percentageManaLeft=Percentage(Player.maxMana,Player.currentMana);
			moveXManaBar=ChangeBarPos(percentageManaLeft,150);
			currentManaPos=new Vector3(manaBarCoords.position.x+moveXManaBar,manaBarCoords.position.y,manaBarCoords.position.z);
		

		if (Player.casting==true) {
			percentageCastLeft=Percentage(Player.castTime,Player.bPressed);
			moveXCastBar=ChangeBarCastPos(percentageCastLeft,190);
			currentCastPos=new Vector3(castBarCoords.position.x+moveXCastBar,castBarCoords.position.y,castBarCoords.position.z);	

			castBar.alpha=1;
		}

		if (Player.casting == false) {
			currentCastPos=castStartPos;
			castBar.alpha=0;
		}

		hpBarCoords.position = Vector3.Lerp (hpStartPos, currentHPPos,0.5f);
		manaBarCoords.position = Vector3.Lerp (manaStartPos, currentManaPos,0.5f);
		castBarCoords.position = Vector3.Lerp (castStartPos,currentCastPos, 0.5f);
        if (Player.lvled == true)
        {
            xpBarCoords.position = Vector3.Lerp(currentXPBarPos, xpStartPos, 0.5f);
        }
        else
        {
            xpBarCoords.position = Vector3.Lerp(xpStartPos, currentXPBarPos, 0.5f);
        }
	}

	public float Percentage(float max,float current ){
		float percentage = 0.0f;
		percentage = (current / max) * 100;
		percentage = ((float)(int)(percentage * 100.0f)) / 100.0f; 

		return percentage;
	}


	public float ChangeBarPos(float percentage, float width){
		float moveXBar = 0.0f;
		percentage = 100 - percentage;
		moveXBar=(percentage*width)/100;
		return moveXBar;
	}

	public float ChangeBarCastPos(float percentage, float width){
		float moveXBar = 0.0f;
		moveXBar=(percentage*width)/100;
		return moveXBar;
	}


	private IEnumerator Wait(float castTime){
		yield return new WaitForSeconds (castTime);
	}

}
