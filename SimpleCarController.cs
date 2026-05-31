using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 70f;

    private float moveInput;
    private float turnInput;

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Jalan
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.fixedDeltaTime);

        // Belok
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.fixedDeltaTime);
    }
}