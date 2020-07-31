﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatScalarField : ScalarField<Heat> {
	public int width = 16;
	public int height = 11;

	public override void Start() {
		SpawnCells(-width / 2, -height / 2, width /2, height / 2);
	}
}