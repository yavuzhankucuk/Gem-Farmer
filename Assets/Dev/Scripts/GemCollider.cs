using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class GemCollider : MonoBehaviour
{
    GemStack Stack;
    public GemData gemData;
    Vector3 emptyGemLocation;
    public bool collectable = false;
    public bool collected=false;
    MeshCollider meshCollider;
    public Tweener scaleTweener;
    bool killed = false;
    public Vector3 collectedScale;
    public Vector3 collectableTreshold =new(0.25f, 0.25f, 0.25f);
    public float salePrice;
    private void Start()
    {   
        Stack = FindObjectOfType<GemStack>();
        emptyGemLocation = this.gameObject.transform.position;
        this.gameObject.tag = "Gem";
        meshCollider = GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            meshCollider.enabled=false;
            meshCollider.convex = true;
            meshCollider.isTrigger = true;
        }
        DOTween.Init();
        scaleTweener = this.transform.DOScale(1f, 5f);
    }

    private void Update()
    {
        if (!collected)
        {
            collectedScale = gameObject.transform.localScale;
            salePrice = gemData.initialPrice+(100*gameObject.transform.localScale.x);
            if ((gameObject.transform.localScale.x > collectableTreshold.x) && killed == false)
            {
                meshCollider.enabled = true;
                collectable = true;
            }
        }               
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && collectable && Stack.gemStack.Count != Stack.maxStackSize)
        {           
            // instead of its own, creating a new gem
            GemGridGenerator gridGenerator = FindObjectOfType<GemGridGenerator>();
            scaleTweener.Kill();
            killed = true;
            gridGenerator.SpawnNewGem(emptyGemLocation);            
        }
        
    } 
}
