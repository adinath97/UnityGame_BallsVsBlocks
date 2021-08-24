using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColllision : MonoBehaviour
{
    [SerializeField] float moveSpeed = 50f;
    [SerializeField] List<Transform> vibrationBounds;
    [SerializeField] LayerMask ignoreThisLayer;

    private bool keepChecking;

    [SerializeField] Player player;

    private CircleCollider2D myBodyCollider;

    private int vibrationBoundIndex = 0;

    void Start()
    {
        myBodyCollider = this.GetComponent<CircleCollider2D>();
        transform.position = vibrationBounds[vibrationBoundIndex].transform.position;
        keepChecking = true;
    }

    void Update()
    {
        Vibrate();
        if(keepChecking) {
            RaycastHitCheck();
        }
    }

    void RaycastHitCheck() {
        var ray = new Ray2D(this.transform.position, this.transform.up);
        RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin,ray.direction,1f, ~ignoreThisLayer);
        if(hitInfo)
        {
            if(hitInfo.collider.tag == "Block")
            {
                keepChecking = false;
                hitInfo.transform.gameObject.GetComponent<Block>().damage -= 1f;
                BoxInstantiator.moveSpeed0 = 0f;
                if(Player.segmentCount > 0f) {
                    ClampName.playerScore -= 1f;
                    Player.segmentCount -= 1f;
                    ScoreManager.score += 1f;
                }
                player.DestroySegment();
                StartCoroutine(WaitAndCheckRoutine());
                return;
            }
            else {
                BoxInstantiator.moveSpeed0 = BoxInstantiator.setSpeed;
                return;
            }
        }
        else {

            BoxInstantiator.moveSpeed0 = BoxInstantiator.setSpeed;
            return;
        }
    }

    private IEnumerator WaitAndCheckRoutine() {
        yield return new WaitForSeconds(.2f);
        keepChecking = true;
    }

    private void Vibrate() {
        var ray = new Ray2D(this.transform.position, this.transform.up);
        RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin,ray.direction,1f, ~ignoreThisLayer);
        if(hitInfo) {
            if(hitInfo.collider.tag == "Block") {
                if(vibrationBoundIndex <= vibrationBounds.Count - 1) {
                    var targetPosition = vibrationBounds[vibrationBoundIndex].transform.position;
                    var movementThisFrame = moveSpeed * Time.deltaTime;
                    this.transform.position = Vector2.MoveTowards(this.transform.position,targetPosition,movementThisFrame);
                    if(this.transform.position == targetPosition) {
                        vibrationBoundIndex++;
                    }
                }
                else {
                    vibrationBoundIndex = 1;
                }
            }
            else {
                vibrationBoundIndex = 0;
                var targetPosition = vibrationBounds[vibrationBoundIndex].transform.position;
                var movementThisFrame = moveSpeed * Time.deltaTime;
                this.transform.position = Vector2.MoveTowards(this.transform.position,targetPosition,movementThisFrame);
            }
        }
    }
}
