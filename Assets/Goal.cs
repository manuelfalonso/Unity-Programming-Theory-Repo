using UnityEngine;

public class Goal : MonoBehaviour
{
    private float originalSize;

    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        originalSize = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float size = Mathf.PingPong(Time.time, originalSize);
        transform.localScale = new Vector3(size, size, size);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
