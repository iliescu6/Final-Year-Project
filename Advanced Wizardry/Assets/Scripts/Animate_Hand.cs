using UnityEngine;
using System.Collections;

public class Animate_Hand : MonoBehaviour {

	private Animator animator;
    private bool proj = false;


	//Spell projectiles
	public static Rigidbody projectile;
	public Transform position;
	public Rigidbody fb;
	public Rigidbody ib;


	void Awake(){
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButton (0) && Menu.pausebool==false) {
			if(Player.currentMana>=Player.manaCost){
				Player.bPressed+=Time.deltaTime;
				Player.casting=true;
				animator.SetFloat("bPressed",Player.bPressed);   ///////bPressed parameter here!
				animator.SetBool("BDown",true);
				animator.SetBool("Shoot",false);

				if(Player.currentWeapon==1 && proj==false){
					projectile=Instantiate(fb,position.position,position.rotation) as Rigidbody;
					projectile.transform.parent=position.transform;
                    projectile.GetComponent<AudioSource>().Play();
					proj=true;
				}

                if (Player.currentWeapon == 2 && proj == false)
                {
                    projectile = Instantiate(ib, position.position, position.rotation) as Rigidbody;
                    projectile.transform.parent = position.transform;
                    projectile.GetComponent<AudioSource>().Play();
                    proj = true;
                }

                if (Player.bPressed>=Player.castTime){
					Player.bPressed=Player.castTime;
				}
			}
		}
		
		if (Input.GetMouseButtonUp (0) && Menu.pausebool==false && projectile !=null) {
            projectile.transform.parent = null;
			if(Player.bPressed>=Player.castTime){
				Player.bPressed = 0;
				Player.casting=false;
				Player.currentMana-=Player.manaCost;
				Debug.Log ("Spell casted!");
				animator.SetBool("Shoot",true);
                proj = false;
                projectile.velocity = position.TransformDirection(Vector3.back*15);
                Destroy(projectile.gameObject, 5.0f);
            }
            else if(Player.bPressed<Player.castTime){
				Player.bPressed = 0;
				Debug.Log ("Spell failed!");
				animator.SetTrigger("Fail");
				Player.casting=false;
                proj = false;
                Destroy(projectile.gameObject, 0.1f);
            }
			animator.SetBool("BDown",false);
		}

	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.25f);
    }
}
