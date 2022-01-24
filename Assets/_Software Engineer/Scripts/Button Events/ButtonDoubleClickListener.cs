using UnityEngine ;
using UnityEngine.Events ;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;

[RequireComponent (typeof(Button))]
public class ButtonDoubleClickListener : MonoBehaviour,IPointerClickHandler {
   
   [Tooltip ("Max duration between 2 clicks in seconds")]
   [Range (0.01f, 0.5f)] public float doubleClickDuration = 0.4f;
   public UnityEvent onDoubleClick ;

   private byte _clicks;
   private float _elapsedTime;

   private Button _button ;

   private void Awake () 
   {
      _button = GetComponent<Button> ();
   }

   private void Update () 
   {
      if (_clicks == 1) {
         _elapsedTime += Time.deltaTime ;
         if (_elapsedTime > doubleClickDuration) {
            _clicks = 0 ;
            _elapsedTime = 0f ;
         }
      }
   }

   public void OnPointerClick (PointerEventData eventData) 
   {
      _clicks++;

      if (_clicks == 1)
         _elapsedTime = 0f;
      else if (_clicks > 1) {
         if (_elapsedTime <= doubleClickDuration) 
         {
            _clicks = 0 ;
            _elapsedTime = 0f ;
            if (_button.interactable)
               onDoubleClick?.Invoke () ;
         }
      }
   }

}
