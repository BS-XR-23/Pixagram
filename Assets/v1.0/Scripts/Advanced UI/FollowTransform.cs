using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour 
{
    
    UnityEngine.RectTransform me;
    bool update = true;
    [SerializeField] public position myPosition;
    [SerializeField] UnityEngine.RectTransform following;
    [SerializeField] float xOffset = 0;
    [SerializeField] float yOffset = 0;

    public enum position { above, leftOf, RightOf, below, alignedAtTop, NULL }

    void Start() 
    {
        Setup();
        Follow();
    }

    public void Set( RectTransform follow, float xOff = 0, float yOff = 0, position myPos = position.NULL ) 
    {
        following = follow;
        xOffset = xOff;
        yOffset = yOff;
        if ( myPos != position.NULL ) {
            myPosition = myPos;
        }
    }

    void Update() 
    {
        if (update)
        {
            Follow();
        }
            
    }

    void Setup() 
    {
        me = GetComponent<RectTransform>();
    }

    void Follow() 
    {
        if (following == null)
        {
            return;
        }
        
        float halfOfTheirHeight = (following.rect.height * following.transform.localScale.y) / 2;
        float halfOfTheirWidth = (following.rect.width * following.transform.localScale.x) / 2;
        float halfMyHeight = (me.rect.height * me.transform.localScale.y) / 2;
        float halfMyWidth = (me.rect.width * me.transform.localScale.x) / 2;

        float xDist = halfOfTheirWidth + halfMyWidth;
        float yDist = halfOfTheirHeight + halfMyHeight;

        float x, y;
        switch ( myPosition ) 
        {
            case position.RightOf: 
            {
                x = following.transform.localPosition.x + xDist;
                y = following.transform.localPosition.y; 
                break;
            }
            case position.above: 
            {
                x = following.transform.localPosition.x;
                y = following.transform.localPosition.y + yDist;
                break;
            }
            case position.alignedAtTop: 
            {
                x = following.transform.localPosition.x;
                y = following.rect.height/2 - me.rect.height/2;
                break;
            }
            case position.below: 
            {
                x = following.transform.localPosition.x;
                y = following.transform.localPosition.y - yDist;
                break;
            }
            case position.leftOf: 
            {
                x = following.transform.localPosition.x - xDist;
                y = following.transform.localPosition.y;
                break;
            }
            default: 
            {
                Debug.LogError( "unknown pos" );
                return;
            }
        }

        x += xOffset;
        y += yOffset;

        me.transform.localPosition = new Vector2( x, y );
    }
}
