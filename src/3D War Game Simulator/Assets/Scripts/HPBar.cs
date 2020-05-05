using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	private Canvas canvas;
    private GameObject FollowTarget;
    private RectTransform m_SliderRectTransform;
    private Slider m_Slider;
    [SerializeField] private Image m_FillImage;
    public float m_ObjectHeight;
    public float HealthPoint
    {
        get
        {
            return m_Slider.value;
        }
        set
        {
            m_Slider.value = value;
        }
    }

    public float MaxHealthPoint
    {
        get
        {
            return m_Slider.maxValue;
        }
        set
        {
            m_Slider.maxValue = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FollowTarget = gameObject.transform.parent.parent.gameObject;
        canvas = gameObject.transform.parent.gameObject.GetComponent<Canvas>();
        m_FillImage = gameObject.transform.Find("Fill Area/Fill").gameObject.GetComponent<Image>();
        if (canvas == null) Debug.LogError("No Canvas has been set.");
        m_Slider = gameObject.GetComponent<Slider>();
        m_SliderRectTransform = m_Slider.transform as RectTransform;
        transform.SetParent(canvas.transform);

	}

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBarPosition();
    }
    private void LateUpdate()
    {
        UpdateHealthBarColor();
    }
    void UpdateHealthBarPosition()
    {
        Vector3 worldPosition = new Vector3(FollowTarget.transform.position.x,
            FollowTarget.transform.position.y + m_ObjectHeight, FollowTarget.transform.position.z);
    }
    void UpdateHealthBarColor()
    {
        if (m_Slider.value < m_Slider.maxValue * 0.2f)
        {
            m_FillImage.color = Color.red;
        }
        else if (m_Slider.value < m_Slider.maxValue * 0.5f)
        {
            m_FillImage.color = Color.yellow;
        }
        else
        {
            m_FillImage.color = Color.green;
        }
        if(m_Slider.value <= 0)
        {
            //Debug.Log(gameObject.name + "is dead.");
        }
    }
}