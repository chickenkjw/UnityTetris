using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour
{
    public float fallTime = 1f;
    private float previousTime = 0f;

    private int currentIndex = 0;
    private int previousIndex;

    private int width = 10;
    private int height = 24;

    void Start() {
        previousIndex = currentIndex;
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
                
                AddtoGrid();
                FindObjectOfType<GameManager>().CreateNextBlock();

                this.enabled = false;
            }

            
            previousTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.Z)) {
            currentIndex++;

            if(currentIndex >= transform.childCount) {
                currentIndex = 0;
            }

            if (canMove()) {
                transform.GetChild(currentIndex).gameObject.SetActive(true);
                transform.GetChild(previousIndex).gameObject.SetActive(false);
            }
            else {
                currentIndex--;
            }

            previousIndex = currentIndex;
        }
        else if (Input.GetKeyDown(KeyCode.X)) {
            currentIndex--;

            if (currentIndex < 0) {
                currentIndex = transform.childCount;
            }

            if (canMove()) {
                transform.GetChild(currentIndex).gameObject.SetActive(true);
                transform.GetChild(previousIndex).gameObject.SetActive(false);
            }
            else {
                currentIndex++;
            }

            previousIndex = currentIndex;
        }
    }

    bool canMove() {
        foreach(Transform children in transform.GetChild(currentIndex)) {
            int FlooredX = Mathf.FloorToInt(children.transform.position.x);
            int FlooredY = Mathf.FloorToInt(children.transform.position.y);

            if(FlooredX < 0 || FlooredX >= width || FlooredY < 0) {
                return false;
            }
            
            if(GameManager.grid[FlooredX, FlooredY] != null) {
                return false;
            }
        }

        return true;
    }

    void AddtoGrid() {
        foreach (Transform children in transform.GetChild(currentIndex)) {
            int FlooredX = Mathf.FloorToInt(children.transform.position.x);
            int FlooredY = Mathf.FloorToInt(children.transform.position.y);

            GameManager.grid[FlooredX, FlooredY] = children;
        }
    }

    bool CheckLine() {
        foreach (Transform children in transform.GetChild(currentIndex)) {
            int FlooredY = Mathf.FloorToInt(children.transform.position.y);

            for(int i = 0; i < width; i++) {
                if(GameManager.grid[i, FlooredY] == null) {
                    return false;
                }
            }
        }

        return true;
    }
}
