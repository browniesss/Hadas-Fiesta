using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*유저의 입력을 처리한다.*/
public class CInputComponent : BaseComponent
{
    //캐릭터의 모든 컴포넌트를 관리하기 쉽게 하기 위해 basecomponent를 상속받은 스크립트들을 componentmanager에서 관리한다.
    public override void InitComtype()
    {
        p_comtype = EnumTypes.eComponentTypes.InputCom;
    }
    
    //사용할 키 지정
    [System.Serializable]
    public class KeySetting
    {
        public KeyCode right = KeyCode.D;

        public KeyCode foward = KeyCode.W;

        public KeyCode left = KeyCode.A;

        public KeyCode back = KeyCode.S;

        public KeyCode Rolling = KeyCode.Space;

        public KeyCode Run = KeyCode.LeftShift;
    }

    [Header("Keys")]
    public KeySetting _key = new KeySetting();

    //input에서 필요한 컴포넌트들
    [Header("Components")]
    //1. move 컴포넌트
    public CMoveComponent movecom;
    //2. Attack 컴포넌트
    public CAttackComponent attackcom;
    //3. Defence 컴포넌트
    public CGuardComponent guardcom;
    
   
    //키와 마우스 입력을 처리한다.
    void KeyInput()
    {
        if (movecom == null)
            movecom = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;

        

        float v = 0;
        float h = 0;

        movecom.MouseMove = new Vector2(0, 0);//마우스 움직임
        movecom.MoveDir = new Vector3(0, 0, 0);//wasd 키 입력에 따른 이동 방향

        movecom.MouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));

        //space 처리
        if (Input.GetKey(_key.Rolling))
            movecom.Rolling();

        CharacterStateMachine.eCharacterState state = CharacterStateMachine.Instance.GetState();


        if (state == CharacterStateMachine.eCharacterState.Attack|| 
            state == CharacterStateMachine.eCharacterState.Rolling||
            state == CharacterStateMachine.eCharacterState.Guard|| 
            state == CharacterStateMachine.eCharacterState.OutOfControl)
        {
            movecom.curval.IsMoving = false;
            return;
        }

        if (movecom.curval.IsRolling|| movecom.curval.IsSlip|| movecom.curval.IsAttacking||movecom.curval.IsGuard)//회피중, 떨어지는중, 공격하는 중에는 움직일 수는 없지만 마우스를 움직여 화면을 돌리는것은 가능
        {
            movecom.curval.IsMoving = false;
            return;
        }

        movecom.curval.IsMoving = false;

        Input.GetAxisRaw("Mouse ScrollWheel");//줌인 줌아웃에 사용

        //wasd 처리
        if (Input.GetKey(_key.foward)) v += 1.0f;
        if (Input.GetKey(_key.back)) v -= 1.0f;
        if (Input.GetKey(_key.left)) h -= 1.0f;
        if (Input.GetKey(_key.right)) h += 1.0f;

        movecom.MoveDir = new Vector3(h, 0, v);

        //left shift 처리
        if (Input.GetKey(_key.Run)) movecom.curval.IsRunning = true;
        else movecom.curval.IsRunning = false;

        

        //이동값이 조금이라도 있으면 움직이는중으로 판단
        if (movecom.MoveDir.magnitude > 0 )
        {
            movecom.curval.IsMoving = true;
            //CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Move);
        }
        else
        {
            CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Idle);
        }


        if (movecom.curval.IsMoving)
        {
            if (movecom.curval.IsRunning)
            {
                //com.animator.SetPlaySpeed(1f);
                movecom.com.animator.Play("_Dash");

            }
            else
            {
                //com.animator.SetPlaySpeed( 1f);
                movecom.com.animator.Play("_Walk");
            }
        }
        else
        {
            movecom.com.animator.Play("_Idle");
        }


    }

    //IEnumerator tempdid;
    //IEnumerator Cor_Test(float time)
    //{
    //    int i = 0;
    //    Debug.Log($"다시시작");
    //    while (true)
    //    {
    //        //if ((Time.time - starttime) >= time)
    //        //{
    //        //    Debug.Log("시간다됨");
    //        //    invoker.Invoke();
    //        //    coroutine = null;
    //        //    //playingCor = false;
    //        //    yield break;
    //        //}
    //        if (i >= 100)
    //            yield break;

    //        Debug.Log($"코루틴{i}");
    //        i++;
    //        yield return new WaitForSeconds(1.0f);
    //    }
    //}

    void Update()
    {
        //왼쪽 마우스 클릭
        if(Input.GetMouseButtonDown(0))
        {
            if (attackcom == null)
                attackcom = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AttackCom) as CAttackComponent;
            attackcom.Attack();
            //movecom.curval.IsAttacking = true;
        }

        //오른쪽 마우스 클릭
        if(Input.GetMouseButtonDown(1))
        {
            if (guardcom == null)
                guardcom = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.GuardCom) as CGuardComponent;
            guardcom.Guard();
            //movecom.curval.IsGuard = true;

        }
        if(Input.GetMouseButtonUp(1))
        {
            if (guardcom == null)
                guardcom = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.GuardCom) as CGuardComponent;
            guardcom.GuardDown();
            //movecom.curval.IsGuard = false;
        }

        //키 입력
        KeyInput();
    }
}
