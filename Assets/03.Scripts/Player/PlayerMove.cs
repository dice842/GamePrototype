using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float dashSpeed = 3.0f;  
    public float dashDuration = 0.1f;  
    private float dashTimer = 0f;    

    private Rigidbody2D rb;

    PlayerControl playerControl;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControl = GetComponent<PlayerControl>();
    }
    public void Move(Vector3 moveDir)
    {
            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
    public void Dash(Vector3 dashDir)
    {
        StartDash(dashDir);

        dashTimer += Time.deltaTime;

        if (dashTimer >= dashDuration)
        {
            EndDash();
        }
    }
    
    public void StartDash(Vector3 dir)
    {
        playerControl.isDashing = true;
        dashTimer = 0f;
        rb.velocity = Vector2.zero;

        rb.velocity = dir * dashSpeed;
    }

    void EndDash()
    {
        playerControl.isDashing = false;
        rb.velocity = Vector2.zero;
    }
}
