using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    private bool _initialized;

    public bool isDashing = false;

    PlayerMove playerMove;
    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _initialized = true;
    }
    private void Update()
    {
        if (!_initialized)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);

        playerMove.Move(moveDirection);
        LookAtMouse();
        if (Input.GetKeyDown(KeyCode.Space)) playerMove.Dash(moveDirection);
    }
    void LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position);
    }
}
