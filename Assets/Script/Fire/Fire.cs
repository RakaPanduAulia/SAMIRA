using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireType
{
    Organic,
    Electric,
    Chemical,
    Gas,
    Liquid
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
                hp = 100f;
                break;
            case FireType.Chemical:
                hp = 100f;
                break;
            case FireType.Gas:
                hp = 100f;
                break;
            case FireType.Liquid:
                hp = 100f;
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
                finalDamage = (damageType == DamageType.Effective) ? damage * 1f : damage * 0.5f;
                break;
            case FireType.Electric:
                finalDamage = (damageType == DamageType.Effective) ? damage * 1f : damage * 0.5f;
                break;
            case FireType.Chemical:
                finalDamage = (damageType == DamageType.Effective) ? damage * 1f : damage * 0.5f;
                break;
            case FireType.Gas:
                finalDamage = (damageType == DamageType.Effective) ? damage * 1f : damage * 0.5f;
                break;
            case FireType.Liquid:
                finalDamage = (damageType == DamageType.Effective) ? damage * 1f : damage * 0.5f;
                break;
        }

        hp -= finalDamage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
