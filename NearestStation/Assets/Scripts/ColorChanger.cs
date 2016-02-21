using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

    long m_Frame;
    const long SPAN = 3;
    const long FPS = 60;
    GameObject m_Obj;
    Camera m_Camera;
    Color m_CurrentColor;

    void mulColor(ref Color col, float r )
    {
        col.r *= r;
        col.g *= r;
        col.b *= r;
    }

    void UpdateColor(ref Color col)
    {
        if (col.r > 1.0f) { col.r = 0.0f; }
        if (col.g > 1.0f) { col.g = 0.0f; }
        if (col.b > 1.0f) { col.b = 0.0f; }

        if (col.r < 0.1f) { col.r = 1.0f; }
        if (col.g < 0.1f) { col.g = 1.0f; }
        if (col.b < 0.1f) { col.b = 1.0f; }
    }

	// Use this for initialization
	void Start () {
        m_Frame = 0;
        m_Obj = this.gameObject;
        m_Camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Frame > FPS)
        {
            m_Frame = 0;
        }

        if (m_Obj && m_Frame % SPAN == 0 )
        {
            m_CurrentColor = m_Camera.backgroundColor;
            mulColor( ref m_CurrentColor, 0.9f);
            UpdateColor(ref m_CurrentColor);
            m_Camera.backgroundColor = m_CurrentColor;
        }

        m_Frame++;
	}
}
