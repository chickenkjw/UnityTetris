using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] tetrimino = new GameObject[7];
    public Transform spawnpoint;

    public static Transform[,] grid = new Transform[10,24];

    private void Start() {
        CreateNextBlock();
    }

    public void CreateNextBlock() {
        int random = Random.Range(0, 7);
        Instantiate(tetrimino[random], spawnpoint.position, Quaternion.identity);
    }
}
