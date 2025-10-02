using UnityEngine;
using UnityEngine.UI;

public class ToggleMainBoard : MonoBehaviour
{
    public GameObject mainBoardPanel; // Drag your main board panel here
    public Button toggleButton;       // Drag your button here

    private bool isVisible = true;

    void Start()
    {
        if (toggleButton != null)
            toggleButton.onClick.AddListener(ToggleBoard);
    }

    void ToggleBoard()
    {
        if (mainBoardPanel != null)
        {
            isVisible = !isVisible;
            mainBoardPanel.SetActive(isVisible);
        }
    }
}

