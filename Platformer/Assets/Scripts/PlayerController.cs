using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 15f, jumpForce = 30f, gravityScale = 1f;

    private Rigidbody _rb;

    [SerializeField] private bool _isGrounded;
    private float _timer;
    private Camera _mainCamera;
    private Vector3 reflectedVelocity;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        //Time.timeScale = 0.3f;
    }

    private void Update()
    {
        //if (!_isGrounded && FastApproximately(0.0f,_rb.velocity.y,0.1f))
        //{
        //    // Mathf.Abs(_rb.velocity.y);
        //    //Use this: Mathf.Approximately(1.0f, 10.0f / 10.0f)
        //    Debug.LogWarning("Height = " + _rb.transform.position.y);
        //}
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 cameraForward = Vector3.Scale(_mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = (cameraForward * moveVertical + _mainCamera.transform.right * moveHorizontal).normalized;
        
        _rb.AddForce(movement * playerSpeed);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.51f))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        // && FastApproximately(0.0f, _rb.velocity.y, 0.1f)
        if (_isGrounded)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0.0f, _rb.velocity.z);
            Vector3 jump = new Vector3(0.0f, (jumpForce * 10), 0.0f);
            _rb.AddForce(jump);
        }
        
        _rb.AddForce(Physics.gravity * (gravityScale - 1) * _rb.mass);
    }
    public static bool FastApproximately(float a, float b, float threshold)
    {
        return ((a - b) < 0 ? ((a - b) * -1) : (a - b)) <= threshold;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (_isGrounded)
    //    {
    //        ContactPoint contact = collision.GetContact(0);
    //        Vector3 normal = contact.normal;
    //        reflectedVelocity = Vector3.Reflect(_rb.velocity, normal);
    //        _rb.velocity = reflectedVelocity;
    //    }
    //}
}
