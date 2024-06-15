public class DodgerollingState : IPlayerState
{
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
