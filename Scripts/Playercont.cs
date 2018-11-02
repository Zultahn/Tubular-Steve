using UnityEngine;
[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerPower))]
public class Playercont : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float TurnSensitivity= 3f;

    [SerializeField]
    public float JumpForce = 1000f;

    [SerializeField]
    private float jumpPowerBurnSpeed=1f;
    [SerializeField]
    private float jumpPowerRegendSpeed = 1f;
    private float jumpPowerAmount = 1f;

    [Header("Joint Options:")]
    [SerializeField]
    private JointDriveMode jointMode= JointDriveMode.Position;
    [SerializeField]
    private float jointSpring = 20f;
    [SerializeField]
    private float jointMaxForce = 40f;

    private PlayerPower power;
    private ConfigurableJoint joint;

    void Start()
    {
        power = GetComponent<PlayerPower>();
        joint = GetComponent<ConfigurableJoint>();
        SetJointSettings(jointSpring);
    }

    void Update()
        {
       
        //calulates movement velocity
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov; 
        Vector3 _movVertical = transform.forward * _zMov;
        
        //movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //apply movement
        power.Move(_velocity);

        // Rotation calculation for turning and looking around
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * TurnSensitivity;

        //using the rotation
        power.Rotate(_rotation);

        // Calculate Camera rotation Y plane.
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * TurnSensitivity;

        //using the rotation
        power.RotateCamera(_cameraRotationX);
        //jump calc
        Vector3 _jumpForce = Vector3.zero;
        
        jumpPowerAmount = Mathf.Clamp(jumpPowerAmount, 0f, 1f);

        //apply jump
        power.ApplyJump(_jumpForce);
    }
    private void SetJointSettings(float _jointSpring)
    {
        joint.yDrive = new JointDrive { mode = jointMode, positionSpring = _jointSpring, maximumForce = jointMaxForce };
    }
}
