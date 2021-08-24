using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float prizeSegments = 5f;
    public float moveSpeed;
    [SerializeField] BoxCollider2D myBodyCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        this.prizeSegments = Mathf.RoundToInt(Random.Range(1f,10f));
        myBodyCollider = this.transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(GameManager.gameOver) {
            return;
        }
        this.moveSpeed = BoxInstantiator.moveSpeed0;
        if(moveSpeed > Mathf.Epsilon) {
            if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Block","Ball","BadBall"))) {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            else {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-moveSpeed);
            }
        }
        else {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
