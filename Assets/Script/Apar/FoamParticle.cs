using UnityEngine;
using UnityEngine.InputSystem;

public class FoamParticle : Particle
{
    public Transform leftController; // Referensi ke transform controller kiri
    private Vector3 initialPositionOffset;

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

    protected override void OnSpawnStarted(InputAction.CallbackContext context)
    {
        base.OnSpawnStarted(context);
        // Tambahkan behavior spesifik untuk FoamParticle jika diperlukan
        Debug.Log("FoamParticle Started");
    }

    protected override void OnSpawnCanceled(InputAction.CallbackContext context)
    {
        base.OnSpawnCanceled(context);
        // Tambahkan behavior spesifik untuk FoamParticle jika diperlukan
        Debug.Log("FoamParticle Stopped");
    }
}
