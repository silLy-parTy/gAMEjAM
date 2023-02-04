using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 3;
    public int currenthealth;

    // Start is called before the first frame update
    void Start()
    {
        
        currenthealth = maxHealth;

    }

    void takeDamage(int amount)
    {

        currenthealth -= amount;

        if(currenthealth <= 0)
        {
            //we're dead.
            //Play death animation
            //fade out to main menu
        }

    }

}
