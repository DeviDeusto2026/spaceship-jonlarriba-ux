using System.Linq;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float velocity;

    private Transform spaceship;
    private int maxHealth = 200;
    private int health = 200;
    private int[] thresholds;
    private Rigidbody rb;

    [SerializeField] private AudioSource audioSourceMetal;
    [SerializeField] private AudioSource audioSourceExplosion;

    public float oscilationRateMax = 4.0f;
    private float oscilationRate = 4.0f;
    private int dir = 1;
    private float sideSpeed = 0.4f;

    public GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject par = GameObject.Find("Spaceship/13.1");
        spaceship = par.transform;

        GameObject audioMetal = GameObject.Find("AudioSources/EnemyAudioMetal");
        audioSourceMetal = audioMetal.GetComponent<AudioSource>();
        GameObject audio = GameObject.Find("AudioSources/EnemyAudioExplosion");
        audioSourceExplosion = audio.GetComponent<AudioSource>();

        thresholds = new int[3];
        thresholds[0] = (maxHealth * 25) / 100;
        thresholds[1] = (maxHealth * 50) / 100;
        thresholds[2] = (maxHealth * 75) / 100;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(spaceship);
        transform.position += rb.transform.TransformDirection(Vector3.forward) * velocity;
        transform.Rotate(new Vector3(0, 1, 0), 90.0f);

        oscilationRate -= Time.deltaTime;
        if (oscilationRate < 0)
        {
            dir = dir * -1;
            oscilationRate = oscilationRateMax;
        }

        transform.position += rb.transform.TransformDirection(Vector3.forward) * dir * sideSpeed;

        if (health <= 0)
        {
            audioSourceExplosion.Play();
            Destroy(this.gameObject);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            audioSourceMetal.Play();
            health--;
            Debug.Log(health);
            if (thresholds.Contains(health))
            {
                spawnTheHorde();
                velocity += 0.15f;
            }
        }
    }

    private void spawnTheHorde()
    {
        for (int i = 0; i< Random.Range(5, 20); i++)
        {
            Vector3 spawnPosition = calculateSpawnPosition();
            Object.Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
        
    }


    Vector3 calculateSpawnPosition()
    {
        Vector3 v3 = new Vector3(0,0,0);
        v3.x = Random.Range((transform.position.x - 120) + Random.Range(60, 120), (transform.position.x + 120) - Random.Range(60, 120));
        v3.y = Random.Range((transform.position.y - 120) + Random.Range(60, 120), (transform.position.y + 120) - Random.Range(60, 120)); ;
        v3.z = Random.Range((transform.position.z - 120) + Random.Range(60, 120), (transform.position.z + 120) - Random.Range(60, 120)); ;
        return v3;
    }

}

