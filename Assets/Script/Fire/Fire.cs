using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireType
{
    Organic,
    Electric,
    Chemical,
    Gas
}

public class Fire : MonoBehaviour
{
    public float hp;
    public FireType fireType;

    protected virtual void Start()
    {
        // Initialize HP based on fire type
        switch (fireType)
        {
            case FireType.Organic:
                hp = 100f;
                break;
            case FireType.Electric:
                hp = 80f;
                break;
            case FireType.Chemical:
                hp = 120f;
                break;
            case FireType.Gas:
                hp = 90f;
                break;
        }
    }

    protected virtual void Update()
    {
        // Fire logic can be updated here
    }

    public void TakeDamage(float damage, DamageType damageType)
    {
        float finalDamage = damage;

        // Modify damage based on fire type and damage type
        switch (fireType)
        {
            case FireType.Organic:
                finalDamage = (damageType == DamageType.Effective) ? damage * 1.5f : damage * 0.5f;
                break;
            case FireType.Electric:
                finalDamage = (damageType == DamageType.Effective) ? damage * 2f : damage * 0.5f;
                break;
            case FireType.Chemical:
                finalDamage = (damageType == DamageType.Effective) ? damage * 1.2f : damage * 0.8f;
                break;
            case FireType.Gas:
                finalDamage = (damageType == DamageType.Effective) ? damage * 1.8f : damage * 0.6f;
                break;
        }

        hp -= finalDamage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
