using UnityEngine;

public struct PeaShooterConfig
{
    public float idleTime;
    public float shootingTime;
    public int hp;
}
public class PeaShooterHandler
{
    private PeaShooter mPeaShooter;
    private PeaShooterConfig mConfig;
    private PeaShooterConfig mStatus;
    private state mState = state.Idle;
    public PeaShooterHandler(PeaShooter peaShooter)
    {
        mPeaShooter = peaShooter;
    }

    enum state
    {
        Idle = 0,
        Shooting,
        Shoot,
        Die
    }
    public void SetPeaShooter(PeaShooter p)
    {
        mPeaShooter = p;
    }

    public void Config(PeaShooterConfig config)
    {
        mConfig = config;
        Debug.Log(config);
    }

    public void Init()
    {
        mStatus = mConfig;
        mState = state.Idle;
        Debug.Log(nameof(Init) + " " + mState);
    }

    public void Process()
    {
        switch(mState)
        {
            case state.Idle:
            {
                mPeaShooter.OnIdle();
                mStatus.idleTime -= Time.deltaTime;
                if (mStatus.idleTime < 0)
                {
                    mStatus.idleTime = mConfig.idleTime;
                    mState = state.Shooting;
                }
                break;
            }
            case state.Shooting:
            {
                mPeaShooter.OnShooting();
                mStatus.shootingTime -= Time.deltaTime;
                if (mStatus.shootingTime < 0)
                {
                    mStatus.shootingTime = mConfig.shootingTime;
                    mState = state.Shoot;
                }
                break;
            }
            case state.Shoot:
            {
                mPeaShooter.OnShoot();
                mState = state.Idle;
                break;
            }
            case state.Die:
            {
                mPeaShooter.OnDie();
                break;
            }
            default:
                break;
        }
    }

    public void TakeDamage(int amount)
    {
        mStatus.hp -= amount;
        if (mStatus.hp <= 0) mState = state.Die;
    }
}
