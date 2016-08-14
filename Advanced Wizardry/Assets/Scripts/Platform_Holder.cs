using UnityEngine;
using System.Collections;

public class Platform_Holder : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        //Player becomes a child object of the platform in order to move and not fall
        if (col.gameObject.name == "FPSController(Clone)")
        {
            col.transform.parent = gameObject.transform;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "FPSController(Clone)")
        {
            col.transform.parent = null;
        }
    }
}
