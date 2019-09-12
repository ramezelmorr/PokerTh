using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModul : MonoBehaviour {



    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite cardBack;

    public int cardIndex; // card endix for the faces array 

    public void ToggleFace(bool showFace)
    {
        if (showFace)  // show the card face 
        {

            spriteRenderer.sprite = faces[cardIndex];

        }
        else    // show the card back
        {

            spriteRenderer.sprite = cardBack;

        }

    }

      void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
}
