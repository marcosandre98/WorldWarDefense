using UnityEngine;

public class BuildManager : MonoBehaviour{
    
    public static BuildManager instance;

    void Awake(){

        if(instance != null){
            return;

        }
        instance = this;
    }
    
    public GameObject standardTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node){
        if(PlayerStats.Money < turretToBuild.cost){
            Debug.Log("Sem grana manito!!");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Dinheiro Restante: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret){
        turretToBuild = turret;
    }
}
