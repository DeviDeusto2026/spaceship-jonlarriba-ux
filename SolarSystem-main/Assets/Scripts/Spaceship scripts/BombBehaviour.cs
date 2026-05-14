using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float explosionTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer -= Time.deltaTime;
        if (explosionTimer <= 0)
        {
            PlayerData.remainingBombs--;
            Destroy(this.gameObject);
        }
    }
}
