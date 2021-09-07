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








    
