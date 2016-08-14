using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//Code taken from Sebastian Lague :https://www.youtube.com/user/Cercopithecan/playlists (Youtube, accessed 02/15/2016)
public class Grid : MonoBehaviour {

	public LayerMask obstacleMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	Node[,] grid;

	float nodeDiameter;
	int gridSizeX,gridSizeY;

	void Start(){
        //Initializes the grid and nodes
            nodeDiameter = nodeRadius * 2;
            gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
            

	}

    void Update() {
        //Updates the nodes
        CreateGrid();
    }
    //Maximum number of nodes
    public int MaxSize {
        get {
            return gridSizeX * gridSizeY;
        }
    }
    //Creates/updates grid
	void CreateGrid(){
		grid=new Node[gridSizeX,gridSizeY];
		Vector3 worldBottomLeft=transform.position - Vector3.right*gridWorldSize.x/2-Vector3.forward*gridWorldSize.y/2;

		for(int x=0;x<gridSizeX;x++){
			for(int y=0;y<gridSizeY;y++){
				Vector3 worldPoint=worldBottomLeft+ Vector3.right*(x*nodeDiameter+nodeRadius)+Vector3.forward*(y*nodeDiameter+nodeRadius);
				bool walkable=!(Physics.CheckSphere(worldPoint,nodeRadius,obstacleMask));
			    grid[x,y]=new Node(walkable,worldPoint,x,y);
			}
		}
	}

    //Returns a list of neighbours around a node
    public List<Node> GetNeighbours(Node node) {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (x == 0 && y == 0 || x==-1 && y==-1 || x==-1 && y==1 || x== 1&& y==-1 || x==1 && y==1) //igore diagonal
   
                    continue;


                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }

    //Transforms a vector 3 world position to a node with an x and y value
    //the x and y are found using a percentage from 0 to 1 
    public Node NodeFromWorldPoint(Vector3 worldPosition) {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX); //(Clamp01 - values only between 0 and 1)
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

	}
