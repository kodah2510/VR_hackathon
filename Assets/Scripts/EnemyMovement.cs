using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float x = 0.0f;
    float z = 0.0f;
    float r = 0.41f;

    public Vector2 centerPos;

    public float speed = 0.08f;
    public float stepSize = 0.02f;

    public float angle = 0.0f;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        centerPos = new Vector2(0.0f, 0.0f);

        x = transform.position.x;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        if (angle >= 2 * Mathf.PI) {
            angle = 0.0f;
        }
        x = centerPos.x + r * Mathf.Sin(angle);
        z = centerPos.y + r * Mathf.Cos(angle);
        if (count < 100) {
            Debug.Log(x);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(x, 0, z);
        }
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = new Vector3(x, 1, z);

        count++;


        transform.Translate(x, 0.0f, z);
    }

}
