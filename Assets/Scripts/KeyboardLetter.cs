using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardLetter : MonoBehaviour
{
    public TMP_InputField inputField;
    public string letter;

    public void OnClick()
    {
        inputField.text += letter;
    }
}