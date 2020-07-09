   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block, allCubes;
    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 10f;
    private bool onPlace;

    void Start() {
        spawn();
    }

    private void Update()
    {
        if (blockInst.transform.position != blockPos && !onPlace) {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        } else if (blockInst.transform.position == blockPos) {
            onPlace = true;
        }

        if (CubeJump.jump && CubeJump.nextBlock) { 
            spawn ();
            onPlace = false;
        }
    }

    private float RandScale () {
        float rand;
        if (Random.Range (0, 100) > 10) {
            rand = Random.Range (1.2f, 2f);
        } else {
            rand = Random.Range (1.2f, 1.5f);
        }
        return rand;
    }

    void spawn () {
        blockPos = new Vector3(Random.Range(0.9f, 1.6f), Random.Range(-2.5f, 2f), 6.2f);
        blockInst = Instantiate (block, new Vector3(2f, -5.4f, 0f), Quaternion.identity);
        blockInst.transform.localScale = new Vector3 (RandScale (), blockInst.transform.localScale.y, blockInst.transform.localScale.z);
        blockInst.transform.parent = allCubes.transform;
    }
   
}
