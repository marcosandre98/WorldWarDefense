using UnityEngine;

public class Shop : MonoBehaviour{

    BuildManager buildManager;

    void Start(){
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret(){
        Debug.Log("Tentou pegar a torre");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret(){
        Debug.Log("Tentou pegar outra torre");
    }
}
