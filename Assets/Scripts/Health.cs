using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 3;
    public int currenthealth;

    public Animator anim;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numOfFlashes;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
        currenthealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void takeDamage()
    {

        currenthealth--;
        anim.SetBool("Damaged", true);

        StartCoroutine(Invulnerability());

        if (currenthealth <= 0)
        {
            //we're dead.
            //Play death animation
            Debug.Log("YOU DED");
            anim.SetBool("IsDead", true);
            //fade out to main menu
        }

    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes*2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

}
