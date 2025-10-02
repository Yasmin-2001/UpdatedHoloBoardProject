using UnityEngine;
using TMPro;
using System.Collections;

public class KeyboardAudio : MonoBehaviour
{
    public TMP_InputField inputField;
    public string character;
    public AudioClip letterSound;
    public TMP_Text buttonText; // Drag your TMP Text here in the Inspector

    private AudioSource audioSource;
    private Vector3 originalScale;
    private Color originalColor;

    void Start()
    {
        originalScale = transform.localScale;
        audioSource = gameObject.AddComponent<AudioSource>();
        originalColor = buttonText.color;
    }

    public void OnClick()
    {
        if (inputField != null)
            inputField.text += character;

        if (letterSound != null)
            audioSource.PlayOneShot(letterSound);

        StartCoroutine(PressAnimation());
        StartCoroutine(FlashLetterColor());
    }

    IEnumerator PressAnimation()
    {
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.05f);
        transform.localScale = originalScale;
    }

    IEnumerator FlashLetterColor()
    {
        buttonText.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        buttonText.color = originalColor;
    }
}

