using System.Collections;
using UnityEngine;

public class FallCubes : MonoBehaviour
{
   
    void Start() {
       Destroy (gameObject, 1f); 
    }

   
    void Update() {
        transform.position -= new Vector3(0, 0.1f, 0);
    }
}
