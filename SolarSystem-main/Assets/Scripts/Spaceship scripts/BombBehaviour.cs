using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float explosionTimer;
    [SerializeField] private AudioSource audioSourceExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject audio = GameObject.Find("AudioSources/BombExplosion");
        audioSourceExplosion = audio.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer -= Time.deltaTime;
        if (explosionTimer <= 0)
        {
            audioSourceExplosion.Play();
            PlayerData.isBombing = false;
            PlayerData.remainingBombs--;
            Destroy(this.gameObject);
        }
    }
}
