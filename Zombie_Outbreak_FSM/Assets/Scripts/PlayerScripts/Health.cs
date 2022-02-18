using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;

    [HideInInspector] public bool isDead = false;

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            PlayerIsDead();

        }
    }

    public void PlayerIsDead()
    {
        isDead = true;
        Debug.Log("MARR Gya !!!!!!!!!!");
    }

    public void TakeDamage(float damage)
    {
        if (!isDead)
        {
            health -= damage;
            Debug.Log(health);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AttackHand"))
        {
            TakeDamage(50f);
        }
    }

}
