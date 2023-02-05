using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingTree : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Tree Planted");
        anim.SetBool("Plant Seed", true)


    }

}
