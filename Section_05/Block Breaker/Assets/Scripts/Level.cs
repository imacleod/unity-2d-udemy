﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int breakableBlocks; // debugging

    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }
}
