using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CO2Particle : Particle
{
    public Transform leftController; // Referensi ke transform controller kiri
    private Vector3 initialPositionOffset;

    public float effectiveDamage = 10f;
    public float ineffectiveDamage = 5f;
    public float veryIneffectiveDamage = 2.5f;

    private void Start()
    {
        if (leftController != null)
        {
            // Simpan offset posisi awal antara objek dan controller kiri
            initialPositionOffset = transform.position - leftController.position;
        }
    }

    private void Update()
    {
        // Update posisi dari objek dan partikel mengikuti controller kiri
        if (leftController != null)
        {
            // Mengikuti posisi controller kiri dengan mempertahankan offset awal
            transform.position = leftController.position + initialPositionOffset;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!CanApplyDamage())
        {
            return;
        }

        Debug.Log("Particle collided with: " + other.name);

        // Cek apakah objek yang bertabrakan memiliki komponen Fire
        Fire fire = other.GetComponent<Fire>();
        if (fire != null)
        {
            Debug.Log("Fire component detected on: " + other.name);

            DamageType damageType;
            float damageAmount;

            // Tentukan jenis damage berdasarkan jenis api (fireType)
            switch (fire.fireType)
            {
                case FireType.Electric:
                    damageType = DamageType.Effective;
                    damageAmount = effectiveDamage;
                    break;
                case FireType.Liquid:
                    damageType = DamageType.Effective;
                    damageAmount = effectiveDamage;
                    break;
                case FireType.Gas:
                    damageType = DamageType.Ineffective;
                    damageAmount = ineffectiveDamage;
                    break;
                case FireType.Organic:
                    damageType = DamageType.VeryIneffective;
                    damageAmount = veryIneffectiveDamage;
                    break;
                default:
                    Debug.Log("No damage applied to fire type: " + fire.fireType);
                    return; // Tidak ada damage untuk jenis api lainnya
            }

            // Terapkan damage ke objek api
            fire.TakeDamage(damageAmount, damageType);
            Debug.Log("Applied " + damageAmount + " damage to " + fire.fireType + " fire. Remaining HP: " + fire.hp);
        }
        else
        {
            Debug.Log("No Fire component found on: " + other.name);
        }
    }
}
