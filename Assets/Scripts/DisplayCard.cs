using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{

    public KeyCode button;
    public KeyCode useCard;

    private int siblingPosition;
    private bool display = false;
    private float speed = 2000;

    // Use this for initialization
    void Start()
    {
        siblingPosition = transform.GetSiblingIndex();
        transform.localPosition += new Vector3(siblingPosition * 125, 0, 0);

        transform.FindChild("Button").GetComponent<Text>().text = (siblingPosition + 1).ToString();

        useCard = KeyCode.E;

        switch(siblingPosition)
        {
            case 0:
                button = KeyCode.Alpha1;
                break;
            case 1:
                button = KeyCode.Alpha2;
                break;
            case 2:
                button = KeyCode.Alpha3;
                break;
            case 3:
                button = KeyCode.Alpha4;
                break;
            case 4:
                button = KeyCode.Alpha5;
                break;
            case 5:
                button = KeyCode.Alpha6;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(button))
        {
            display = true;
        } else if (Input.GetKeyUp(button))
        {
            display = false;
        }

        MoveCard();
        UseCard();
    }

    private void MoveCard()
    {
        if (display)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, -475, 0), speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, -600, 0), speed * Time.deltaTime);
        }
    }

    private void UseCard()
    {
        if ((Input.GetKey(useCard) ||
            Input.GetMouseButtonDown(0)) &&
            display)
        {
            gameObject.SetActive(false);
        }
    }

    public void Display()
    {
        transform.SetAsLastSibling();
        display = true;
    }

    public void Undisplay()
    {
        transform.SetSiblingIndex(siblingPosition);
        display = false;
    }
}
