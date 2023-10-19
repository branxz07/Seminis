using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outScene : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        transform.LookAt(new Vector3(player.transform.position.x, 0f, 0f));
    }

    void Update()
    {

        if (player.transform.position.x - transform.position.x >= 2.511688f)
        {
            Vector3 start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 end = new Vector3(transform.position.x + 2.52f, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(start, end, Time.deltaTime * 15);
        }
        else if (player.transform.position.x - transform.position.x <= -2.511688f)
        {
            Vector3 start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 end = new Vector3(transform.position.x - 2.52f, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(start, end, Time.deltaTime * 15);
        }
        if (player.transform.position.y - transform.position.y < 2)
        {
            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, 0f));
        }
    }
    
}
