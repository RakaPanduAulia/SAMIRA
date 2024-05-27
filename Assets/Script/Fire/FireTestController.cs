using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireTestController : MonoBehaviour
{
    public OrganicFire organicFire; // Assign this in the inspector or find it in Start method
    public InputActionReference damageEffectiveAction;
    public InputActionReference damageIneffectiveAction;

    void Start()
    {
        if (organicFire == null)
        {
            // Try to find the OrganicFire component in the scene
            organicFire = FindObjectOfType<OrganicFire>();
        }

        if (organicFire == null)
        {
            Debug.LogError("OrganicFire component not found in the scene.");
        }
        else
        {
            Debug.Log("Initial HP: " + organicFire.hp);
        }

        damageEffectiveAction.action.performed += OnEffectiveDamage;
        damageIneffectiveAction.action.performed += OnIneffectiveDamage;
    }

    private void OnEnable()
    {
        damageEffectiveAction.action.Enable();
        damageIneffectiveAction.action.Enable();
    }

    private void OnDisable()
    {
        damageEffectiveAction.action.Disable();
        damageIneffectiveAction.action.Disable();
    }

    private void OnEffectiveDamage(InputAction.CallbackContext context)
    {
        if (organicFire == null) return;

        // Apply effective damage
        organicFire.TakeDamage(20f, DamageType.Effective);
        Debug.Log("HP after effective damage: " + organicFire.hp);
    }

    private void OnIneffectiveDamage(InputAction.CallbackContext context)
    {
        if (organicFire == null) return;

        // Apply ineffective damage
        organicFire.TakeDamage(20f, DamageType.Ineffective);
        Debug.Log("HP after ineffective damage: " + organicFire.hp);
    }
}
