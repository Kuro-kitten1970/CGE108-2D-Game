using UnityEngine;

public class ObjectsTranform : MonoBehaviour
{
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] private Vector3 _targetDistance;

    private Vector3 _originTranform;
    private Vector3 _targetTranform;

    public bool _isGoingOpposite;
    public bool _isStop = false;

    private void Start()
    {
        _originTranform = transform.position;
        _targetTranform = _originTranform + _targetDistance;
    }

    private void FixedUpdate()
    {
        if (_isStop) return;

        if (transform.position == _targetTranform || transform.position == _originTranform)
            _isGoingOpposite =! _isGoingOpposite;

        if (!_isGoingOpposite)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetTranform, _speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _originTranform, _speed);
        }
    }
}
