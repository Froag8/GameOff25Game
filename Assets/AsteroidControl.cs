using UnityEngine;
using System.Collections;

public class AsteroidControl : MonoBehaviour
{
    private float leftEdge, rightEdge, topEdge, bottomEdge;
    public GameObject asteroidPrefab;
    public float spawnInterval = 1.5f;

    void Start()
    {
        UpdateWorldBounds();
        StartCoroutine(SpawnLoop());
    }

    void UpdateWorldBounds()
    {
        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        leftEdge = bottomLeft.x;
        rightEdge = topRight.x;
        bottomEdge = bottomLeft.y;
        topEdge = topRight.y;
    }

    Vector2 GetRandomSpawnPosition()
    {
        int edge = Random.Range(0, 4);
        Vector2 spawnPos = Vector2.zero;

        if (edge == 0)
        {
            float y = Random.Range(bottomEdge, topEdge);
            spawnPos = new Vector2(leftEdge - 1f, y);
        }
        else if (edge == 1)
        {
            float y = Random.Range(bottomEdge, topEdge);
            spawnPos = new Vector2(rightEdge + 1f, y);
        }
        else if (edge == 2)
        {
            float x = Random.Range(leftEdge, rightEdge);
            spawnPos = new Vector2(x, topEdge + 1f);
        }
        else
        {
            float x = Random.Range(leftEdge, rightEdge);
            spawnPos = new Vector2(x, bottomEdge - 1f);
        }

        return spawnPos;
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Vector2 spawnPos = GetRandomSpawnPosition();
            Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            Instantiate(asteroidPrefab, spawnPos, randomRot);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
