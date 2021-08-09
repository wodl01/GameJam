using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] PlayerScript player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") player.isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground") player.isGround = false;
    }
}
