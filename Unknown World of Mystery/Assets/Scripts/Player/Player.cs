
public class Player : Character
{
    /// <summary>
    /// ������ ������������
    /// </summary>
    public void StartTeleportation()
    {
        characterAnim.SetBool("isStartTeleportation", true);
    }

    /// <summary>
    /// ��������� ������������
    /// </summary>
    public void EndTeleportation()
    {
        characterAnim.SetBool("isStartTeleportation", false);
        characterAnim.SetBool("isEndTeleportation", true);
    }

    /// <summary>
    /// ��������� ����
    /// </summary>
    public override void EnterFloor()
    {
        characterAnim.SetBool("isEndTeleportation", false);
        isFloor = true;
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    public override void EnterTrigger()
    {
        FirstLocation.isOpenDoor = true;
        SecondLocation.is�omplete = true;
        isMove = false;
    }
}
