using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    void Awake()
    {
        int randX = Random.Range(0,5);
        switch(randX) {
            case 0:
                this.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,.2f);
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,.4f);
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,.6f);
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,.8f);
                break;
            default:
                this.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,1f);
                break;
        }
    }

    void Update()
    {
        if(GameManager.gameOver) {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-BoxInstantiator.moveSpeed0);
    }
}
