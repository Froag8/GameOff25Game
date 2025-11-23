using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 5f;
    public float rotationspeed = 200f;
    private Rigidbody2D rb;
    private float moveInput;
    private float rotateInput;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");

        rotateInput = -Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }

    }

    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation + rotateInput * rotationspeed * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + (Vector2)transform.up * moveInput * movespeed * Time.fixedDeltaTime);
    }

}
