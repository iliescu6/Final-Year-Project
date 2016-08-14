using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	private int speed=100;
	
	void Update () {
		gameObject.transform.Rotate (Vector3.up,speed*Time.deltaTime);
	}
}
