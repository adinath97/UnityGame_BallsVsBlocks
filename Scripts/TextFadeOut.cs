using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFadeOut : MonoBehaviour
{
    private Animator myAnim;
    
    // Start is called before the first frame update
    void Awake()
    {
        myAnim = this.GetComponent<Animator>();
        myAnim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver) {
            myAnim.enabled = true;
        }
    }
}
