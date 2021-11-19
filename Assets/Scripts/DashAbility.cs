using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;

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

        player1.HaveDash = true;
        player2.HaveDash = true;
        Destroy(gameObject);



    }

    

}
