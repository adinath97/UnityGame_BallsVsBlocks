using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float prizeSegments = 5f;
    public float moveSpeed;
    private CircleCollider2D myBodyCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        myBodyCollider = this.GetComponent<CircleCollider2D>();
        this.prizeSegments = Mathf.RoundToInt(Random.Range(1f,10f));
    }

    void Update()
    {
        if(GameManager.gameOver) {
            return;
        }
        this.moveSpeed = BoxInstantiator.moveSpeed0;
        if(moveSpeed > Mathf.Epsilon) {
            if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Block"))) {
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
            Player.segmentCount += prizeSegments;
            ClampName.playerScore += prizeSegments;
            this.GetComponent<ClampNameBall>().DestroyThis();
            Destroy(this.gameObject);
        }
    }
}
