using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource deathSound;
    public AudioSource projectileSound;
    public AudioSource playerDeath;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // or if (Input.GetButtonUp("Cancel")) {
            Application.Quit();
        }
    }

    public void PlayDeathSound()
    {
        deathSound.Play();
    }

    public void PlayProjectile()
    {
        projectileSound.Play();
    }

    public void PlayPlayerDeath()
    {
        playerDeath.Play();
    }
}
