using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_A_Ghost : MonoBehaviour
{
    [SerializeField] float count = 0.0f;
    [SerializeField] GameObject ghostPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 1.0f)
        {
            count += 0.5f * Time.deltaTime;
        }
        else
        {
            Transform spawnPoint = this.gameObject.transform;
            GameObject newGhost = Instantiate(ghostPrefab, spawnPoint) as GameObject;

            count = count - count;
        }
    }
}
