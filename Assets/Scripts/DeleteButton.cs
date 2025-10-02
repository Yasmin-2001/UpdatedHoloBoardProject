using UnityEngine;
using TMPro;
using System.Collections;

public class DeleteButton : MonoBehaviour
{
    public TMP_InputField inputField;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnDelete()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }

        StartCoroutine(PressAnimation());
    }

    IEnumerator PressAnimation()
    {
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.05f);
        transform.localScale = originalScale;
    }
}
