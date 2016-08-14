using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {


    void OnTriggerEnter(Collider col) {
        if (Player.casting == false && col.gameObject.tag !="Platform") { 
        Destroy(Animate_Hand.projectile.gameObject);
    }
	}
}
