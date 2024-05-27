using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireIndicator : MonoBehaviour
{
    public Fire fire; // Reference to the Fire script
    public Image hpImage; // Reference to the HP Circle Image
    private float currentHp; // Current displayed HP

    // Start is called before the first frame update
    void Start()
    {
        if (fire == null)
        {
            fire = FindObjectOfType<Fire>();
        }

        if (fire != null)
        {
            currentHp = fire.hp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fire != null && hpImage != null)
        {
            // Smoothly interpolate currentHp towards fire.hp
            currentHp = Mathf.Lerp(currentHp, fire.hp, Time.deltaTime * 5f); // The 5f here is the speed of interpolation, you can adjust it

            // Update the fill amount of the hpImage
            hpImage.fillAmount = currentHp / 100f; // Assuming max HP is 100
        }
    }
}
