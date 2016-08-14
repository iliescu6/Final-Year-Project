using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && transform.gameObject.name=="DeadZone")
        {
            Player.currentHP = 0;

        }else if (col.gameObject.tag == "Player")
        {
            if (Player.damaged == false)
            {
                Player.damaged = true;
                Player.currentHP -= 2.5f;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Player.damaged = false;
    }
}
