using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeMonster : Enemy
{
    [SerializeField]
    float Now_HP;
    [SerializeField]
    bool Mob_Skill_divide;


    public GameObject hpBarPrefab; //Instantiate 메서드로 복제할 프리펩을 담을 변수
    public Vector3 hpBarOffset = new Vector3(-0.5f, 2.4f, 0);

    public Canvas enemyHpBarCanvas;
    //public Slider enemyHpBarSlider; //Slider의 초기 세팅, Hp 갱신에 사용할 Slider를 담을 변수
    private EnemyHpbar MyHpbar;
  //  public Vector3 hpBarOffset = new Vector3(-0.5f, 2.4f, 0);
    protected override void Enemy_Attack()
    {
        throw new System.NotImplementedException();
    }
    
    protected override void Enemy_FSM()
    {
        switch (cur_State)
        {
            case 1:
                Enemy_Patrol();
                break;
            case 2:
                Enemy_Trace();
                break;
            case 3:
                break;
            case 4:
                Enemy_Return();
                break;
        }
    }
    void SkillFsm()
    {
      
        if(Now_HP<=0) // 현재 체력이 0보다 작다면. 
        {
            if(Mob_Skill_divide) //스킬을 사용했다면 그대로 종료한다. 
            {
                Destroy(this.gameObject);
            }
            else if(!Mob_Skill_divide) //스킬을 사용안했었다면 스킬을 사용한다. 
            {
                Slime_Split();
                Set_Mob_Skill_devied();
            }
        }
    }
    void Slime_Split()  //슬라임이 분열하는곳.
    {
        Vector3 tmp;
        GameObject obj = Resources.Load<GameObject>("Prefabs/Fire Demon-Yellow");
        tmp = this.transform.position;
        tmp.x += 2f;
        obj = Instantiate(obj, this.transform) as GameObject;  
        obj.transform.SetParent(null);
        obj.GetComponent<SlimeMonster>().Split_Init(tmp);

        GameObject obj2 = Resources.Load<GameObject>("Prefabs/Fire Demon-Yellow");
        tmp = this.transform.position;
        tmp.x -= 2f;
        obj2 = Instantiate(obj2,this.transform) as GameObject;      
        obj2.transform.SetParent(null);
        obj2.GetComponent<SlimeMonster>().Split_Init(tmp);
       
    }
    public void Set_Mob_Skill_devied()
    {
        this.Mob_Skill_divide = true;
    }
    public void Split_Init(Vector3 pos)
    {
        this.transform.position = pos;
        this.Mob_Skill_divide = true;
        Now_HP = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        parent_Init();
        SetHpBar(); 
    }
    private void Awake()
    {
       
        Mob_Skill_divide = false;
    }
    // Update is called once per frame
    void Update()
    {
        SkillFsm();
        Enemy_FSM();
        MyHpbar.hit();

    }
    public void SetHpBar()
    {
        enemyHpBarCanvas = enemyHpBarCanvas.GetComponent<Canvas>();
        GameObject hpBar = UIManager.Instance.Prefabsload("Enemy HpBar Slider", UIManager.CANVAS_NUM.ex_skill);

        var _hpbar = hpBar.GetComponent<EnemyHpbar>();
      //  hpBar.transform.SetParent(enemyHpBarCanvas.transform);
        _hpbar.enemyTr = this.gameObject.transform;
        _hpbar.offset = hpBarOffset;
        _hpbar.Maxhp = Now_HP;
        _hpbar.Curhp = Now_HP;
        var _test = hpBar.GetComponent<Slider>();
        _hpbar.myhp =_test;
        MyHpbar = _hpbar;

        Debug.Log(enemyHpBarCanvas.transform);
         
    }
    public void Hitdamage()
    {
        MyHpbar.Curhp = MyHpbar.Curhp - 5f;
        MyHpbar.hit();
    }
}
