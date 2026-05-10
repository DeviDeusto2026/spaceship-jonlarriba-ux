using UnityEngine;

public class SpaceshipDeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("MAYDAY");
    }
}
