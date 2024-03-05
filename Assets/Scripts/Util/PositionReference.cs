using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PositionReference : MonoBehaviour
{
    public GameObject referenceObject;  // An immutable object acting as a global reference point for in-game need.
    public Vector3 referencePosition;

    // Start is called before the first frame update
    void Start()
    {
        // Example usage: accessing the GameObject's Transform component
        if (referenceObject == null)
        {
            UnityEngine.Debug.LogError(GetType().Name + " is not assigned!");
        }
        else
        {
            referencePosition = referenceObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
