using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject originalsPrefab;
    public GameObject levelPrefab;
    public GameObject menue;
    Renderer [] originalMaterials;
    MaterialPropertyBlock [] levelMaterials;
    int matching, notMatching;
    [HideInInspector]public int steps = 0;
    public Text stepsTxt;
    public Text finalstepsTxt;
    void Start()
    {
        GameObject obj = GameObject.Instantiate(originalsPrefab) as GameObject;
        originalMaterials = obj.GetComponentsInChildren<Renderer>();
        stepsTxt.text = "Steps: " + steps;
    }
    void Update()
    {
        matching = notMatching = 0;
        levelMaterials = levelPrefab.GetComponentsInChildren<MaterialPropertyBlock>();
        for(int i=0;i<originalMaterials.Length;i++)
        {
            Color c1 = originalMaterials[i].material.color;
            Color c2 = levelMaterials[i].color1;
            string str1 = ColorUtility.ToHtmlStringRGB(c1);
            string str2 = ColorUtility.ToHtmlStringRGB(c2);
            if(str1 == str2)
            {
                matching++;
            }
            else
            {
                notMatching++;
            }
        }
        Debug.Log("matching colors: " + matching);
        Debug.Log("not matching colors: " + notMatching);
        if(notMatching == 0)
        {
            Debug.Log("YAAAAAAAAAAY");
            endgame();
        }
    }
    public void updateSteps()
    {
        steps++;
        stepsTxt.text = "Steps: " + steps;
    }
    void endgame()
    {
        menue.SetActive(true);
        finalstepsTxt.text = "Steps: " + steps;
        //activate winning window 
    }
}
