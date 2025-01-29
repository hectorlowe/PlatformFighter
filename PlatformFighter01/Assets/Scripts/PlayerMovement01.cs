using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement01 : MonoBehaviour

{
    public float speed;
    public float drag;
    public Rigidbody body;
    public BoxCollider groundCheck;
    public Quaternion groundMask;
    public bool grounded;


    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(xInput) > 0) {
            body.linearVelocity = new Vector2(xInput*speed, body.linearVelocity.y);
        }

        if (Mathf.Abs(yInput) > 0) {
            body.linearVelocity = new Vector2(body.linearVelocity.x, yInput*speed);
        }

        //Vector2 direction = new Vector2(xInput, yInput).normalized;
        //body.linearVelocity = direction * speed;
    }

    void FixedUpdate()
    {
        CheckGround();

        if (grounded) {
        body.linearVelocity *= drag;
        }
    }
    void CheckGround()
    {
        grounded = Physics.OverlapBox(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

}
