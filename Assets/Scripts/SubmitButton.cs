using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ButtonPressEffect : MonoBehaviour
{
    private Vector3 originalScale;
    private Button button;

    void Start()
    {
        originalScale = transform.localScale;
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayPressAnimation);
    }

    void PlayPressAnimation()
    {
        StopAllCoroutines(); // Avoid stacking
        StartCoroutine(AnimatePress());
    }

    IEnumerator AnimatePress()
    {
        // Shrink
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.05f);

        // Pop back
        transform.localScale = originalScale;
    }
}
