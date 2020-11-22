using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlock : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube") {
            Destroy(other.gameObject);
        }
    }
}
