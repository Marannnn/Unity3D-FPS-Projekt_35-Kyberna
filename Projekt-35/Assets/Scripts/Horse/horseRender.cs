using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseRender : MonoBehaviour
{
    public GameObject Horse;
    public GameObject horsePlaceHolder;
    void Update()
    {
        horsePlaceHolder.transform.position = Horse.transform.position - new Vector3(0, 1.5f, 0f);
    }
}
