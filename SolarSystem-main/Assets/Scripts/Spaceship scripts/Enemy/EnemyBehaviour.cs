using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float velocity;

    private Transform spaceship;
    private int health = 3;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject par = GameObject.Find("Spaceship/13.1");
        spaceship = par.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(spaceship);

        transform.position += rb.transform.TransformDirection(Vector3.forward) * velocity;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            health--;
            Debug.Log(health);
        }
    }
}
