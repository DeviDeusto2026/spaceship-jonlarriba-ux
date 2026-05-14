using UnityEngine;
using UnityEngine.Audio;

public class enemySpawner : MonoBehaviour
{
    public float timeLeft = 2.0f;
    private float untilBossSpawn;
    public GameObject enemy;

    public GameObject bossSpawner;

    [SerializeField] private AudioSource startTrack;

    public GameObject panelBeforeBoss;
    public GameObject panelAfterBoss;

    private void Start()
    {
        panelAfterBoss.SetActive(false);
        panelBeforeBoss.SetActive(true);
        untilBossSpawn = PlayerData.timeUntilBoss;
        bossSpawner.SetActive(false);
        startTrack.Play();
    }
    void Update()
    {
        untilBossSpawn -= Time.deltaTime;
        PlayerData.timeUntilBoss -= Time.deltaTime;
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Vector3 v3 = calculateSpawnPosition();
            Object.Instantiate(enemy, v3, Quaternion.identity);
            timeLeft = 1.0f;
        }
        if(untilBossSpawn < 0)
        {
            panelAfterBoss.SetActive(true);
            panelBeforeBoss.SetActive(false);
            bossSpawner.SetActive(true);
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
