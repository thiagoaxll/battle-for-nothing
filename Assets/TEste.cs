using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("J1ButtonA"))
        {
            print("J1ButtonA");
        }
        
        if (Input.GetButtonDown("J2ButtonA"))
        {
            print("J2ButtonA");
        }
        
        if (Input.GetButtonDown("J1ButtonB"))
        {
            print("J1ButtonB");
        }
        
        if (Input.GetButtonDown("J2ButtonB"))
        {
            print("J2ButtonB");
        }
        
        
        if (Input.GetButtonDown("J1ButtonX"))
        {
            print("J1ButtonX");
        }
        
        if (Input.GetButtonDown("J2ButtonX"))
        {
            print("J2ButtonX");
        }
        
        if (Input.GetButtonDown("J1ButtonY"))
        {
            print("J1ButtonY");
        }
        
        if (Input.GetButtonDown("J2ButtonY"))
        {
            print("J2ButtonY");
        }

        print("lt 1: " + Input.GetAxisRaw("J1ButtonRightHorizontal"));
        print("lt 2: " + Input.GetAxisRaw("J2ButtonRightHorizontal"));

        
        print("rt 1: " + Input.GetAxisRaw("J1ButtonRightVertical"));
        print("rt 2: " + Input.GetAxisRaw("J2ButtonRightVertical"));

        
    }
}
