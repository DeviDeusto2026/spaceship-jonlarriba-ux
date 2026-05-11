using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform spaceship;
    public int velocity;

    private int health = 3;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(spaceship);

        rb.AddForce(rb.transform.TransformDirection(Vector3.forward) *  velocity * Time.deltaTime, ForceMode.VelocityChange);

        if (health <= 0)
        {
            Destroy(this);
        }
    }
}
