using UnityEngine;
using System.Collections;

//Code taken from Sebastian Lague :https://www.youtube.com/user/Cercopithecan/playlists (Youtube, accessed 02/15/2016)
public class Node : IHeapItem<Node> {

	public bool walkable;
	public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int hCost;
    public int gCost;
    public Node parent;
    int heapIndex;

    //constructor
	public Node(bool _walkable,Vector3 _worldPos,int _gridX,int _gridY){
		walkable = _walkable;
		worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
	}

    public int fCost {
        get {
            return gCost + hCost;
        }
    }

    public int HeapIndex {
        get {
            return heapIndex;
        }

        set {
            heapIndex = value;
        }
    }

    public int CompareTo(Node nodeToCompare) {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0) {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }

}
