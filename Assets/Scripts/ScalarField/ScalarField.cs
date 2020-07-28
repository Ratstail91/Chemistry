﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalarField : MonoBehaviour {
	public Dictionary<(int, int), ScalarCell> cells = new Dictionary<(int, int), ScalarCell>();

	public float cellWidth = 32f;
	public float cellHeight = 32f;

	//the prefabs
	[SerializeField]
	GameObject cellPrefab = null;

	void Start() {
		SpawnCells(-5, -5, 5, 5);
	}

	public virtual void SpawnCells(int xLower, int yLower, int xUpper, int yUpper) {
		for (int i = xLower; i < xUpper; i++) {
			for (int j = yLower; j < yUpper; j++) {
				//spawn if it doesn't exist
				if (!cells.ContainsKey((i, j))) {
					GameObject go = Instantiate(cellPrefab, new Vector3(i * cellWidth, j * cellHeight, 0f), Quaternion.identity, transform);
					cells[(i, j)] = go.GetComponent<ScalarCell>();

					//initialize the cell
					cells[(i, j)].position = new Vector2Int(i, j);
				}
			}
		}
	}
}