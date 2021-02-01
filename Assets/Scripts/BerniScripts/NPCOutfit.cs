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
        }

        spriteRenderers[0].color = randomClothColor();
    }

    private Color randomClothColor()
    {
        Color color = new Color(Random.Range(0.1f,0.8f), Random.Range(0.1f, 0.8f), Random.Range(0.1f, 0.8f));        

        return color;
    }
}
