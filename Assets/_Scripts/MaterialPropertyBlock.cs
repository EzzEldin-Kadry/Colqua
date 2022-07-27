using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertyBlock : MonoBehaviour
{
    public Color color1;
    private Renderer _renderer;
    private UnityEngine.MaterialPropertyBlock _propBlock;
    void Awake()
    {
        _propBlock = new UnityEngine.MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    } 
    void Update()
    {
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color",color1);
        _renderer.SetPropertyBlock(_propBlock);
    }
}
