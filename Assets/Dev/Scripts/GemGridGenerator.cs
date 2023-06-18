using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

[System.Serializable]
public class GemData
{
    public string gemName;
    public float initialPrice;
    public Sprite gemSprite;
    public GameObject gemModel;
      
}

public class GemGridGenerator : MonoBehaviour
{
    public int rows; 
    public int columns; 
    public Transform gridParent;
    [Header("Gem Settings")]
    public float initialGemSize = 0.1f;
    public float finalGemSize = 1f;
    public float sizeChangeDuration = 5f;
    public float spacingBetweenGems = 1f;
    [Header("GemData")]
    public GemData[] gemTypes;
    private float sizeChangeStartTime;
        
    private void Update()
    {
        float normalizedTime = (Time.time - sizeChangeStartTime) / sizeChangeDuration;
        normalizedTime = Mathf.Clamp01(normalizedTime);

        float currentGemSize = Mathf.Lerp(initialGemSize, finalGemSize, normalizedTime);

        ResizeGems(currentGemSize);
    }
    public void GenerateGemGrid()
    {        
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                GemData selectedGem = GetRandomGemType(); //random gem selection


                GameObject gem = Instantiate(selectedGem.gemModel, gridParent); //instantiate the gem from gemprefabs
                GemCollider gemCollider = gem.AddComponent<GemCollider>(); // GemCollider components
                gem.GetComponent<MeshCollider>().enabled = false;
                gem.transform.position = new Vector3(row * spacingBetweenGems, 0, column * spacingBetweenGems);//place the gem with desired spacing and location values.                
                gem.transform.localScale = new Vector3(initialGemSize, initialGemSize, initialGemSize);// setting up the initial size of the gem.               
                gemCollider.gemData = selectedGem;                
            }
        }
        sizeChangeStartTime = Time.time; // save the resize operation starting time.
    }       

    public void SpawnNewGem(Vector3 position)
    {
        GemData selectedGem = GetRandomGemType();
        GameObject gem = Instantiate(selectedGem.gemModel);      
        GemCollider gemCollider = gem.AddComponent<GemCollider>();       
        gemCollider.collectable = false;
        gem.transform.position = position; //place the gem with desired spacing and location values.                
        gem.transform.localScale = new Vector3(initialGemSize, initialGemSize, initialGemSize);// setting up the initial size of the gem.               
        gemCollider.gemData = selectedGem;
    }
    
    

    void ResizeGems(float size)
    {
        foreach (Transform gem in gridParent)
        {
            gem.localScale = new Vector3(size, size, size);
            GemCollider gemData = gem.GetComponent<GemCollider>();
            if (gemData != null && !gemData.collectable && gem.localScale.magnitude > 0.25)
            {
                gem.GetComponent<MeshCollider>().enabled = true;
                gemData.collectable = true; // gem can be collectable
            }
        }
    }

    public GemData GetRandomGemType()
    { 
        int random = Random.Range(0, gemTypes.Length);
        return gemTypes[random];
    }
   
}
