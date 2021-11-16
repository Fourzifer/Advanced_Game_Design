using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private bool switchIsActive;
    [SerializeField] private GameObject door;
    [SerializeField] private int switchType;
    public static int totalPlayers;

    private void Update()
    {
        /*requires 2 pressure plates
        (a known bug is that two players could stand on the same pressure plate)*/
        if (totalPlayers == 2 && door != null)
        {
            Debug.Log("Door destroyed");
            Destroy(door);
            totalPlayers = 0;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && door != null)
        {
            switch (switchType)
            {
                case 1:
                    switchIsActive = true;
                    Debug.Log("Opened");
                    door.SetActive(false);
                    return;
                case 2:
                    switchIsActive = true;
                    Debug.Log("Door destroyed");
                    Destroy(door);
                    return;
                case 3:
                    totalPlayers++;
                    Debug.Log(totalPlayers);
                    return;
                default:
                    return;
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        switch (switchType)
        {
            case 3:
                totalPlayers--;
                Debug.Log(totalPlayers);
                return;
            default:
                if (other.gameObject.tag == "Player" && door != null)
                {
                    switchIsActive = false;
                    Debug.Log("Closed");
                    door.SetActive(true);
                }
                return;
        }
    }
}