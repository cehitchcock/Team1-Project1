using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GhostNavigate : MonoBehaviour
{
    [SerializeField] float count = 0.0f;
    [SerializeField] float timeAtSpawn = 0.0f;


    [SerializeField] Vector2 destinationLocation;
    [SerializeField] Vector2 spawnLocation;
    [SerializeField] Vector2 bezierMidpointCalculated;

    [SerializeField] float midpointMagnitude = 5.0f;

    [SerializeField] GameObject ghostTail;
    [SerializeField] int rotationSpeed = 100;

    private Vector2 positionBeforeMove;
    private Vector2 positionAfterMove;
    private Vector2 movementDirection;
    


    // Start is called before the first frame update

    private void Awake()
    {
        spawnLocation = this.gameObject.transform.position;
        print(spawnLocation.x.ToString() + spawnLocation.y.ToString());

        //pull current time.
        timeAtSpawn = Time.deltaTime;

        midpointMagnitude = Random.Range(5.0f, 10.0f);

    }
    void Start()
    {
        bezierMidpointCalculated = spawnLocation + (destinationLocation - spawnLocation) / 2 + Vector2.up * midpointMagnitude;
    }

    // Update is called once per frame
    void Update()
    {
        positionBeforeMove = this.transform.position;

        if (count < 1.0f)
        {
            count += 1.0f * (Time.deltaTime);

            Vector2 m1 = Vector2.Lerp(spawnLocation, bezierMidpointCalculated, count);
            Vector2 m2 = Vector2.Lerp(bezierMidpointCalculated, destinationLocation, count);
            this.GetComponent<Transform>().position = Vector2.Lerp(m1, m2, count);

            positionAfterMove = this.transform.position;
        }

        movementDirection = positionAfterMove - positionBeforeMove;

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
        ghostTail.transform.rotation = Quaternion.RotateTowards(ghostTail.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

    }
}
