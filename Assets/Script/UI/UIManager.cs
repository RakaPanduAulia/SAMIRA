using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject playGameCanvas;
    public GameObject[] uiCanvases; // Assign UIFoam, UIWater, UICO2, UIPowder in the inspector
    public Button playButton;
    public Button tutorialButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
        tutorialButton.onClick.AddListener(OnTutorialButtonClick);
    }

    private void OnPlayButtonClick()
    {
        // Hide the main menu canvas
        mainMenuCanvas.SetActive(false);

        // Show the play game canvas
        playGameCanvas.SetActive(true);
    }

    private void OnTutorialButtonClick()
    {
        // Hide the play game canvas
        playGameCanvas.SetActive(false);

        // Set initial position for each canvas
        Vector3 initialPosition = new Vector3(0, 0, 0); // Adjust this based on your scene setup
        float spacing = 0.3f; // Adjust the spacing between the canvases

        // Animate each canvas to its new position
        for (int i = 0; i < uiCanvases.Length; i++)
        {
            GameObject uiCanvas = uiCanvases[i];
            Vector3 targetPosition = initialPosition + new Vector3(i * spacing, 0, 0);

            // Enable the canvas before animating
            uiCanvas.SetActive(true);
            uiCanvas.transform.localPosition = new Vector3(-800f, 0, 0); // Set initial off-screen position

            // Animate to target position
            uiCanvas.transform.DOLocalMove(targetPosition, 1f).SetDelay(i * 0.5f); // Adjust duration and delay as needed
        }
    }
}
