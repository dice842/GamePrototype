using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    [SerializeField] float dashCooldown = 5f;
    public bool isDashing = false;
    private bool canDash = true;

    private bool _initialized;

    PlayerMove playerMove;
    WeaponControl weaponControl;
    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        weaponControl = GetComponentInChildren<WeaponControl>();
        _initialized = true;
    }
    private void Update()
    {
        if (!_initialized)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        if (!isDashing)
        {
            if(Input.GetKey(KeyCode.LeftShift)) playerMove.Walk(moveDirection);

            else playerMove.Run(moveDirection);

            if (Input.GetKeyDown(KeyCode.Space) && moveDirection != Vector3.zero && canDash)
            {
                playerMove.Dash(moveDirection);
                StartCoroutine(DashCooldown());
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            weaponControl.ShootBullet(LookAtMouse());
        }

    }
    public Vector3 LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = (mousePos - transform.position);
        return direction;
    }
    IEnumerator DashCooldown()
    {
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        yield break;
    }
}
