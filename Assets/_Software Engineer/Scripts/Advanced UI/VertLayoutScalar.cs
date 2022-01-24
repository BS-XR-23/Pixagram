using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( UnityEngine.UI.VerticalLayoutGroup ) )]
public class VertLayoutScalar : MonoBehaviour 
{
    
    [SerializeField] bool update = true;

    void Update() 
    {
        if ( update ) 
        {
            ScaleRectTransform_TightenGridBounds();
        }
    }

    // Makes our rectTransform bottom aligned to the lowest child
    public void ScaleRectTransform_TightenGridBounds() 
    {
        var verticalLayout = GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        UnityEngine.Assertions.Assert.IsNotNull(verticalLayout);
        float numRows = (float)transform.childCount;
        if ( transform.childCount == 0 )
            return;
        var myFirstChild = transform.GetChild( 0 );
        if ( myFirstChild == null )
            return;
        var childRect = myFirstChild.GetComponent<RectTransform>();
        var childHeight = childRect.rect.height * childRect.localScale.y;
        float totalHeight = ( childHeight + verticalLayout.padding.vertical + verticalLayout.spacing) * numRows;
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, totalHeight );
    }
}