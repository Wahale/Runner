using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHomes : MonoBehaviour
{
    public float speed;
    public GameObject homes;
    public Player player;


    void Update()
    {
        if (player.start)
        {

            transform.Translate(Vector3.forward * -speed * Time.deltaTime);

            if (transform.position.z < -7f)
            {
                Instantiate(homes, new Vector3(0, 0, 22.97f), Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
