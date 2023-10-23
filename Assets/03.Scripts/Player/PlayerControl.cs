using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    GameObject hand;

    private SpriteRenderer spriteRenderer;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    [SerializeField] float dashCooldown = 5f;

    public bool canDash = true;
    public bool canMove = true;
    public bool canUseItem = true;

    private bool _initialized;

    PlayerMove playerMove;
    Weapon weapon;

    Vector3 moveDirection;
    private void Start()
    {
        hand = transform.GetChild(0).gameObject;
        playerMove = GetComponent<PlayerMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        weapon = GetComponentInChildren<Weapon>();
        _initialized = true;
    }
    private void Update()
    {
        if (!_initialized)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        if (canMove)
        {
            canUseItem = true;
            if (Input.GetKey(KeyCode.LeftShift)) playerMove.Run(moveDirection);

            else playerMove.Walk(moveDirection);

            if (Input.GetKeyDown(KeyCode.Space) && moveDirection != Vector3.zero && canDash)
            {
                playerMove.Dash(moveDirection);
                StartCoroutine(DashCooldown());
            }
        }

        HandPosUpdate(canUseItem ? LookAtMouse() : moveDirection);

        if (canUseItem)
        {
            if (Input.GetMouseButton(0))
            {
                useHand();
            }
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
    private void HandPosUpdate(Vector3 lookBir)
    {
        hand.transform.position = transform.position + (lookBir.normalized * 0.5f);
    }
    void useHand()
    {
        if (transform.GetChild(0).tag == "MainWeapon")
        {
            weapon.Operate(LookAtMouse());
        }
    }
}
