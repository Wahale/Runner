using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MoveRoad : MonoBehaviour
{
    public float speed;
    public GameObject Platform;
    public GameObject Coins;
    public Player player;
    public int coinChance;


    private void Start()
    {
        Coins.SetActive(Random.Range(0, 101) <= coinChance);
    }

    void Update()
    {
        if (player.start)
        {
            //if (player.scorePoint >= 100)
            //    speed = 2.5f;

            transform.Translate(Vector3.forward * -speed * Time.deltaTime);

            if (transform.position.z < -7f)
            {
                Instantiate(Platform, new Vector3(0, 0, 22.97f), Quaternion.identity);
                Destroy(Platform.gameObject);
            }
        }
    }
}
