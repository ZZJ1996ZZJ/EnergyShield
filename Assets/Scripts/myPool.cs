using UnityEngine;

public class myPool : BasePool<Gem>
{
    public int spawnAmount = 50;
    public float spawnInterval = 0.5f;
    float spawnTimer;
    void Awake()
    {
        Initialize();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f; 
            Get();
        }
    }
    protected override Gem OnCreatePoolItem()
    {
        var gem = base.OnCreatePoolItem();
        gem.SetDeactivateAction(delegate { Release(gem); });
        return gem;
    }

    protected override void OnGetPoolItem(Gem gem)
    {
        base.OnGetPoolItem(gem);
        gem.transform.position = transform.position + Random.insideUnitSphere * 2f;
    }

    protected override void OnReleasePoolItem(Gem gem)
    {
        base.OnReleasePoolItem(gem);
    }
}
