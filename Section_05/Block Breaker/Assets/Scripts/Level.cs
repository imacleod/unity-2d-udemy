using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int breakableBlocks; // debugging

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }

    public void IncrementBreakableBlocks()
    {
        breakableBlocks++;
    }
}
