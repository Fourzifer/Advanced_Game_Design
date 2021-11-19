using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAbility : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;

    public GameObject Textbox;


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
        Instantiate(Textbox, transform.position, Quaternion.identity);
        player1.HaveWallClimb = true;
        player2.HaveWallClimb = true;
        Destroy(gameObject);



    }




}
