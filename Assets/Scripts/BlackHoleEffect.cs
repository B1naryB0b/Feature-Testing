using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BlackHoleEffect : MonoBehaviour
{

    //public settings
    public Shader shader;
    public Transform blackHole;
    public float ratio;
    public float radius;
    public float strength;

    //private settings
    Camera cam;
    Material _material;

    Material material
    {
        get
        {
            if (_material == null)
            {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    void OnEnable()
    {
        cam = GetComponent<Camera>();
        ratio = 1f / cam.aspect;
    }

    void OnDisable()
    {
        if (_material)
        {
            DestroyImmediate(material);
        }
    }

    Vector3 wtsp;
    Vector2 pos;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (shader && material && blackHole) 
        {
            wtsp = cam.WorldToScreenPoint(blackHole.position);

            if (wtsp.z > 0)
            {
                pos = new Vector2(wtsp.x / cam.pixelWidth, wtsp.y / cam.pixelHeight);

                _material.SetVector("_Position", pos);
                _material.SetFloat("_Ratio", ratio);
                _material.SetFloat("_Rad", radius);
                _material.SetFloat("_Distance", Vector3.Distance(blackHole.position, transform.position));
                _material.SetFloat("_Strength", strength);

                Graphics.Blit(source, destination, material);
                
            }
        }
    }
}
