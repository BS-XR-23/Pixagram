using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostController : MonoBehaviour
{
    public Transform parent;
    public PostCell prefab;
    public int numberOfItem = 10;
    public List<Sprite> sprites;
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
    }

   
}
