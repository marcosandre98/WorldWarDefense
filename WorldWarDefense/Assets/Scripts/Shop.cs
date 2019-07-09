using UnityEngine;

public class Shop : MonoBehaviour{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret(){
        Debug.Log("Selecionou uma torre");
        buildManager.SelectTurretToBuild(standardTurret);
    }
/*
    public void PurchaseAnotherTurret(){
        Debug.Log("Tentou pegar outra torre");
    }
 */
}
