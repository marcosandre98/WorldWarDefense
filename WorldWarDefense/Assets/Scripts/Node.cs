using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hoverColor;
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;
    
    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    
    public Vector3 GetBuildPosition(){
        return transform.position + positionOffset;
    }

    void OnMouseDown(){

        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        
        if(!buildManager.CanBuild){
            return;
        }

        if (turret != null){
            return;
        }
        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter(){

        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if(!buildManager.CanBuild){
            return;
        }       
    }

    void OnMouseExit(){
        rend.material.color = startColor;
    }

}
