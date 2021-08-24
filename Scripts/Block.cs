using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject gameOverExplosion;
    
    public float damage;

    public float moveSpeed;

    private BoxCollider2D myBodyCollider;

    private bool keepChecking;

    void Awake()
    {
        damage = Mathf.RoundToInt(Random.Range(1f,30f));
        if(damage > 0f && damage < 6f) {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if(damage >= 6f && damage < 12f) {
            this.GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else if(damage >= 12f && damage < 18f) {
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if(damage >= 18f && damage < 24f) {
            this.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else {
            this.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }

    void Start()
    {
        myBodyCollider = this.GetComponent<BoxCollider2D>();
        keepChecking = true;
    }

    void Update()
    {
        if(this.damage <= 0f) {
            this.GetComponent<ClampNameBox>().DestroyThis();
            Instantiate(gameOverExplosion,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if(GameManager.gameOver) {
            return;
        }
        this.transform.position += transform.up*-BoxInstantiator.moveSpeed0*Time.fixedDeltaTime;
    }

    private void DecrementCount() {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Player"))) {
            keepChecking = false;
            StartCoroutine(DecrementCountRoutine());
        }
    }

    private IEnumerator DecrementCountRoutine() {
        yield return new WaitForSeconds(.2f);
        this.damage -= 1f;
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && this.damage > 0f) {
            StartCoroutine(DecrementCountRoutine());
        }
        else {

            if(this.damage > 0f) {
                keepChecking = true;
            }
            else {
                this.GetComponent<ClampNameBox>().DestroyThis();
                Instantiate(gameOverExplosion,transform.position,Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
