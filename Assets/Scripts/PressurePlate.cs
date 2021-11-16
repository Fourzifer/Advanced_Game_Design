using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private bool switchIsActive;
    [SerializeField] private GameObject door;
    [SerializeField] private int switchType;
    //public static GameObject switchA;
    //public static GameObject switchB;

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
                //case 3:
                //    if (switchA && switchB)
                //    {
                //        Debug.Log("Door destroyed");
                //        Destroy(door);
                //    }
                    return;
                default:
                    return;
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player" && door != null)
        {
            switchIsActive = false;
            Debug.Log("Closed");
            door.SetActive(true);
        }
    }
}