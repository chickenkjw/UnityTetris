using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour
{
    public float fallTime = 1f;
    private float previousTime = 0f;

    private int currentIndex = 0;

    private int width = 10;
    private int height = 24;

    public 

    void Start() {
        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += Vector3.right;

            if (!canMove()) {
                transform.position += Vector3.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += Vector3.left;

            if (!canMove()) {
                transform.position += Vector3.right;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - previousTime > fallTime) {
            transform.position += Vector3.down;

            if (!canMove()) {
                transform.position += Vector3.up;

                FindObjectOfType<GameManager>().CreateNextBlock();

                this.enabled = false;
            }

            previousTime = Time.time;
        }
    }

    bool canMove() {
        foreach(Transform children in transform.GetChild(currentIndex)) {
            int FlooredX = Mathf.FloorToInt(children.transform.position.x);
            int FlooredY = Mathf.FloorToInt(children.transform.position.y);

            if(FlooredX < 1 || FlooredX > width || FlooredY < 1 || FlooredY > height) {
                return false;
            }
        }

        return true;
    }

    void AddtoGrid() {
        //GameManager.
    }
}








    //public float fallTime = 1f;
    //private float startTime;

    //public static int height = 24;
    //public static int width = 10;
    //private int deadLine = 20;

    //private int curBlockIndex = 0;
    //private int preBlockIndex;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    preBlockIndex = curBlockIndex;

    //    for(int i = 0; i < transform.childCount; i++) {
    //        if(i == curBlockIndex) {
    //            continue;
    //        }
    //        transform.GetChild(i).gameObject.SetActive(false);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.RightArrow)) {
    //        transform.position += Vector3.right;
    //        if (!canMove()) {
    //            transform.position -= Vector3.right;
    //        }
    //    }
    //    else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
    //        transform.position += Vector3.left;
    //        if (!canMove()) {
    //            transform.position -= Vector3.left;
    //        }
    //    }
    //    else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - startTime > fallTime) {
    //        transform.position += Vector3.down;
    //        if (!canMove()) {
    //            transform.position -= Vector3.down;

    //            AddToGrid();
    //            CheckLines();

    //            if (!IsGameOver()) {
    //                FindObjectOfType<Game>().SpawnTetrimino();
    //            }
    //            else {
    //                FindObjectOfType<Game>().GameOver();
    //            }

    //            this.enabled = false;
    //        }

    //        startTime = Time.time;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Z)) {
    //        curBlockIndex++;

    //        if(curBlockIndex >= transform.childCount) {
    //            curBlockIndex = 0;
    //        }

    //        if (canMove()) {
    //            transform.GetChild(curBlockIndex).gameObject.SetActive(true);
    //            transform.GetChild(preBlockIndex).gameObject.SetActive(false);
    //        }
    //        else {
    //            curBlockIndex--;
    //        }
    //        preBlockIndex = curBlockIndex;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Space)) {
    //        while (canMove()) {
    //            transform.position += Vector3.down;
    //        }
    //        transform.position -= Vector3.down;

    //        AddToGrid();
    //        CheckLines();

    //        if (!IsGameOver()) {
    //            FindObjectOfType<Game>().SpawnTetrimino();
    //        }
    //        else {
    //            FindObjectOfType<Game>().GameOver();
    //        }

    //        this.enabled = false;
    //    }

    //}

    //bool canMove() {
    //    foreach (Transform children in transform.GetChild(curBlockIndex)) {
    //        int flooredX = Mathf.FloorToInt(children.transform.position.x);
    //        int flooredY = Mathf.FloorToInt(children.transform.position.y);

    //        if (flooredX < 0 || flooredX >= width || flooredY < 0) {
    //            return false;
    //        }

    //        if(Game.grid[flooredX, flooredY] != null) {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    //void AddToGrid() {
    //    foreach (Transform children in transform.GetChild(curBlockIndex)) {
    //        int flooredX = Mathf.FloorToInt(children.transform.position.x);
    //        int flooredY = Mathf.FloorToInt(children.transform.position.y);

    //        Game.grid[flooredX, flooredY] = children;
    //    }
    //}

    //void CheckLines() {
    //    foreach (Transform children in transform.GetChild(curBlockIndex)) {
    //        int flooredY = Mathf.FloorToInt(children.transform.position.y);

    //        do {
    //            if (HasLine(flooredY)) {
    //                DeleteLine(flooredY);
    //                DownBlocks(flooredY);
    //            }
    //        } while (HasLine(flooredY));
    //    }
    //}

    //bool HasLine(int y) {
    //    for (int i = 0; i < width; i++) {
    //        if(Game.grid[i, y] == null) {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    //void DeleteLine(int y) {
    //    for(int i = 0; i < width; i++) {
    //        Destroy(Game.grid[i, y].gameObject);
    //        Game.grid[i, y] = null;
    //    }
    //}

    //void DownBlocks(int y) {
    //    for (int i = y + 1; i < height; i++) {
    //        for (int j = 0; j < width; j++) {
    //            if (Game.grid[j, i] != null) {
    //                Game.grid[j, i - 1] = Game.grid[j, i];
    //                Game.grid[j, i] = null;
    //                Game.grid[j, i - 1].transform.position += Vector3.down;
    //            }
    //        }
    //    }
    //}

    //bool IsGameOver() {
    //    foreach (Transform children in transform.GetChild(curBlockIndex)) {
    //        int flooredY = Mathf.FloorToInt(children.transform.position.y);

    //        if(flooredY > deadLine) {
    //            return true;
    //        }
    //    }
    //    return false;
    //}