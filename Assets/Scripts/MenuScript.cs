using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private int maxCharNameLength;

    // ENCAPSULATION
    private string _playerName;
    public string PlayerName {
        get { return _playerName; }
        set
        {
            if (value.Length == 0 || value.Length > maxCharNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(value)} is required and its max length is {maxCharNameLength}");
            }
            else
            {
                _playerName = value;
                startButton.interactable = true;
            }
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = false;
    }

    public void StartGame()
    {
        GameManager.Instance.PlayerName = PlayerName;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }
}
