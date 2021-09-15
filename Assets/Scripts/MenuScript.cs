using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Button startButton;
    private TMP_InputField nameInput;

    [SerializeField] private int maxCharNameLength;

    // ENCAPSULATION
    private string _playerName;
    public string PlayerName {
        get { return _playerName; }
        set
        {
            if (value.Length != 0)
            {
                _playerName = value;
                startButton.interactable = true;
            }
            else
            {
                startButton.interactable = false;
            }
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = false;
        nameInput = GetComponentInChildren<TMP_InputField>();
        nameInput.characterLimit = maxCharNameLength;
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
