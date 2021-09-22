using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName; 

    // Start is called before the first frame update
    void Start()
    {
        if (playerName != null)
        {
            playerName.SetText("Player: " + GameManager.Instance.PlayerName);
        }
    }
}
