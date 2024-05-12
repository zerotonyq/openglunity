namespace Core.Movement.Fsm.Base
{
    public abstract class FsmState
    {
        public Fsm Fsm;

        public FsmState(Fsm fsm) => Fsm = fsm;
        
        public virtual void Enter(){}
        
        public virtual void Exit(){}
        
        public virtual void Update(){}
    }
}