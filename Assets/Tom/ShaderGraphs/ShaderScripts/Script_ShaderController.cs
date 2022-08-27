using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Script_ShaderController : MonoBehaviour
{
    [SerializeField] Material material;
    private LocalKeyword spriteOutlineKeyword;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;

        spriteOutlineKeyword = new LocalKeyword(material.shader, "_SPRITEOUTLINE");
    }


    private void OnMouseEnter()
    {
        EnableOutline();
    
    }

    private void OnMouseExit()
    {
        DisableOutline();
    }



    public void EnableOutline()
    {
        material.EnableKeyword(spriteOutlineKeyword);
    }

    public void DisableOutline()
    {
        material.DisableKeyword(spriteOutlineKeyword);
    }
    
}
