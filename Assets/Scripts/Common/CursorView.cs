using UnityEngine;

namespace Common
{
    // Set Type Cursor
    public class CursorView : MonoBehaviour
    {
        public LayerMask clickableLayer;
        
        [SerializeField]
        private Texture2D pointer; // normal mouse pointer
        [SerializeField]
        private Texture2D target; // target mouse pointer
        [SerializeField]
        private Texture2D doorway; // doorway mouse pointer
        [SerializeField]
        private Texture2D attack; //attack mouse pointer
   

        void Update()
        {
            // Raycast into scene
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), 
                out hit, 
                50, clickableLayer.value))
            {
                bool door = false;

                if (hit.collider.gameObject.tag == "Doorway")
                {
                    Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                    door = true;
                }
                else if (hit.collider.gameObject.tag == "Attack")
                {
                    Cursor.SetCursor(attack,new Vector2(16,16),CursorMode.Auto);
                }

                else
                {
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                }
            }
        
            else
            {
                Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);// set Standart Cursor
            }
        }
    }
}



