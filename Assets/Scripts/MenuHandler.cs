using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuHandler : MonoBehaviour
{
    public static string PlayerName = "name";
    public TMP_InputField nameField;

    public void StartGame()
    {
        PlayerName = nameField.text;
        SceneManager.LoadScene("Main Scene");
    }
}
