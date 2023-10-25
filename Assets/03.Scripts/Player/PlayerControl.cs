using System;
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
    PlayerAdility playerAdility;
    ThrownWeapons thrownWeapons;

    Vector3 moveDirection;
    private void Start()
    {
        hand = transform.GetChild(0).gameObject;
        playerMove = GetComponent<PlayerMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAdility = GetComponent<PlayerAdility>();
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
            if (Input.GetKey(KeyCode.LeftShift) && playerAdility.CurrentStamina > 0) playerMove.Run(moveDirection);

            else playerMove.Walk(moveDirection);

            if (Input.GetKeyDown(KeyCode.Space) && moveDirection != Vector3.zero && canDash && playerAdility.CurrentStamina > 10)
            {
                playerMove.Dash(moveDirection);
                StartCoroutine(DashCooldown());
            }
        }

        if (hand.gameObject != null)
        {
            HandPosUpdate(canUseItem ? LookAtMouse() : moveDirection);
        }

        if (canUseItem)
        {
            if (Input.GetMouseButton(0))
            {
                useHand1();
            }
            else if (Input.GetMouseButton(1))
            {
                useHand2();
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
    public IEnumerator useItemColldown(float collTime)
    {
        canUseItem = false;
        yield return new WaitForSeconds(collTime);
        canUseItem = true;
    }
    private void HandPosUpdate(Vector3 lookBir)
    {
        hand.transform.position = transform.position + (lookBir.normalized * 0.5f);
    }
    void useHand1()
    {
        if (transform.GetChild(0).tag == "MainWeapon")
        {
            weapon = GetComponentInChildren<Weapon>();
            weapon.Operate(LookAtMouse());
        }
        else if (transform.GetChild(0).tag == "ThrownWeapons")
        {
            thrownWeapons = GetComponentInChildren<ThrownWeapons>();
            thrownWeapons.Thrown(LookAtMouse());
        }
    }
    private void useHand2()
    {
        if (transform.GetChild(0).tag == "ThrownWeapons")
        {
            thrownWeapons = GetComponentInChildren<ThrownWeapons>();
            thrownWeapons.ChargingWeapon();
        }
    }
}
