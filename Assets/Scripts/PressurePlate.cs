using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private bool switchIsActive;
    [SerializeField] private GameObject door;
    [SerializeField] private int switchType;
    public static int totalPlayers = 0;
    public static int totalPlayersBlue = 0;

    private void Update()
    {
        //(a known "bug" is that two players could stand on the same pressure plate)
        if (totalPlayers == 2 && switchType == 3 && door != null)
        {
            door.SetActive(false);
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
                    door.SetActive(false);
                    totalPlayersBlue++;
                    Debug.Log("Blue switch: " + totalPlayersBlue);
                    return;
                case 2:
                    switchIsActive = true;
                    door.SetActive(false);
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
            case 1:
                if (other.gameObject.tag == "Player" && door != null && totalPlayersBlue == 1)
                {
                    switchIsActive = false;
                    door.SetActive(true);
                }
                totalPlayersBlue--;
                Debug.Log("Blue switch: " + totalPlayersBlue);
                return;
            case 2:
                return;
            case 3:
                totalPlayers--;
                Debug.Log(totalPlayers);
                return;
            default:
                return;
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    switch (switchType)
    //    {
    //        case 1:
    //            Debug.Log("It's true dude");
    //            switchIsActive = true;
    //            door.SetActive(false);
    //            return;
    //        default:
    //            return;
    //    }
    //}
}