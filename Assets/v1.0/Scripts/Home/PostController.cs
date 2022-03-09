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

    [Space(2)]
    [Header("FullScreenModel")]
    [SerializeField]
    private GameObject fullscreenPanel;
    [SerializeField]
    private GameObject modelTarget;

    [Space(2)]
    [Header("DragController")]
    [SerializeField]
    DraggingController _draggingController;
    [SerializeField]
    Transform _defaultModel;
    private Vector3 defaultPosition;
    private Vector3 defaultScale;

    [SerializeField]
    public Dictionary<string, Product2> models = new Dictionary<string, Product2>();
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
        _defaultModel.gameObject.SetActive(false);
        defaultPosition = _defaultModel.position;
        defaultScale= modelTarget.transform.localScale;
        userId = Constant.ownerId;
        print($"Models:{models.Count}");

        _ = OpenSeaAssetsAsync();

    }
    private void FullScreen(Product2 product)
    {
        fullscreenPanel.SetActive(true);
        _defaultModel.gameObject.SetActive(false);
        GameObject obj = Instantiate(product.styleObject.gameObject, modelTarget.transform);
        Rigidbody rb = obj.AddComponent<Rigidbody>();
        rb.angularDrag = _defaultModel.GetComponent<Rigidbody>().angularDrag;
        rb.useGravity = _defaultModel.GetComponent<Rigidbody>().useGravity;
        obj.AddComponent<BoxCollider>().isTrigger = true;
        obj.name = product.product_name;
        modelTarget.transform.localScale = defaultScale;
        if (product.category == "outfit")
        {
            print("outfit");
            obj.transform.localScale = _defaultModel.localScale + new Vector3(250, 250,250);
            obj.transform.position = defaultPosition + new Vector3(0, -2.7f, 0);
        }
        else
        {
            obj.transform.localScale = _defaultModel.localScale - new Vector3(20, 20, 20);
            obj.transform.position = _defaultModel.position;
        }
        
        obj.transform.rotation = _defaultModel.rotation;
        _draggingController.target = obj.transform;
        _draggingController._zoomTarget = modelTarget.transform;
    }
    public void Close()
    {
        DestroyImmediate(_draggingController.target.gameObject);
    }

    private async Task OpenSeaAssetsAsync()
    {
        string url = $"{APIEndPoints.assets }?owner={userId}&order_direction=asc&offset=0&limit=40";
        print(url);
        Asset openSeaAssetDatas = await APIRequestFactory.Instance.Get<Asset>(url, false, "");
        OpenSeaAssetData[] assets = openSeaAssetDatas.assets;
        print($"Length:{openSeaAssetDatas.assets.Length}");
        foreach (OpenSeaAssetData openSeaAssetData in assets)
        {
            if (gameObject==null) return;
            Product obj = Instantiate(product, parent);
            obj.name = openSeaAssetData.name;
            obj.transform.SetSiblingIndex(Random.Range(0, parent.childCount));
            
            Product2 model = models.ContainsKey(openSeaAssetData.name)? models[openSeaAssetData.name]:null;
            obj.fullscreen.onClick.AddListener(() =>
            {
                if (model != null)
                {
                    model.product_name = openSeaAssetData.name;
                    FullScreen(model);
                }
            });
           
            obj.Init(openSeaAssetData.name, WEI_TO_ETH(openSeaAssetData.sell_orders[0].base_price), openSeaAssetData.description, openSeaAssetData.permalink, model, openSeaAssetData.image_url);
        }
       
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
