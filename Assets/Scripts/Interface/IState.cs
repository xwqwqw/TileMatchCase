namespace TKK.Interface
{
    public interface IState
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();
        void OnReset();
    }
}