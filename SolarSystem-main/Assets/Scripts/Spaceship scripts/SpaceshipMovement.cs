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

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        movementDirection = Move.action.ReadValue<Vector2>();
        rotation = Rotate.action.ReadValue<Vector2>();


        rigidBody.AddForce(rigidBody.transform.TransformDirection(Vector3.forward) * movementDirection.y * velocityMove, ForceMode.VelocityChange);
        rigidBody.AddForce(rigidBody.transform.TransformDirection(Vector3.right) * movementDirection.x * velocityMove, ForceMode.VelocityChange);

        rigidBody.AddTorque(rigidBody.transform.right * velocityTurn * rotation.y * -1, ForceMode.VelocityChange);
        rigidBody.AddTorque(rigidBody.transform.up * velocityTurn * rotation.x, ForceMode.VelocityChange);

    }
}
