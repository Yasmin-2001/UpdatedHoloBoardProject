using UnityEngine;
using UnityEngine.UI;

public class SlidingToggle : MonoBehaviour
{
    public RectTransform switchHandle;
    public Toggle toggle;
    public float slideAmount = 20f; // how far to move

    private Vector2 offPosition;
    private Vector2 onPosition;

    void Start()
    {
        offPosition = new Vector2(-slideAmount, 0);
        onPosition = new Vector2(slideAmount, 0);

        toggle.onValueChanged.AddListener(OnToggle);
        UpdateHandle(toggle.isOn);
    }

    void OnToggle(bool isOn)
    {
        UpdateHandle(isOn);
    }

    void UpdateHandle(bool isOn)
    {
        switchHandle.anchoredPosition = isOn ? onPosition : offPosition;
    }
}

