using NUnit.Framework;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 90f, 0);    
    
    bool IsOpen = false;


    public void Interact()
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("IsOpen", !IsOpen);
        IsOpen = !IsOpen;
    }
}