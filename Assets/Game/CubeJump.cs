using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    public static bool nextBlock, jump;
    public GameObject mainCube, btnRestart;
    private bool animate, lose;
    private float scratch_speed = 0.7f, startTime, yPosCube;
    public static int count_blocks ;

    private void PressCube (float force) {
        mainCube.transform.localPosition += new Vector3 (0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3 (0f, force * Time.deltaTime, 0f);
    }

    private void Start()
    {
        StartCoroutine (CanJump ());
    }

    private void FixedUpdate() {
        if (animate && mainCube.transform.localScale.y > 0.4f) {
            PressCube(-scratch_speed);
        } else if (!animate && mainCube != null) {
            if (mainCube.transform.localScale.y < 1f) {
                PressCube(scratch_speed * 3f);
            } else if (mainCube.transform.localScale.y != 1f) {
                mainCube.transform.localScale = new Vector3 (1f, 1f, 1f);
            }
        }
        if (mainCube != null) {
            if (mainCube.transform.position.y < -10f) {
                Destroy(mainCube, 0.5f);
                Debug.Log("Player Lose"); 
                lose = true;
            }
        } 
        if (lose) {
           btnRestart.gameObject.SetActive(true);
        } 
    }

    private void OnMouseDown() {
        if (mainCube.GetComponent<Rigidbody> () && nextBlock ) { 
        animate = true;
        startTime = Time.time;
        yPosCube = mainCube.transform.localPosition.y;
        }
    }

    private void OnMouseUp() {
        if (mainCube.GetComponent<Rigidbody> () && nextBlock ) { 
        animate = false;
        //jump = true;
        float force, dif;
        dif = Time.time - startTime;
        if (dif < 3f) {
            force = 190 * dif;
        }  else {
            force =300f; 
        }
        if (force < 60f) {
            force = 60f; 
        } 
        mainCube.GetComponent <Rigidbody> ().AddRelativeForce (mainCube.transform.up * force);
        mainCube.GetComponent <Rigidbody> ().AddRelativeForce (mainCube.transform.right * -force);
        StartCoroutine(checkCubePos ());
        nextBlock = false;
        }
    }

    IEnumerator checkCubePos () {
        yield return new WaitForSeconds(1.5f);
        if (yPosCube < mainCube.transform.localPosition.y + 0.05f && yPosCube > mainCube.transform.localPosition.y - 0.05f ) {
            Debug.Log("Player Lose");
            lose = true;
        } else {
            while (!mainCube.GetComponent<Rigidbody>().IsSleeping()) {
            yield return new WaitForSeconds (0.05f);
            if (mainCube == null)
                break;
            }
            if (!lose) { 
                nextBlock = true;
                jump = true;
                count_blocks++;
                Debug.Log("Next one");
                mainCube.transform.eulerAngles = new Vector3 (0f, mainCube.transform.eulerAngles.y, 0f);
            }
        }
    }

    IEnumerator CanJump () {
        while (!mainCube.GetComponent<Rigidbody>())
        yield return new WaitForSeconds (0.05f);
        yield return new WaitForSeconds (1f);
        nextBlock = true;
    }

}