using UnityEngine;

namespace FoodGame
{
    public class DragDropScript : MonoBehaviour
    {
        protected bool isSelected;
        [SerializeField] protected GameObject box;
        protected static bool isTime;
        protected virtual void Start()
        {
            isTime = false;
        }
        protected virtual void Update()
        {
            if (isSelected)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = mousePos;
                if (Input.GetMouseButtonUp(0))
                {
                    isSelected = false;
                    box.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
        protected void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSelected = true;
                box.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
