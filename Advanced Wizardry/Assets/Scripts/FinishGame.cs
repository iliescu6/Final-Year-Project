using UnityEngine;
using System.Collections;

public class FinishGame : MonoBehaviour {

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Achievements.fifth = true;
        }
    }
}
