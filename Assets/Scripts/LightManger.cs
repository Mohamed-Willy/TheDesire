using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Vector3Bool
{
    public bool R;
    public bool G;
    public bool B;

    public Vector3Bool(bool R, bool G, bool B)
    {
        this.R = R; 
        this.G = G; 
        this.B = B;
    }
}
[System.Serializable]
public struct Item
{
    public GameObject item;
    public Vector3Bool RGB;
}
public class LightManger : MonoBehaviour
{
    GameObject m_GameObject;
    [SerializeField] Vector3Bool RGB;
    [SerializeField] List<Item> items;
    private void Start()
    {
        RGB = new(true, true, true);
        m_GameObject = gameObject;
        ChangeColor();
    }
    private void Update()
    {
        ChangeColor();
    }
    public void SetColor(Vector3Bool RGB)
    {
        this.RGB.R = RGB.R ? !this.RGB.R : this.RGB.R;
        this.RGB.G = RGB.G ? !this.RGB.G : this.RGB.G;
        this.RGB.B = RGB.B ? !this.RGB.B : this.RGB.B;
        ChangeColor();
    }
    private void ChangeColor()
    {
        foreach (var light in m_GameObject.GetComponentsInChildren<Light>())
        {
            light.color = new Color(RGB.R ? 255 : 0, RGB.G ? 255 : 0, RGB.B ? 255 : 0);
        }
        foreach (var item in items)
        {
            if (IsComplementColor(RGB, item.RGB))
            {
                item.item.SetActive(true);
            }
            else
            {
                item.item.SetActive(false);
            }
        }
    }
    bool IsComplementColor(Vector3Bool ob1, Vector3Bool ob2)
    {
        return ob1.R != ob2.R && ob1.G != ob2.G && ob1.B != ob2.B;
    }
}