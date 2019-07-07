using UnityEngine;

public class BuildManager : MonoBehaviour{
    
    public static BuildManager instance;

    void Awake(){

        if(instance != null){
            Debug.LogError("more than build manager in scene!!");
            return;

        }
        instance = this;
    }
    
    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild(){
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret){
        turretToBuild = turret;
    }
}
