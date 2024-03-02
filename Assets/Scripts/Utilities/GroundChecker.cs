using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _point;
    [SerializeField] private float _pointRadius = 0.5f;
    [SerializeField] private int _itemFound;

    public bool grounded;

    private readonly Collider2D[] _colliders = new Collider2D[3];

    public bool isGrounded { get { return grounded; } }

    private void Update()
    {
        _itemFound = Physics2D.OverlapCircleNonAlloc(_point.position, _pointRadius, _colliders, _layerMask);

        if (_itemFound > 0 && _colliders[0].GetComponent<IGround>() != null)
        {
            grounded = true;
            return;
        }

        grounded = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_point.position, _pointRadius);
    }
}
