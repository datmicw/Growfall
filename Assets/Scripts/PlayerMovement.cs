using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    public Vector3 collisionVelocity = new Vector3(25f, 5f, 10f);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Start")) // Kiểm tra tag "Start"
        {
            Debug.Log("Start");

            // tạo hướng bật ngược lại
            Vector3 bounceDirection = transform.position - collision.transform.position;
            bounceDirection.y = 1f; // bật lên theo trục Y

            // áp lực bật ra (ForceMode.Impulse để áp lực tức thời)
            rb.AddForce(bounceDirection.normalized * collisionVelocity.magnitude, ForceMode.Impulse);
        }
    }

}
