using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{
    public int Level = 1;

    public void loadNextLevel()
    {
        Level++;
        GameObject.Find("AlienManager").GetComponent<AlienManager>().makeAliens();
    }
}
