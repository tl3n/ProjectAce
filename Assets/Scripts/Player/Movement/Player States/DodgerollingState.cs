public class DodgerollingState : IPlayerState
{
    /// <summary>
    /// State Machine field to interact with
    /// </summary>
    private Player player;

    public DodgerollingState(Player player)
    {
        this.player = player;
    }

    public void EnterState()
    {
        AudioManager.Instance.PlayPlayerSFX(1);
        player.StartCoroutine(player.DodgerollCoroutine());
    }

    public void UpdateState() 
    {
        
    }

    public void ExitState() { }
}
