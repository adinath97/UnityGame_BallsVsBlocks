using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject segmentPrefab;
    [SerializeField] LayerMask ignoreThisLayer;

    [SerializeField] GameObject gameOverExplosion; 

    TextMeshProUGUI scoreInstance;

    [SerializeField] CircleCollider2D myBodyCollider;

    private Rigidbody2D playerRB;
    public List<GameObject> segments = new List<GameObject>();
    private float deltaX,newXPos,xMin,xMax,targetXPos,leftBound,rightBound;
    public static float segmentCount;
    public static bool playerGameOver;
    private bool isColliding,coroutineOver;

    void Awake()
    {
        segmentCount = 15f;
        playerGameOver =  false;
        playerRB = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SetUpMoveBoundaries();
        StartCoroutine(MoveSegmentsRoutineThree());
    }

    void Update()
    {
        MoveSnake();
        if(coroutineOver) {
            coroutineOver = false;
            StartCoroutine(MoveSegmentsRoutineThree());
        }
        if(segments.Count > segmentCount){
            DestroySegment();
        }
        if(this.segments.Count > 10) {
            playerGameOver = true;
        }
        if(playerGameOver && segments.Count <= 0) {
            GameManager.gameOver = true;
            this.GetComponent<ClampName>().DestroyThis();
            Instantiate(gameOverExplosion,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        } 
     }

    private IEnumerator MoveSegmentsRoutineThree() {
        yield return new WaitForSeconds(.2f);
        GameObject segmentInstance = Instantiate(segmentPrefab,this.transform.position,Quaternion.identity) as GameObject;
        segments.Add(segmentInstance);
        if(segments.Count > segmentCount) {
            DestroySegment();
        }
        StartCoroutine(MoveSegmentsRoutineThree());
    }

    public void DestroySegment() {
        Destroy(segments[0]);
        segments.RemoveAt(0);
    }

    public void DestroyInBulk(float param){
        int x = (int)param;
    }

    private void MoveSnake() {
        deltaX = Input.GetAxisRaw("Horizontal");
        float xSpeed = deltaX * moveSpeed * Time.deltaTime;
        Vector2 force = new Vector2(xSpeed,0f);
        playerRB.AddForce(force);
        /*
        //raycast to detect wall on right
        newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        transform.position = new Vector2(newXPos,transform.position.y);
        var ray = new Ray2D(this.transform.position, this.transform.right);
        RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin,ray.direction, 10f, ~ignoreThisLayer);
        Debug.DrawRay(ray.origin,ray.direction,Color.green,10f);
        
        if(hitInfo)
        {
            if(hitInfo.collider.tag == "Wall")
            {
                Debug.Log("WALL ON RIGHT");
                return;
            }
        }

        var ray2 = new Ray2D(this.transform.position, -this.transform.right);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(ray2.origin,ray2.direction, 10f, ~ignoreThisLayer);
        Debug.DrawRay(ray2.origin,ray2.direction,Color.green,10f);
        if(hitInfo2)
        {
            if(hitInfo2.collider.tag == "Wall")
            {
                Debug.Log("WALL ON LEFT");
                return;
            }
        }
        */
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}
