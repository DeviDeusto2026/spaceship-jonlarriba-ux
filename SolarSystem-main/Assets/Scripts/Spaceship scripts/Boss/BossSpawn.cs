using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] private AudioSource bossTrack;
    [SerializeField] private AudioSource bossSpawnClip;

    public GameObject Sun; // to deactivate it

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sun.SetActive(false);
        bossTrack.Play();
        bossSpawnClip.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
