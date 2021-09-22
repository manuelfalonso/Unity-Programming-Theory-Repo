using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string _playerName;
    public string PlayerName
    {
        get => _playerName;
        set => _playerName = value;
    }

    private AudioSource audioS;

    private static GameManager instance;
    public static GameManager Instance 
    { 
        get { return instance; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.Play();
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
