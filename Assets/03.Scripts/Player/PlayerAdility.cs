using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdility : MonoBehaviour
{
    PlayerLever playerLever;

    [SerializeField] float maxHealth;

    float _maxShield = 100;
    [SerializeField] float currentShield;

    float _maxStamina = 100;
    float recoveryStaminaDelay = 5;
    float recoveryStaminaRate = 3;
    [SerializeField] float currentStamina;

    [SerializeField] float moveSpeed;

    public float CurrentStamina { get { return currentStamina; } }

    private void Start()
    {
        playerLever = GetComponent<PlayerLever>();
        currentStamina = _maxStamina;
        StartCoroutine(RecoveryStamina());
    }
    public void useStamina(float value)
    {
        currentStamina -= value * (1 - (playerLever.Physical * 0.1f));
        StopAllCoroutines();
        if (currentStamina <= 0) StartCoroutine(ExhaustStamina());
        else StartCoroutine(RecoveryStamina());
    }
    IEnumerator RecoveryStamina()
    {
        yield return new WaitForSeconds(recoveryStaminaDelay);
        while (currentStamina < _maxStamina)
        {
            yield return new WaitForSeconds(1 / recoveryStaminaRate);
            currentStamina ++;
            if (currentStamina >= _maxStamina)
            {
                currentStamina = _maxStamina;
                break;
            }
        }
        yield break;
    }
    IEnumerator ExhaustStamina()
    {
        currentStamina = 0;
        yield return new WaitForSeconds(recoveryStaminaDelay);
        StartCoroutine(RecoveryStamina());
        currentStamina = 10;
        yield break;
    }

}
