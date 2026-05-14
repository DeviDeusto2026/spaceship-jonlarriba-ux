using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipMovement : MonoBehaviour
{
    
    private Vector2 movementDirection;
    private Vector2 rotation;
    private Vector2 roll;
    public Rigidbody rigidBody;

    public float velocityMove;
    public float velocityTurn;
    public float rollSpeed;

    public InputActionReference Move;
    public InputActionReference Rotate;
    public InputActionReference Roll;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        movementDirection = Move.action.ReadValue<Vector2>();
        rotation = Rotate.action.ReadValue<Vector2>();
        roll = Roll.action.ReadValue<Vector2>();

        rigidBody.AddForce(rigidBody.transform.TransformDirection(Vector3.forward) * movementDirection.y * velocityMove, ForceMode.VelocityChange);
        rigidBody.AddForce(rigidBody.transform.TransformDirection(Vector3.right) * movementDirection.x * velocityMove, ForceMode.VelocityChange);

        rigidBody.AddTorque(rigidBody.transform.right * velocityTurn * rotation.y * -1, ForceMode.VelocityChange);
        rigidBody.AddTorque(rigidBody.transform.up * velocityTurn * rotation.x, ForceMode.VelocityChange);

        rigidBody.AddTorque(rigidBody.transform.forward * rollSpeed * roll.x, ForceMode.VelocityChange);
    }
}
