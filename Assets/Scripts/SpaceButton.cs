using UnityEngine;
using TMPro;

public class SpaceButton : MonoBehaviour
{
    public TMP_InputField inputField;

    public void OnSpace()
    {
        inputField.text += " ";
    }
}
