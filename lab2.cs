using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab2 : MonoBehaviour
{
    float timeAfterDirectionChenge = 0;
    Rigidbody rb;
    int[] speeds;
    int speed = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    int[] changeDirection() 
    {
        print("changing direction");
        int[] speeds = new int[2];
        int frontDirection = Random.Range(0, 3);
        int sideDirection = Random.Range(0, 3);
        switch (frontDirection)
        {
            case 0:
                speeds[0] = 0; break;
            case 1:
                speeds[0] = speed; break;
            case 2:
                speeds[0] = -speed; break;
            default:
                print("Direction change error"); break;
        }
        switch (sideDirection)
        {
            case 0:
                speeds[1] = 0; break;
            case 1:
                speeds[1] = speed; break;
            case 2:
                speeds[1] = -speed; break;
            default:
                print("Direction change error"); break;
        }
        return speeds;
    }


    void Update()
    {
        if (timeAfterDirectionChenge <= 0) {
            speeds = changeDirection();
            timeAfterDirectionChenge = Random.Range(0, 7);
        }
        timeAfterDirectionChenge -= Time.deltaTime;
        rb.MovePosition(new Vector3(this.transform.position.x + speeds[0] * Time.deltaTime, this.transform.position.y,
            this.transform.position.z + speeds[1] * Time.deltaTime));
    }
}
