using UnityEngine;

public class VideoActive : MonoBehaviour
{
    public float timeLeft = 6.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
