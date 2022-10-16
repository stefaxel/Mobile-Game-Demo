using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
                Collider2D touchedColl = Physics2D.OverlapPoint(touchPos);
                if(coll == touchedColl)
                {
                    moveAllowed = true;
                }
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPos.x, touchPos.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
    }
}
