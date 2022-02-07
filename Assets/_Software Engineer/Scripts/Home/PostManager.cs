using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace _Software_Engineer.Scripts.Home
{
    public class PostManager : MonoBehaviour
    {

        #region Fields

        [Header("Texts")] [Space(5)]
        [SerializeField] private TMP_Text accountName;
        [SerializeField] private TMP_Text views;
        [SerializeField] private TMP_Text comments;
    
        [Space(12)] [Header("Buttons")] [Space(5)]
        [SerializeField] private Button ellipsisButton;
        [SerializeField] private Button reactButton;
        [SerializeField] private Button unReactButton;
        [SerializeField] private Button commentButton;
        [SerializeField] private Button shareButton;
        [SerializeField] private Button addToCollectionButton;
        [SerializeField] private ButtonDoubleClickListener imageHolder;
    
        private GameObject _commentsScene;
        private GameObject _shareScene;
        private GameObject _ellipsisScene;

        #endregion
        
        /// <summary>
        /// Call this function when you want to assign the name of the account or user
        /// </summary>
        /// <param name="userAccountName"> Pass the name of the account or user </param>
        public void SetAccountName(string userAccountName)
        {
            accountName.text = userAccountName;
        }

        /// <summary>
        /// Call this function when you want to assign the view count of the post
        /// </summary>
        /// <param name="viewsOfThePost"> Pass the number of views in string </param>
        public void SetViews(string viewsOfThePost)
        {
            views.text = viewsOfThePost;
        }

        /// <summary>
        /// Call this function when you want to assign the first comment of the post
        /// This will show only the first comment
        /// Please, assign the 1st comment only
        /// </summary>
        /// <param name="commentOfThePost"> Pass the 1st comment </param>
        public void SetFirstComment(string commentOfThePost)
        {
            comments.text = commentOfThePost;
        }

        #region OnClick Functions

        /// <summary>
        /// This function will be called when the "Image_Holder" will be pressed twice.
        /// </summary>
        public void On_Click_ImageHolder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function will be called when the "Button_AddToCollection" will be pressed.
        /// </summary>
        public void On_Click_AddToCollectionButton()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function will be called when the "Button_Share" will be pressed.
        /// </summary>
        public void On_Click_ShareButton()
        {
            _shareScene.GetComponent<SlideingUI>().SlideUp();
        }

        /// <summary>
        /// This function will be called when the "Button_Comment" will be pressed.
        /// </summary>
        public void On_Click_CommentButton()
        {
            _commentsScene.GetComponent<SlideingUI>().SlideUp();
        }

        /// <summary>
        /// This function will be called when the "Button_UnReact" will be pressed.
        /// </summary>
        public void On_Click_UnReactButton()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function will be called when the "Button_React" will be pressed.
        /// </summary>
        public void On_Click_ReactButton()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function will be called when the "Button_Ellipsis" will be pressed.
        /// </summary>
        public void On_Click_EllipsisButton()
        {
            _ellipsisScene.GetComponent<SlideingUI>().SlideUp();
        }

        #endregion
    
        #region Private Methods

        private void Start()
        {
            Assert.IsNotNull(ellipsisButton);
            Assert.IsNotNull(reactButton);
            Assert.IsNotNull(unReactButton);
            Assert.IsNotNull(commentButton);
            Assert.IsNotNull(shareButton);
            Assert.IsNotNull(addToCollectionButton);
        
            ellipsisButton.onClick.AddListener(On_Click_EllipsisButton);
            reactButton.onClick.AddListener(On_Click_ReactButton);
            unReactButton.onClick.AddListener(On_Click_UnReactButton);
            commentButton.onClick.AddListener(On_Click_CommentButton);
            shareButton.onClick.AddListener(On_Click_ShareButton);
            addToCollectionButton.onClick.AddListener(On_Click_AddToCollectionButton);
            imageHolder.onDoubleClick.AddListener(On_Click_ImageHolder);
        
            _commentsScene = GameObject.Find("Comments");
            _shareScene = GameObject.Find("Share");
            _ellipsisScene = GameObject.Find("Ellipsis");
        }

        #endregion

    }
}
