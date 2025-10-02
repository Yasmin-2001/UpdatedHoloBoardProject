using UnityEngine;
using UnityEngine.UI;

public class HideMainBoardOnClick : MonoBehaviour
{
    public GameObject mainBoardPanel; // Assign your main board panel here
    public Button completeSetupButton; // Assign the "Complete Setup" button here

    void Start()
    {
        completeSetupButton.onClick.AddListener(HidePanel);
    }

    void HidePanel()
    {
        if (mainBoardPanel != null)
        {
            mainBoardPanel.SetActive(false);
        }
    }
}

