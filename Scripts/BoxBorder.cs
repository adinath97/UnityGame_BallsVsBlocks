using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBorder : MonoBehaviour
{
    private BoxInstantiator myBoxInstantiator;
    private Rigidbody2D myRigidbody;
    private bool triggered;

    void Awake()
    {
        myBoxInstantiator = GameObject.FindObjectOfType<BoxInstantiator>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(0f,-BoxInstantiator.moveSpeed0);
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(triggered) {return;}
        if(other.gameObject.tag == "Player" && !triggered) {
            triggered = true;
            myBoxInstantiator.LoadNewBlocks();
        }
    }
}
