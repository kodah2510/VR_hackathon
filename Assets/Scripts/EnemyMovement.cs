using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    float r = 10.0f;

    float dx = 0.0f;
    float dy = 0.0f;
    float dz = 0.0f;
    public Vector2 centerPos;

    public float angle = 0.0f;
    float randY = 0.0f;
    bool waiting = false;
    // Start is called before the first frame update
    void Start()
    {
        centerPos = new Vector2(0.0f, 0.0f);

        x = transform.position.x;
        z = transform.position.z;
        y = transform.position.y;

        StartCoroutine(Stall());
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        if (angle >= 2 * Mathf.PI) {
            angle = 0.0f;
        }

        dx = r * Mathf.Sin(angle);
        dz = r * Mathf.Cos(angle);
        randY = 0.8f * r * Mathf.PerlinNoise(dx, dz);
        transform.position = Vector3.Lerp(transform.position , new Vector3(dx, randY, dz), Time.deltaTime);
    }

    IEnumerator Stall()
    {
        yield return new WaitForSeconds(1);
    }
}
