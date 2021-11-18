using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Zero check");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("First check");
            player.transform.parent = other.gameObject.transform;
            Debug.Log("Second check");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}
