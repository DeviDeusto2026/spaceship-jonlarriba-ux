using UnityEngine;

public class SpaceshipDeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
