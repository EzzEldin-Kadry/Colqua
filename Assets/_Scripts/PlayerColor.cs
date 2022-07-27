using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public GameObject playerMat; 
    public Color c1,c2,c3;
    public GameManager gm;
    void OnCollisionEnter(Collision collisionInfo)
    {
        
        //Material groundMat = collisionInfo.gameObject.GetComponent<Material>();
        if(collisionInfo.gameObject.tag == "Base Ground")
        {
            Color blockColor = collisionInfo.gameObject.GetComponent<MaterialPropertyBlock>().color1;
            Color c = playerMat.GetComponent<Renderer>().material.color;
            string HexaColor = ColorUtility.ToHtmlStringRGB(c);
            changeColor(HexaColor,ref blockColor);
            gm.updateSteps();
        }
        else if(collisionInfo.gameObject.tag == "Not Base Ground")
        {
            collisionInfo.gameObject.GetComponent<MaterialPropertyBlock>().color1 = playerMat.GetComponent<Renderer>().material.color;
            gm.updateSteps();
        }
            
    }
    void changeColor(string HexaColor,ref Color blockColor)
    {
        if(HexaColor == "FFFFFF")
        {
            playerMat.GetComponent<Renderer>().material.color = blockColor;
            gm.steps--;
        }
        else if(HexaColor == ColorUtility.ToHtmlStringRGB(c1)
                && blockColor == c2)
        {
            playerMat.GetComponent<Renderer>().material.color = c3;
        }
        else if(HexaColor == ColorUtility.ToHtmlStringRGB(c2)
                && blockColor == c1)
        {
            playerMat.GetComponent<Renderer>().material.color = c3;
        }
        else if(HexaColor == ColorUtility.ToHtmlStringRGB(c3)
                && blockColor == c1)
        {
            playerMat.GetComponent<Renderer>().material.color = c1;
        }
        else if(HexaColor == ColorUtility.ToHtmlStringRGB(c3)
                && blockColor == c2)
        {
            playerMat.GetComponent<Renderer>().material.color = c2;
        }
    }
}
//989200 y
//FF0000 r