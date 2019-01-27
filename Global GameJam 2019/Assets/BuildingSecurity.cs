using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSecurity : MonoBehaviour
{
    public float randStartTime = 0.5f;
    public float randEndTime = 1f;
    public GameObject[] PraeivisPrefabs;
    public GameObject[] Laiptines;


    public bool GuardLetGo = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !GuardLetGo)
        {
            GuardLetGo = true;
            // TODO: Spawn guard
            StartCoroutine(Spawn());
        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            Spawn();
        }
    }

    public IEnumerator Spawn()
    {
        var randTime = Random.Range(randStartTime, randEndTime);
        yield return new WaitForSeconds(randTime);
        // Get Random spawn point
        GameObject SpawnPoint = Laiptines[Random.Range(0, Laiptines.Length - 1)];
        GameObject Target = GameObject.FindGameObjectWithTag("Player");

        var praeivisPrefab = PraeivisPrefabs[Random.Range(0, PraeivisPrefabs.Length)];
        // Instantiate

        var praeivis = Instantiate(praeivisPrefab, SpawnPoint.transform.position, Quaternion.identity);
        praeivis.GetComponent<PraeivisMovement>().target = Target.transform;

        // StartCoroutine(Spawn());
    }
}
