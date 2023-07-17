using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IKitchenObjectParent
{
    public static PlayerInteraction Instance { get; private set; }

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private Transform kitchenObjectHoldPoint;
    private KitchenObject currentKitchenObject;
    private BaseCounter selectedCounter;

    private Vector3 lastInteractDir;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        gameInput.OnInteractAction += OnInteractAction;
    }

    private void OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    private void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero ) {
            lastInteractDir = moveDir;
        }

        float interactDist = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit hit, interactDist, countersLayerMask))
        {
            if (hit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    private void SetSelectedCounter(BaseCounter _selectedCounter)
    {
        this.selectedCounter = _selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = _selectedCounter });
    }

    public Transform GetKitchenObjectPlacementTransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject _kitchenObject)
    {
        this.currentKitchenObject = _kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return currentKitchenObject;
    }

    public void ClearKitchenObject()
    {
        currentKitchenObject = null;
    }

    public bool HasKitchenOject()
    {
        return currentKitchenObject != null;
    }
}