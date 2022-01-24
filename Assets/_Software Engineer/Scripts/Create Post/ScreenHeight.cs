using UnityEngine;


namespace Create_Post
{
    public class ScreenHeight : MonoBehaviour
    {
        public RectTransform header;
        //public RectTransform mainImage;
        public RectTransform scrollView;
        
        private float _blankSpaceHeight;
        private void Start()
        {
            _blankSpaceHeight = (Screen.height - (header.sizeDelta.y + Screen.width));
            // Debug.Log("Header Height" + header.sizeDelta.y);
            // Debug.Log("Main Image width" + Screen.width);
            // Debug.Log("Full Screen Height" + Screen.height);
            // Debug.Log("Blank Space Height" + _blankSpaceHeight);
            scrollView.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _blankSpaceHeight);
        }
    }
}
