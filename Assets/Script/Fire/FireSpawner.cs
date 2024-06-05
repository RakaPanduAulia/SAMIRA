using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public List<GameObject> firePrefabs; // Daftar prefab objek api
    public List<Transform> spawnPoints; // Daftar spawn points untuk objek api

    public List<GameObject> currentFireObjects { get; private set; } = new List<GameObject>(); // Daftar objek api saat ini di scene

    private void Start()
    {
        // Pastikan jumlah firePrefabs dan spawnPoints sama
        if (firePrefabs.Count != spawnPoints.Count)
        {
            Debug.LogError("Jumlah firePrefabs dan spawnPoints harus sama.");
            return;
        }

        // Instantiate fire objects di posisi spawn points
        for (int i = 0; i < firePrefabs.Count; i++)
        {
            if (firePrefabs[i] != null && spawnPoints[i] != null)
            {
                GameObject fireInstance = Instantiate(firePrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
                currentFireObjects.Add(fireInstance);
                fireInstance.SetActive(false); // Nonaktifkan pada awalnya
            }
        }
    }

    public void DeactivateAllFires()
    {
        foreach (var fire in currentFireObjects)
        {
            if (fire != null)
            {
                fire.SetActive(false);
            }
        }
    }

    public void RespawnFires()
    {
        for (int i = 0; i < firePrefabs.Count; i++)
        {
            if (currentFireObjects[i] == null)
            {
                currentFireObjects[i] = Instantiate(firePrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
            }
            else
            {
                currentFireObjects[i].transform.position = spawnPoints[i].position; // Kembalikan posisi awal
                currentFireObjects[i].transform.rotation = spawnPoints[i].rotation;
                currentFireObjects[i].SetActive(true); // Aktifkan kembali api
            }
        }
    }

    public void DestroyRemainingFires()
    {
        for (int i = 0; i < currentFireObjects.Count; i++)
        {
            if (currentFireObjects[i] != null)
            {
                Fire fireComponent = currentFireObjects[i].GetComponent<Fire>();
                if (fireComponent != null && !fireComponent.canTakeDamage)
                {
                    Destroy(currentFireObjects[i]);
                    currentFireObjects[i] = null; // Set to null so it can be respawned later
                }
            }
        }
    }
}
