using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
public class PostController : SerializedMonoBehaviour
{
    public Transform parent;
    public PostCell prefab;
    public Product product;
    public int numberOfItem = 10;
    public List<Sprite> sprites;
    private string userId;
    [SerializeField]
    public Dictionary<string, Product2> models;
    void Start()
    {
        for(int i=0;i<numberOfItem;i++)
        {
            PostCell postCell = Instantiate(prefab,parent);
            AccountInfo obj = new AccountInfo();
            obj.AccountName = i + "_Name";
            obj.image = sprites[Random.Range(0, sprites.Count)];

            postCell.ConfigureCell(obj, i);
        }
        userId = Constant.ownerId;
        _ = OpenSeaAssetsAsync();

    }

    private async Task OpenSeaAssetsAsync()
    {
        string url = APIEndPoints.assets + $"?owner={userId}&order_direction=asc&offset=0&limit=40";
        print(url);
        Asset openSeaAssetDatas = await APIRequestFactory.Instance.Get<Asset>(url, false, "");
        OpenSeaAssetData[] assets = openSeaAssetDatas.assets;
        foreach (OpenSeaAssetData openSeaAssetData in assets)
        {

            print($"price:{openSeaAssetData.sell_orders[0].base_price/Mathf.Pow(10,18)}");
            Product obj = Instantiate(product, parent);
            obj.name = openSeaAssetData.name;
            obj.transform.SetSiblingIndex(Random.Range(0, parent.childCount));
            Product2 model = null;
            if(models.ContainsKey(openSeaAssetData.name))
            {
                model= models[openSeaAssetData.name];
            }
            else
            {
                
            }
            obj.Init(openSeaAssetData.name, WEI_TO_ETH(openSeaAssetData.sell_orders[0].base_price), openSeaAssetData.description, openSeaAssetData.permalink, model, openSeaAssetData.image_url);
        }
        print(openSeaAssetDatas.assets.Length);
    }
    private string WEI_TO_ETH(double balance)
    {
        double decimals = 1000000000000000000; // 18 decimals
        double eth = balance / decimals;
        return System.Convert.ToDecimal(eth).ToString();
    }
    private void OnDestroy()
    {
        parent.DestoryAllChild();
    }
}

class Asset
{
    public OpenSeaAssetData[] assets;
}
