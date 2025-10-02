using UnityEngine;
using TMPro;
using System.Collections;

public class ClearInputField : MonoBehaviour
{
    public TMP_InputField inputField;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void ClearText()
    {
        if (inputField != null)
        {
            inputField.text = "";
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

