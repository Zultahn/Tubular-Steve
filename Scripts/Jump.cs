
using UnityEngine;



public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    [Range(1, 10)]
    public float jumpVelocity;

    void Update()
    {
        RaycastHit hit;


        if (Input.GetButtonDown("Jump")&& !Input.GetKey("e"))
        {
            if (Physics.Raycast(transform.position, -transform.up, out hit, .6f))
            {
                GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;

            }
        }


    }
}
