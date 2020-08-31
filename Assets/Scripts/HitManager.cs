using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public Player player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fence") || collision.gameObject.CompareTag("tree"))
        {
            player.animator.SetTrigger("Hit");
            player.g--;
        }
    }
}
