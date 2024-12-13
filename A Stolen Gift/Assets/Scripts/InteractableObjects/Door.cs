using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float InteractionDistance;

    public GameObject InteractiveComponent;

    [SerializeField]
    public string doorOpenAnimName, doorCloseAnimName;


    [SerializeField]
    public Collider Collider;

    void Update()
    {
            if (Collider.gameObject.tag == "Door")
            {
                GameObject doorParent = Collider.transform.root.gameObject;
                Animator doorAnim = doorParent.GetComponent<Animator>();

                InteractiveComponent.SetActive(true);
                if (Collider.isTrigger && Input.GetKeyDown(KeyCode.E))
                {
                if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        
                        doorAnim.ResetTrigger("Open");
                        doorAnim.SetTrigger("Close");
                    }
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        doorAnim.ResetTrigger("Close");
                        doorAnim.SetTrigger("Open");
                    }
                }
            }
            else
            {
                InteractiveComponent.SetActive(false);
            }
    }
}
