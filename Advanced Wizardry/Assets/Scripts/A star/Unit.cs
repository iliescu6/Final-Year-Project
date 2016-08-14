using UnityEngine;
using System.Collections;


//Code taken from Sebastian Lague :https://www.youtube.com/user/Cercopithecan/playlists (Youtube, accessed 02/15/2016)
public class Unit : MonoBehaviour {

    public Transform target;
    float speed = 0.1f;
    Vector3[] path;
    int targetIndex;

	void Update () {
        if (Panel.move == true)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
            Panel.move = false;
        }
	}

    //If a path is found it will start 
    public void OnPathFound(Vector3[] newPath, bool pathSuccesful) {
        if (pathSuccesful==true) {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath() {
        Vector3 currentWaypoint = path[0];

        while (true) {
            if (transform.position == currentWaypoint) {
                targetIndex++;
                if (targetIndex >= path.Length) {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed);
            yield return null;
        }
    }
	
}
