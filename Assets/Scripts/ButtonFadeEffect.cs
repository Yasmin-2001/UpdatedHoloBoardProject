using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ButtonFadeEffect : MonoBehaviour
{
    public TMP_InputField inputField;
    private CanvasGroup canvasGroup;
    private Button button;
    public string character; // Assign the letter for this button in Inspector

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (inputField != null)
        {
            inputField.text += character;
        }

        StartCoroutine(FadeButton());
    }

    IEnumerator FadeButton()
    {
        // Fade Out
        for (float f = 1f; f >= 0; f -= 0.05f)
        {
            canvasGroup.alpha = f;
            yield return new WaitForSeconds(0.01f);
        }

        // Fade In
        for (float f = 0f; f <= 1f; f += 0.05f)
        {
            canvasGroup.alpha = f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
