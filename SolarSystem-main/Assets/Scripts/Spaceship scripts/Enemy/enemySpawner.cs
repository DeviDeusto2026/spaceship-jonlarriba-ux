using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float timeLeft = 1.0f;
    public float untilBossSpawn = 10.0f;
    public GameObject enemy;
    private void Start()
    {
        
    }
    void Update()
    {
        untilBossSpawn -= Time.deltaTime;
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Vector3 v3 = calculateSpawnPosition();
            Object.Instantiate(enemy, v3, Quaternion.identity);
            timeLeft = 1.0f;
        }
        if(untilBossSpawn < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    Vector3 calculateSpawnPosition()
    {
        Vector3 v3 = new Vector3(0,0,0);
        v3.x = Random.Range(650, -650);
        v3.y = Random.Range(200, -200);
        v3.z = Random.Range(4500, -700);
        return v3;
    }
}
