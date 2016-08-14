using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour
{
    private GameObject bridge, gate;
    void Start() {
        bridge = GameObject.Find("Bridge");
        gate = GameObject.Find("Gate");
        bridge.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "StartCube" )
        {
            bridge.SetActive(true);
            gate.SetActive(false);

        }
    }
}
