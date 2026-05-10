using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipMovement : MonoBehaviour
{
    
    public Vector3 movementDirection;
    public Rigidbody rigidBody;

    public float velocity;
    public InputActionReference Move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = Move.action.ReadValue<Vector3>();

        Vector3 newVector = new Vector3(movementDirection.x * velocity * Time.deltaTime, movementDirection.y * velocity * Time.deltaTime, movementDirection.z * velocity * Time.deltaTime);
        this.gameObject.transform.position += newVector;
        Debug.Log(newVector);
    }
}
