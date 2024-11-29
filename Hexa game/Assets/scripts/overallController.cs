using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overallController : MonoBehaviour
{
    public Maincontroller[] merger;
    [SerializeField]
    private GameObject[] toSpawn;
    // Update is called once per frame
    void Update()
    {
        merger = FindObjectsOfType<Maincontroller>();
        foreach(Maincontroller m in merger)
        {
            if (m.isSpawner)
            {
                int i = Random.Range(0, 3);
                Instantiate(toSpawn[i], m.posToSpawn.position, Quaternion.identity);
                m.isSpawner = false;
            }
        }
    }
}
