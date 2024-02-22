using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChild : MonoBehaviour
{
    public GameObject parentObject; // Assign the parent object in the Unity Editor

    void Start()
    {
        // Ensure the parent object is assigned
        if (parentObject != null)
        {
            // Set this object as a child of the parent object
            transform.parent = parentObject.transform;
        }
        else
        {
            UnityEngine.Debug.LogWarning("Parent object is not assigned.");
        }
    }
}
