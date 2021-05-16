using UnityEngine;

//todo add comments
public class BasicBoomerang : ItemGrab
{
    [SerializeField] private float speedBoomerangAdjust = 30f, accelerationBoomerangAdjust = 30f;
    [SerializeField] private float boomerangAdjustDist = 2f;
    private bool _isThrown;
    private Vector3 _initPosThrow;

    public override void Grab(Transform anchor)
    {
        base.Grab(anchor);
        StopBoomerang();
    }

    public override void Throw(float strength)
    {
        base.Throw(strength);
        _initPosThrow = transform.position;
        _isThrown = true;
    }

    private void FixedUpdate()
    {
        MoveUpdate();
        if (!_isThrown)
        {
            return;
        }

        CustomGravity.EnableGravity = false;
        //_initPosThrow = GameManager.Instance.LevelManager.Player.transform.position;
        Vector3 aim = _initPosThrow - transform.position;
        if (aim.magnitude < boomerangAdjustDist && Vector3.Dot(aim, Body.velocity) > 0)
        {
            StopBoomerang();
            return;
        }
        float maxSpeedChange = accelerationBoomerangAdjust * Time.fixedDeltaTime;
        Body.velocity = Vector3.MoveTowards(Body.velocity, aim * speedBoomerangAdjust, maxSpeedChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        _isThrown = false;
    }

    private void StopBoomerang()
    {
        _isThrown = false;
        CustomGravity.EnableGravity = true;
    }
}