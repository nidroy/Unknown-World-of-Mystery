
public class Player : Character
{
    /// <summary>
    /// начать талепортацию
    /// </summary>
    public void StartTeleportation()
    {
        characterAnim.SetBool("isStartTeleportation", true);
    }

    /// <summary>
    /// закончить телепортацию
    /// </summary>
    public void EndTeleportation()
    {
        characterAnim.SetBool("isStartTeleportation", false);
        characterAnim.SetBool("isEndTeleportation", true);
    }

    /// <summary>
    /// коснуться пола
    /// </summary>
    public override void EnterFloor()
    {
        characterAnim.SetBool("isEndTeleportation", false);
        isFloor = true;
    }

    /// <summary>
    /// коснуться тригера
    /// </summary>
    public override void EnterTrigger()
    {
        FirstLocation.isOpenDoor = true;
        SecondLocation.isСomplete = true;
        isMove = false;
    }
}
