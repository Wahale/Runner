using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCoins : MonoBehaviour
{
    public float speed;
    public Player player;
    public GameObject Coins;

    private void Start()
    {
        //StartCoroutine(SpawnCoins());
    }

    void Update()
    {
        if (player.start)
        {

            transform.Translate(Vector3.up * -speed * Time.deltaTime);

            if (transform.position.z < -7f)
            {
                Destroy(gameObject);
            }

        }
    }

    //IEnumerator SpawnCoins()
    //{
    //    yield return new WaitForSeconds(5f);
    //    Instantiate(scores, new Vector3(positions[Random.Range(0, positions.Length)], -0.703f, 7.87f), Quaternion.Euler(new Vector3(90, 0, 0)));
    //    if (transform.position.z < -7f)
    //        Destroy(gameObject);

    //}

   
}
