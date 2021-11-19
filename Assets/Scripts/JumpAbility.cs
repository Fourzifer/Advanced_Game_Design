using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAbility : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Has Jump");
            Pickup(other.gameObject.GetComponent<PlayerMovement>());
            
        }







    }


    void Pickup(PlayerMovement player)
    {

        player1.HaveJump = true;
        player2.HaveJump = true;
        Destroy(gameObject);



    }




}
