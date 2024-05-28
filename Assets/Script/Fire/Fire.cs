using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Effective,
    Ineffective,
    VeryIneffective
}

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
                finalDamage = ModifyDamageForType(damage, damageType);
                break;
            case FireType.Electric:
                finalDamage = ModifyDamageForType(damage, damageType);
                break;
            case FireType.Chemical:
                finalDamage = ModifyDamageForType(damage, damageType);
                break;
            case FireType.Gas:
                finalDamage = ModifyDamageForType(damage, damageType);
                break;
            case FireType.Liquid:
                finalDamage = ModifyDamageForType(damage, damageType);
                break;
        }

        hp -= finalDamage;
        if (hp <= 0 && !IsInvoking(nameof(DestroyFire)))
        {
            StartCoroutine(DestroyFire());
        }
    }

    private float ModifyDamageForType(float damage, DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Effective:
                return damage * 1f;
            case DamageType.Ineffective:
                return damage * 0.5f;
            case DamageType.VeryIneffective:
                return damage * 0.25f;
            default:
                return damage;
        }
    }

    private IEnumerator DestroyFire()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        Destroy(gameObject);
    }
}
