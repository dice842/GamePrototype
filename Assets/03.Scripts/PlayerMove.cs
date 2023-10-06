using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private SpriteRenderer spriteRenderer;

    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    private bool _initialized;

    public float dashSpeed = 3.0f;  
    public float dashDuration = 0.1f;
    private bool isDashing = false;  
    private float dashTimer = 0f;    

    private Rigidbody2D rb;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _initialized = true;
    }

    void Update()
    {
        if (!_initialized)
            return;
        Move();
        LookAtMouse();

        //animator.SetFloat
    }
    
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        if (!isDashing)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space)) StartDash(moveDirection);
        }
        if (isDashing)
        {
            dashTimer += Time.deltaTime;

            if (dashTimer >= dashDuration)
            {
                EndDash();
            }
        }
    }
    void LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position);
    }
    void StartDash(Vector3 dir)
    {
        isDashing = true;
        dashTimer = 0f;
        rb.velocity = Vector2.zero;

        rb.velocity = dir * dashSpeed;
    }

    void EndDash()
    {
        isDashing = false;
        rb.velocity = Vector2.zero;
    }
}
