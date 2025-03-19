using System;
using UnityEngine;

public class AreaSound : MonoBehaviour
{
    [SerializeField] private int areaSoundIndex;
    [SerializeField] private int areaBgmIndex = -1; // Set to -1 if no specific BGM should play
    
    private bool playerInArea = false;
    private int previousBgmIndex = -1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            // Play the area-specific sound effect
            AudioManager.instance.PlaySFX(areaSoundIndex, null);
            
            // If we have a specific BGM for this area
            if(areaBgmIndex >= 0)
            {
                // Store current BGM index for later
                for (int i = 0; i < AudioManager.instance.GetBgmLength(); i++)
                {
                    if (AudioManager.instance.IsBgmPlaying(i))
                    {
                        previousBgmIndex = i;
                        break;
                    }
                }
                
                // Play the area-specific background music directly
                // This calls StopAllBGM internally
                AudioManager.instance.playBgm = true;
                AudioManager.instance.PlayBGM(areaBgmIndex);
            }
            
            playerInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            AudioManager audioManager = AudioManager.instance;
            
            if(audioManager != null)
            {
                // Stop the area-specific sound effect
                audioManager.StopSFXWithTime(areaSoundIndex);
                
                // If we changed the BGM when entering this area
                if(areaBgmIndex >= 0)
                {
                    // Stop the area-specific background music
                    audioManager.StopAllBGM();
                    
                    // Restore the previous BGM if there was one
                    if(previousBgmIndex >= 0)
                    {
                        audioManager.playBgm = true;
                        audioManager.PlayBGM(previousBgmIndex);
                    }
                    else
                    {
                        // If there was no previous BGM, play random or default
                        audioManager.playBgm = true;
                        audioManager.PlayRandomBGM();
                    }
                }
            }
            
            playerInArea = false;
        }
    }
}