using UnityEngine;
using System.Collections;

public class Torch_Turn_OnOff : MonoBehaviour {

	private bool lit;

    public GameObject fire;

	public GameObject platform1;
	public GameObject platform1Start;
	public GameObject platform1End;



	void OnTriggerEnter(Collider projectile){
	if (projectile.gameObject.tag == "Fireball") {
			lit=true;
            transform.gameObject.GetComponent<AudioSource>().Play();
            fire.SetActive(true);
		}
        if (projectile.gameObject.tag == "Iceball") {
            lit = false;
            fire.SetActive(false);
        }
	}

	
	// Update is called once per frame
	void Update () {
	
		if (lit == true) {
			platform1.transform.position = Vector3.MoveTowards (platform1.transform.position, platform1End.transform.position, 5*Time.deltaTime);            
		} else if (lit == false) {
			platform1.transform.position = Vector3.MoveTowards (platform1.transform.position, platform1Start.transform.position, 5*Time.deltaTime);
		}

	}
}
