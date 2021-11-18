using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public PlayerMovement player;

    public Rigidbody rb;



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Has Dash");
            Pickup(other.gameObject.GetComponent<PlayerMovement>());

        }







    }


    void Pickup(PlayerMovement player)
    {

        player.HaveDash = true;
        Destroy(gameObject);



    }

    

}
