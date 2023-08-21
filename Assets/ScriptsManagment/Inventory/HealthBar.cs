using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Bar;
    public GameObject Counter;

    public UserController User;

    public float DefaultWidth;

    void Start()
    {
        DefaultWidth = Bar.GetComponent<RectTransform>().rect.width;
    }

    void FixedUpdate()
    {
        Counter.GetComponent<TextMeshPro>().text = User.Health.current.ToString();

        float width = (User.Health.current * DefaultWidth) / User.Health.max;

        Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 20);
        Bar.GetComponent<Transform>().localPosition = new Vector3((width / 2) - 100, 0, 0); 

    }
}
