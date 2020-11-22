using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
   public GameObject detectClicks;
   private bool hard;

    void Update() {
        if (CubeJump.count_blocks > 0) {    
            if (CubeJump.count_blocks % 7 == 0 && !hard) {
                Debug.Log("Hard");
                Camera.main.GetComponent<Animation>().Play("Harder");
                detectClicks.transform.position = new Vector3 (9.2f, -1.3f, 1.854752f);
                detectClicks.transform.eulerAngles = new Vector3 (32.178f, -50.259f, 0f);
                hard = true;
            } else if ((CubeJump.count_blocks % 7) - 1  == 0 && hard) {
                hard = false;
                Debug.Log("Easier");
                detectClicks.transform.position = new Vector3 (0f,0f,-7.88f);
                detectClicks.transform.eulerAngles = new Vector3 (0f,0f,0f);
                Camera.main.GetComponent<Animation>().Play("Easier");
            }
        }
    }
}
