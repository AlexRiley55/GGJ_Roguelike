using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOutfit : MonoBehaviour
{
    public GameObject[] npcCharacters;    

    private Color skin1 = new Color(1f, 0.9f, 0.9f);
    private Color skin2 = new Color(1f, 0.99f, 0.9f);
    private Color skin3 = new Color(0.4f, 0.3f, 0.28f);
    private Color skin4 = new Color(0.71f, 0.5f, 0.4f);

    private void Start()
    {
        int ran = Random.Range(0, npcCharacters.Length);

        foreach(GameObject npcChracter in npcCharacters)
        {
            npcChracter.SetActive(false);
        }

        GameObject Outfit = npcCharacters[ran];
        List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

        foreach(SpriteRenderer spriteRenderer in Outfit.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(spriteRenderer);
            spriteRenderer.gameObject.SetActive(false);
        }

        spriteRenderers[0].color = randomClothColor();

        int ranHair = Random.Range(1, 4);
        SpriteRenderer chosenHair = spriteRenderers[ranHair];
        chosenHair.gameObject.SetActive(true);
        chosenHair.color = randomClothColor();

        int ranSkin = Random.Range(0, 4);
        SpriteRenderer skin = spriteRenderers[4];
        if(ranSkin == 0)
        {
            skin.color = skin1;
        }
        else if (ranSkin == 1)
        {
            skin.color = skin2;
        }
        else if (ranSkin == 2)
        {
            skin.color = skin3;
        }
        else if (ranSkin == 3)
        {
            skin.color = skin4;
        }
        skin.gameObject.SetActive(true);


        int ranMouth = Random.Range(6, 9);
        SpriteRenderer chosenMouth = spriteRenderers[ranMouth];
        chosenMouth.gameObject.SetActive(true);

        spriteRenderers[0].gameObject.SetActive(true);
        spriteRenderers[4].gameObject.SetActive(true);
        spriteRenderers[5].gameObject.SetActive(true);
        spriteRenderers[9].gameObject.SetActive(true);

        Outfit.SetActive(true);
    }

    private Color randomClothColor()
    {
        Color color = new Color(Random.Range(0.1f,0.8f), Random.Range(0.1f, 0.8f), Random.Range(0.1f, 0.8f));        

        return color;
    }
}
