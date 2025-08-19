using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuHandler : MonoBehaviour
{
    // ENCAPSULATION
    private static string playerName = "name";

    public static string PlayerName
    {
        get => playerName;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                playerName = "name";
            }
            else
            {
                // Ограничиваем длину 8 символами
                playerName = value.Length > 8 ? value.Substring(0, 8) : value;
            }
        }
    }

    public TMP_InputField nameField;

    public void StartGame()
    {
        PlayerName = nameField.text;
        SceneManager.LoadScene("Main Scene");
    }
}
