using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour
{

    public GameObject [] cubes;
    public GameObject buttons, mainCube, spawn_blocks;
    public Text tapToPlayTxt, logoTxt, study;
    public Animation cubes_anim, block;
    public Light dirLight, dirLight2;

    private bool clicked;

    private void Update() {
       if (clicked && dirLight.intensity != 0) {
           dirLight.intensity -= 0.03f;
       }
    }
    
    private void OnMouseDown() {
        if (!clicked) {
            StartCoroutine(delCubes());
            clicked = true;
            tapToPlayTxt.gameObject.SetActive(false);
            logoTxt.text = "0";
             study.gameObject.SetActive(true);
            logoTxt.GetComponent<Animation>().Play("StartLogo");
            logoTxt.alignment = TextAnchor.MiddleCenter;  
            buttons.GetComponent<Animation>().Play("StartBtn");
            mainCube.GetComponent<Animation>().Play("StartGame");
            StartCoroutine(cubeToBlock());
            mainCube.transform.localScale = new Vector3 (1f, 1f, 1f);
            cubes_anim.Play();
            
        } else  if (clicked && study.gameObject.activeSelf) {
            study.gameObject.SetActive(false);
        }
    }

    IEnumerator delCubes () {
        //Add RigidBody component
        mainCube.AddComponent<Rigidbody> ();
        for (int i=0; i < 3; i++) {
            yield return new WaitForSeconds(0.33f);
            cubes[i].GetComponent<FallCubes>().enabled = true;
        }
        spawn_blocks.GetComponent<SpawnBlocks>().enabled = true;
    }

      IEnumerator cubeToBlock () {
        yield return new WaitForSeconds(mainCube.GetComponent<Animation>().clip.length - 0.1f);
        block.Play();
    }


}
