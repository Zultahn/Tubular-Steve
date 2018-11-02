using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerPower : MonoBehaviour {

    [SerializeField]
    private Camera playcam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currCamRotX = 0f;
    private Vector3 JumpForce = Vector3.zero;


    [SerializeField]
    private float CamRotLimit= 85f;


    private Rigidbody rb;

    void Start()
        {
        rb = GetComponent<Rigidbody>();

    }

    // recieves movement vector
        public void Move (Vector3 _velocity)
    {
        velocity = _velocity;

    }
    // recieves rotate vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;

    }
    // recieves camerarotate vector
    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;

    }
    public void ApplyJump (Vector3 _jumpForce)
    {
        JumpForce = _jumpForce;

    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
    // Performs movement based on velocity
    void PerformMovement ()
    {
        if(velocity!=Vector3.zero)
        {
            //moves player to the position of our player+velocity
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
       
        }
        if(JumpForce!=Vector3.zero)
        {
            rb.AddForce(JumpForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
        if (playcam != null)
        {
            //set rot & clamped rot to stop looking behind. Cam limit.
            currCamRotX -= cameraRotationX;
            currCamRotX = Mathf.Clamp(currCamRotX, -CamRotLimit, CamRotLimit);

            playcam.transform.localEulerAngles = new Vector3(currCamRotX, 0f, 0f);
        }
    }

}
