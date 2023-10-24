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

    private Rigidbody2D rb;

    PlayerControl playerControl;
    PlayerAdility playerAdility;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControl = GetComponent<PlayerControl>();
        playerAdility = GetComponent<PlayerAdility>();
    }
    public void Run(Vector3 moveDir)
    {
        if(moveDir != Vector3.zero)
        {
            playerAdility.useStamina(0.1f);
            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
            playerControl.canUseItem = false;
        }
    }
    public void Walk(Vector3 moveDir)
    {
        transform.Translate(moveDir * (moveSpeed /2) * Time.deltaTime);
    }
    public void Dash(Vector3 dashDir)
    {
        playerControl.canMove = false;
        playerControl.canUseItem = false;
        rb.velocity = Vector2.zero;
        playerAdility.useStamina(10f);
        StartCoroutine(StartDash(dashDir));

    }

    IEnumerator StartDash(Vector3 dir)
    {
        rb.velocity = dir * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        EndDash();
        yield break;
    }

    void EndDash()
    {
        playerControl.canMove = true;
        rb.velocity = Vector2.zero;
    }
}
