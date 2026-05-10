using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShoot : MonoBehaviour
{
    public InputActionReference shoot;
    public GameObject bullet;
    public GameObject bulletSpawner;
    public float force;

    private Quaternion q;
    private RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        q = new Quaternion(90, 90, 90, 0);
        shoot.action.started += shootDown;

    }

    // Update is called once per frame
    void Update()
    {
        
        
            
            
    }

    void shootDown(InputAction.CallbackContext context)
    {
        GameObject newBullet = Object.Instantiate(bullet, bulletSpawner.transform.position, q);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }
    private void FixedUpdate()
    {
        //int layerMask = 1 << 10;
        //layerMask = ~layerMask;

        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        //    Debug.Log("Did hit" + hit.collider.gameObject.name);
        //}
        //else
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //    Debug.Log("not hitting");
        //}

    }
}
