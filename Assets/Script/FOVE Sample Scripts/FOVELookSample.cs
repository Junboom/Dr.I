using UnityEngine;

public class FOVELookSample : MonoBehaviour
{
    public Light attachedLight;
    public GameObject fire;
    //public FoveInterfaceBase foveInterface;

    
    private Material material;
    private bool light_attached = false;

    void Start()
    {
        

        if (attachedLight == null)
            attachedLight = transform.GetComponentInChildren<Light>();

        if (attachedLight)
        {
            light_attached = true;
            attachedLight.enabled = false;
        }
        material = gameObject.GetComponent<Renderer>().material;
        if (material == null)
            gameObject.SetActive(false);

        fire.SetActive(false);
        attachedLight.enabled = false;


    }


    public void emissionOff()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        material.DisableKeyword("_EMISSION");

        if (light_attached)
        {
            attachedLight.enabled = false;
            DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.black);
            fire.SetActive(true);
        }
    }



    public void emissionOn()
    {

        material.EnableKeyword("_EMISSION");

        if (light_attached)
        {
            material.SetColor("_EmissionColor", attachedLight.color);
            attachedLight.enabled = true;
            DynamicGI.SetEmissive(GetComponent<Renderer>(), attachedLight.color);
            fire.SetActive(false);
        }
    }




}
