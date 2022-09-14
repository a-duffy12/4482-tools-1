using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[ExecuteInEditMode]
public class ShapeRandomizer : MonoBehaviour
{
    [Header("Shape Properties")]
    [SerializeField] float posX;
    [SerializeField] float posY;
    [SerializeField] float posZ;
    [SerializeField] float scale;
    [SerializeField] Color color;

    [Header("Randomization Properties")]
    [HideInInspector] public float minX = -10;
    [HideInInspector] public float maxX = 10;
    [HideInInspector] public float minY = -10;
    [HideInInspector] public float maxY = 10;
    [HideInInspector] public float minZ = -10;
    [HideInInspector] public float maxZ = 10;
    [HideInInspector] public float minScale = 0;
    [HideInInspector] public float maxScale = 100;

    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
        defaultScale = transform.localScale;
        defaultColor = GetComponent<Renderer>().sharedMaterial.color;

        minX = -10;
        maxX = 10;
        minY = -10;
        maxY = 10;
        minZ = -10;
        maxZ = 10;
        minScale = 0;
        maxScale = 10;
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
        scale = transform.localScale.x;
        color = GetComponent<Renderer>().sharedMaterial.color;
    }

    public void ResetShape()
    {
        transform.position = defaultPosition;
        transform.localScale = defaultScale;
        GetComponent<Renderer>().sharedMaterial.color = defaultColor;
    }

    public void ResetSliders()
    {
        minX = -10;
        maxX = 10;
        minY = -10;
        maxY = 10;
        minZ = -10;
        maxZ = 10;
        minScale = 0;
        maxScale = 10;
    }

    public void Randomize()
    {
        RandomizePosition();
        RandomizeScale();
        RandomizeColor();
    }

    public void RandomizePosition()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }

    public void RandomizeScale()
    {
        float newScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    public void RandomizeColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }
}
