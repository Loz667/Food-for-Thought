using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObject;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO() 
    { 
        return kitchenObject; 
    }

    public void SetKitchenObjectParent(IKitchenObjectParent _kitchenObjectParent)
    {
        this.kitchenObjectParent?.ClearKitchenObject();

        this.kitchenObjectParent = _kitchenObjectParent;

        if (_kitchenObjectParent.HasKitchenOject())
        {
            Debug.LogError("ObjectParent is not available!");
        }

        _kitchenObjectParent.SetKitchenObject(this);

        transform.parent = _kitchenObjectParent.GetKitchenObjectPlacementTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent() 
    { 
        return kitchenObjectParent; 
    }
}
