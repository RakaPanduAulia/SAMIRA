using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class IconManager : MonoBehaviour
{
    public Image iconImage; // Referensi ke UI Image untuk ikon
    public Image backgroundImage; // Referensi ke UI Image untuk background warna
    public List<Sprite> icons; // Daftar ikon yang sesuai dengan jenis partikel
    public List<string> particleNames; // Daftar nama skrip partikel
    public List<Color> colors; // Daftar warna yang sesuai dengan jenis partikel

    private void OnEnable()
    {
        Selection.selectionChanged += UpdateIcon;
    }

    private void OnDisable()
    {
        Selection.selectionChanged -= UpdateIcon;
    }

    private void Start()
    {
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        GameObject activeObject = Selection.activeGameObject;
        if (activeObject != null)
        {
            string activeObjectName = activeObject.GetComponent<Particle>()?.GetType().Name;
            if (!string.IsNullOrEmpty(activeObjectName))
            {
                int index = particleNames.IndexOf(activeObjectName);
                if (index != -1)
                {
                    iconImage.sprite = icons[index];
                    backgroundImage.color = colors[index];
                    Debug.Log($"Ikon diperbarui ke: {icons[index].name} dan warna background diperbarui ke: {colors[index]} untuk partikel: {activeObjectName}");
                }
                else
                {
                    Debug.LogError($"Nama partikel {activeObjectName} tidak ditemukan dalam daftar particleNames.");
                }
            }
            else
            {
                Debug.LogError("Objek aktif tidak memiliki komponen Particle.");
            }
        }
        else
        {
            Debug.LogError("Tidak ada objek aktif yang dipilih di Inspector.");
        }
    }
}
