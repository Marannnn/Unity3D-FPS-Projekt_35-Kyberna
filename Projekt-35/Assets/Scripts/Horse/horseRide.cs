using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class horseRide : MonoBehaviour
{
    public GameObject self;
    public GameObject Horse;
    public GameObject HorsePlaceholder;

    public float interactionDistance = 10f;

    private bool isMounted = false;
    
    void Update()
    {
        if (Horse != null && Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(transform.position, Horse.transform.position);
            
            if (distance <= interactionDistance)
            {
                isMounted = true;
            }
        }

        if (isMounted)
        {
            Horse.SetActive(true);
            
            self.SetActive(false);
            HorsePlaceholder.SetActive(false);
            isMounted = false;
        }
    }
}
