using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnTime = 3f;
    private float timer = 0f;


    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTime)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        var posicion = transform.position;
        Vector3 newPosition = new Vector3(posicion.x - 1, posicion.y, posicion.z);
        GameObject newObject = Instantiate(objectToSpawn, newPosition, transform.rotation);
        newObject.transform.parent = transform;
    }



}
