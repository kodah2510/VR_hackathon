using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubishGenerator : MonoBehaviour
{
    const int MAX_RUBISHS = 100;
    GameObject[] rubishArr;

    float minX = -10.0f;
    float maxX = 10.0f;

    float minZ = -10.0f;
    float maxZ = 10.0f;

    float randX = 0.0f;
    float randZ = 0.0f;
    float size = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -0.7f, 0);
        rubishArr = new GameObject[MAX_RUBISHS];
        for (int i = 0; i < MAX_RUBISHS; i++)
        {
            randX = Random.Range(minX, maxX);
            randZ = Random.Range(minZ, maxZ);
            size = Mathf.Clamp(Random.value, 0.3f, 1.0f);
            rubishArr[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            rubishArr[i].transform.position = new Vector3(randX, 3.0f, randZ);
            rubishArr[i].transform.localScale = new Vector3(size, size, size);
            Rigidbody rb = rubishArr[i].AddComponent<Rigidbody>() as Rigidbody;
            rb.mass = size * 5.0f;
            rb.useGravity = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
