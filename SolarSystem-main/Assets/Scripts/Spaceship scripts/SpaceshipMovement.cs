using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipMovement : MonoBehaviour
{
    
    public Vector2 movementDirection;
    public Vector2 rotation;
    public Rigidbody rigidBody;

    public float velocityMove;
    public float velocityTurn;

    public InputActionReference Move;
    public InputActionReference Rotate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

            
    }

    private void FixedUpdate()
    {
        movementDirection = Move.action.ReadValue<Vector2>();
       // Vector2.ClampMagnitude(movementDirection, 1f);
        rotation = Rotate.action.ReadValue<Vector2>();
        //Vector2.ClampMagnitude(movementDirection, 1f);


        rigidBody.AddForce(rigidBody.transform.TransformDirection(Vector3.forward) * movementDirection.y * velocityMove, ForceMode.VelocityChange);
        rigidBody.AddForce(rigidBody.transform.TransformDirection(Vector3.right) * movementDirection.x * velocityMove, ForceMode.VelocityChange);

        rigidBody.AddTorque(rigidBody.transform.right * velocityTurn * rotation.y * -1, ForceMode.VelocityChange);
        rigidBody.AddTorque(rigidBody.transform.up * velocityTurn * rotation.x, ForceMode.VelocityChange);

    }
}
