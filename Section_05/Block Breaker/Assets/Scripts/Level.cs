using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int blocksTotal; // debugging

    public void BlockDestroyed()
    {
        blocksTotal--;
        if (blocksTotal <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }

    public void CountBlocks()
    {
        blocksTotal++;
    }
}
