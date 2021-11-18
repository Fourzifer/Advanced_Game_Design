using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAbility : MonoBehaviour
{

    public PlayerMovement player;

    public Rigidbody rb;



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Has Wall Climb");
            Pickup(other.gameObject.GetComponent<PlayerMovement>());
            
        }







    }


    void Pickup(PlayerMovement player)
    {

        player.HaveWallClimb = true;
        Destroy(gameObject);



    }




}
