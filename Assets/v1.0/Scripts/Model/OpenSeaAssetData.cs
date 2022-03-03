using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSeaAssetData
{
    public string id;
    public string name;
    public string description;
    public string image_url;
    public string permalink;
    public SellOrder[] sell_orders;
    
}
public class SellOrder
{
    public double current_price;
    public double base_price;
}
