using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class horseRidePS : MonoBehaviour
{
    public GameObject Self;
    public GameObject Player;
    public GameObject horsePlaceHolder;
    
    private bool isMounted;


    void Start()
    {
        isMounted = true;
    }
    
    void Update()
    {
        Player.transform.position = Self.transform.position;
        
        if (isMounted && Input.GetKeyDown(KeyCode.E))
        {
            Self.SetActive(false);
            Player.SetActive(true);
            horsePlaceHolder.SetActive(true);
        }
    }
}
