using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetKitchenObjectPlacementTransform();

    public void SetKitchenObject(KitchenObject _kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenOject();
}
