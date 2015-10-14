using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
	public Transform tile;

	private int[,] m_MapConfigArray = {
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{ 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1},
		{ 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1},
		{ 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
	};

	private List<Transform> m_TileList;

	// Use this for initialization
	void Start () {
		m_TileList = new List<Transform> ();
		for (int x = 0; x < 8; x++) {
			for (int y = 0; y < 12; y++) {
				int flag = m_MapConfigArray [x, y];
				var tileTF = Instantiate (tile, new Vector3 (y * 0.3f, -x * 0.3f, 0), Quaternion.identity) as Transform;
				if (flag == 1) {
					tileTF.GetComponent<SpriteRenderer> ().color = Color.red;
				}
				m_TileList.Add (tileTF);
			}
		}

		Maze maze = new Maze(m_MapConfigArray);
		Point start = new Point(1, 1);
		Point end = new Point(1, 10);

//		Transform startTile = m_TileList [1 * 12 + 1];
//		startTile.GetComponent<SpriteRenderer> ().color = Color.black;
//
//		Transform endTile = m_TileList [6 * 12 + 10];
//		endTile.GetComponent<SpriteRenderer> ().color = Color.black;

		var parent = maze.FindPath(start, end, false);

		while (parent != null)
		{
			Debug.Log(parent.X + ", " + parent.Y);
			Transform targetTile = m_TileList [parent.X * 12 + parent.Y];
			targetTile.GetComponent<SpriteRenderer> ().color = Color.green;

			parent = parent.ParentPoint;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
