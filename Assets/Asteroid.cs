using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Transform player;
    public float speed = 3f;
    private float leftEdge, rightEdge, topEdge, bottomEdge;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure it has the tag 'Player'.");
        }

        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        leftEdge = bottomLeft.x;
        rightEdge = topRight.x;
        bottomEdge = bottomLeft.y;
        topEdge = topRight.y;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }

        if (transform.position.x < leftEdge - 2 || transform.position.x > rightEdge + 2 ||
            transform.position.y < bottomEdge - 2 || transform.position.y > topEdge + 2)
        {
            Destroy(gameObject);
        }
    }
}
