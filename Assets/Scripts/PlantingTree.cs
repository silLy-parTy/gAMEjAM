using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantingTree : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Tree Planted");
        anim.SetBool("IsPlanted", true);
        anim.SetBool("IsGrowing", true);

    }

    public void winScreen()
    {

        SceneManager.LoadScene(3);

    }

}
