using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShoot : MonoBehaviour
{
    public InputActionReference shoot;
    public InputActionReference bomb;
    public GameObject bullet;
    public GameObject bombObject;
    public GameObject bulletSpawner;
    public float force;
    public float bombForce;

    private Quaternion q;
    private RaycastHit hit;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        q = new Quaternion(0, 0, 0, 0);
        shoot.action.started += shootDown;
        bomb.action.started += bombDown;
    }

    void shootDown(InputAction.CallbackContext context)
    {
        GameObject newBullet = Object.Instantiate(bullet, bulletSpawner.transform.position, q);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        audioSource.PlayOneShot(shootSound);    
    }

    void bombDown(InputAction.CallbackContext context)
    {
        GameObject newBomb = Object.Instantiate(bombObject, bulletSpawner.transform.position, q);
        newBomb.GetComponent<Rigidbody>().AddForce(transform.forward * bombForce, ForceMode.Impulse);
        audioSource.PlayOneShot(shootSound);
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
