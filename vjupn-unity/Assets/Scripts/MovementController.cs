using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{   
    public float jumpForce = 1000f;
    private Rigidbody2D rb;
    private bool SaltoPosible = true;
    private bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SaltoPosible) Saltar();
    }

    public bool Saltar(){
        if(CanJump() && SaltoPosible) {
            rb.AddForce(transform.up * jumpForce);
            Jump();
        }
        return true;
    }
    private bool CanJump() {
        return onGround || !onGround;
    }
    private void Jump() {
        onGround = false;
            
    }
    private void OnCollisionEnter2D(Collision2D other) {
        onGround = true;
    }

}
