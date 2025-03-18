using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            dialogue.SetActive(true);

        if (Input.GetMouseButtonDown(1))
            dialogue.SetActive(false);
    }

}
