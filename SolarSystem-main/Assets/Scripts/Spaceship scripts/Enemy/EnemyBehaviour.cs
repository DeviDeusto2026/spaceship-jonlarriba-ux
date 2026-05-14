using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float velocity;

    private Transform spaceship;
    private int health = 3;
    private Rigidbody rb;

    [SerializeField] private AudioSource audioSourceMetal;
    [SerializeField] private AudioSource audioSourceExplosion;

    private int bombs;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject par = GameObject.Find("Spaceship/13.1");
        spaceship = par.transform;

        GameObject audioMetal = GameObject.Find("AudioSources/EnemyAudioMetal");
        audioSourceMetal = audioMetal.GetComponent<AudioSource>();
        GameObject audio = GameObject.Find("AudioSources/EnemyAudioExplosion");
        audioSourceExplosion = audio.GetComponent<AudioSource>();

        bombs = PlayerData.remainingBombs;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(spaceship);
        transform.position += rb.transform.TransformDirection(Vector3.forward) * velocity;
        transform.Rotate(new Vector3(0, 1, 0), 90.0f);
        if (health <= 0)
        {
            audioSourceExplosion.Play();
            Destroy(this.gameObject);
        }

        if (bombs != PlayerData.remainingBombs)
        {
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
        }
    }
}
