using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStack : MonoBehaviour
{
    GameObject generator;
    

    public float gemStackSpacing = 0.5f;
    public Transform gemStackParent;
    public int maxStackSize = 5;


    public List<GameObject> gemStack = new List<GameObject>();    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            GemCollider gemCollider = other.GetComponent<GemCollider>();
            if (gemCollider != null && !gemCollider.collected && gemCollider.collectable==true && gemStack.Count < maxStackSize)
            {
                CollectGem(gemCollider, other.gameObject);
            }
        }
    }

    void CollectGem(GemCollider gemCollider, GameObject gem)
    {
        gemCollider.collected = true;
        gemCollider.collectable = false;
        gem.GetComponent<MeshCollider>().enabled = false;
        gem.transform.SetParent(gemStackParent); // Gems stacking in the parent.
        gem.transform.localPosition = new Vector3(0, gemStack.Count * gemStackSpacing, 0); // Placing the gem        
        gemStack.Add(gem);

    }
}
