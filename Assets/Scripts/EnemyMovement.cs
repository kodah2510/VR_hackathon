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

    
    float minX = -10.0f;
    float maxX = 10.0f;

    float minZ = -10.0f;
    float maxZ = 10.0f;

    GameObject[] rubishArr;
    const int MAX_RUBISHS = 500;
    int rubishIndex = 0;
    float rubishSize = 0.3f;

    int rb_step = 10;
    int count = 0;

    float randR = 5f;
    float randL = 0f;
    float gravity = -0.07f;
    public float thrust =100f;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        centerPos = new Vector2(0.0f, 0.0f);

        x = transform.position.x;
        z = transform.position.z;
        y = transform.position.y;

        rubishArr = new GameObject[MAX_RUBISHS];

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

        if (rubishIndex < MAX_RUBISHS && count % rb_step == 0)
        {

            RubhishGenerate(new Vector3(transform.position.x, transform.position.y, transform.position.z));
            
        }
        count++;

    }

    Vector2 randomPosition()
    {
        Vector2 res;
        res.x = Random.Range(randL, randR);
        res.y = Random.Range(randL, randR);

        return res;
    }

    Vector3 randomVector()
    {
        Vector3 res;
        res.x = Random.Range(randL, randR)>0.5 ? 1 : 0;
        res.y = Random.Range(randL, randR)>0.5 ? 1 : 0;
        res.z = Random.Range(randL, randR)>0.5 ? 1 : 0;

        return res;
    }

    void RubhishGenerate(Vector3 position)
    {
        Vector2 randomPos = randomPosition(); 
        rubishArr[rubishIndex] = GameObject.CreatePrimitive(PrimitiveType.Cube);
         
        
        rubishArr[rubishIndex].transform.position = new Vector3(position.x + randomPos.x, position.y, position.z + randomPos.y);
        rubishArr[rubishIndex].transform.localScale = new Vector3(rubishSize, rubishSize, rubishSize);
      
        Rigidbody rb = rubishArr[rubishIndex].AddComponent<Rigidbody>() as Rigidbody;

        Vector3 randVec = randomVector();
        Vector3 direction = new Vector3(transform.forward.x*randVec.x, transform.forward.y* randVec.y, transform.forward.x* randVec.z);

        rb.AddForce(direction * thrust);

        rb.mass = rubishSize;
        rb.useGravity = true;
        rubishIndex++;

    }

    IEnumerator Stall()
    {
        yield return new WaitForSeconds(1);
    }
}
