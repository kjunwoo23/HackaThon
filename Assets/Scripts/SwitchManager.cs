using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

[System.Serializable]
public class Switch
{
    public string switchName;
    public bool bools;
}
public class SwitchManager : MonoBehaviour
{
    public static SwitchManager instance;

    [Header("스위치 등록")]
    [SerializeField]
    public Switch[] switches;

    //npc
    public Text problem;
    public GameObject alert;


    private void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (switches[1].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"가로 20, 세로 20으로 주변좌표를 정해놓았다.
현재위치와 근처의 ATM기 4개의 x,y좌표를 입력받고, 가장 가까운 ATM기의 번호를 출력하는 프로그램을 만드시오(1,2,3,4)";
            PythonTest.instance.npc.input = "5/5/8/13/7/2/6/6/19/19";
            PythonTest.instance.npc.output = "3";
            switches[1].bools = false;
        }

        if (switches[2].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"고양이의 적정 사료량(g)은 체중(kg) * 10 + 40입니다.
고양이의 몸무게를 입력받고 하루 적정 사료량을 출력하는 프로그램을 만드시오.";
            PythonTest.instance.npc.input = "5";
            PythonTest.instance.npc.output = "90";
            switches[2].bools = false;
        }
        if (switches[3].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"파맛 첵스 차카는 세종대 학생회장이 되기 위해 선거에 출마했다. 학생들을 매수하려하는 차카가 당선될 확률은 다음의 공식을 따른다. 
n - n * n * 0.01 (n은 매수한 사람 수)
차카가 당선될 확률이 가장 높으려면 몇명의 사람을 매수해야 하는가?";
            PythonTest.instance.npc.input = "";
            PythonTest.instance.npc.output = "50";

            switches[3].bools = false;
        }

        if (switches[4].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"깃허브의 마스코트 문어는 깃허브에 작업 내용을 커밋하려 한다.
그런데 너무나 많은 프로젝트들을 관리하고 있었던 문어는 먼저 프로젝트들을 작업한지 오래된 순서대로 정렬한 뒤, 정렬된 순서대로 프로젝트들을 차례로 커밋하고자 한다.
코드를 작성하여 문어의 정렬을 도와주자.";
            PythonTest.instance.npc.input = "1/9/2/8/3/7/5/6/4/10";
            PythonTest.instance.npc.output = "10\r\n9\r\n8\r\n7\r\n6\r\n5\r\n4\r\n3\r\n2\r\n1";

            switches[4].bools = false;
        }

        if (switches[5].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"출석부의 5명의 영어이름을 입력받고, 첫글자만 전부 대문자로 바꿔서 출력하는 프로그램을 만드시오.";
            PythonTest.instance.npc.input = "BAEK/cHojaeHYuN/CoNGdOHAn/lEEsAnGhyUN/KimjUNwOO";
            PythonTest.instance.npc.output = @"Baek
Chojaehyun
Congdohan
Leesanghyun
Kimjunwoo";

            switches[5].bools = false;
        }
        if (switches[6].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"다행히도 선택적 패스 제도가 도입이 되어 D0이상의 성적을 받은 과목들을 P로 전환할 수 있게 되었다.
(최종점수=중간고사의 30%+기말고사의 40%+과제의 30%), 최종점수가 30점 이상이면 P 처리할 수 있다.
새내기 병아리군의 5개의 과목 성적을 통해 어떤 과목들을 P로 바꿀 수 있는지 알아보자.";
            PythonTest.instance.npc.input = "10/20/30/40/20/40/0/18/59/40/12/6/30/20/10/6/7/1";
            PythonTest.instance.npc.output = @"np
p
np
np
np";

            switches[6].bools = false;
        }
        if (switches[7].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = "가로n 세로 n크기의 정사각형에 모래시계모양으로 '0', 바깥영역에는 '1'을 출력하는 프로그램을 만드시오.";
            PythonTest.instance.npc.input = "7";
            PythonTest.instance.npc.output = @"0000000
1000001
1100011
1110111
1100011
1000001
0000000";

            switches[7].bools = false;
        }

        if (switches[8].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"하지만 다행히도 도서를 대출한 날짜와 대출의 연장 여부에 대한 정보들은 사라지지 않았다.
대출일과 대출 연장 여부를 통해 도서들의 반납일을 구해보자. (대출일과 반납일의 연도는 항상 2020년이다.)
(14일 동안 도서를 빌릴 수 있으며, 연장 시 7일을 더 빌릴 수 있다.)";
            PythonTest.instance.npc.input = "3/28/0/2/1/1/5/7/0/8/18/1/9/24/0";
            PythonTest.instance.npc.output = @"4/11
2/22
5/21
9/8
10/6";

            switches[8].bools = false;
        }
        if (switches[9].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"만날 확률:
여름 -> 70%
비가 안 오는 날 -> 80%
바람이 적당히 부는 날 -> 70%
천적이 근처에 없는 경우 -> 90%";
            PythonTest.instance.npc.input = "0/0/0/1/0/0/1/0/0/1/0/1/1/0/1/1/1/1/1/1";
            PythonTest.instance.npc.output = @"6
1
1
35
8";

            switches[9].bools = false;
        }
        if (switches[10].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"대머리교수가 개발한 탈모치료제는 매 2의 배수인 날, 3의 배수인 날에 먹어야 하지만 6의 배수인 날은 먹으면 안된다. 이번 달에 먹어야 하는 날들을 출력하는 프로그램을 만드시오.";
            PythonTest.instance.npc.input = "";
            PythonTest.instance.npc.output = @"2
3
4
8
9
10
14
15
16
20
21
22
26
27
28";

            switches[10].bools = false;
        }
        if (switches[11].bools == true)
        {
            EffectManager.instance.effectSounds[0].source.Play();
            alert.SetActive(true);
            Player.instance.move = false;
            problem.text = @"세종초 3학년 잼민이는 세종대 운동장에서 축구하는 것을 즐긴다.
잼민이가 공을 가장 멀리 찰 수 있는 각도를 구해보자.
다음의 물리 공식을 이용하여라.
d = v^2 / g * sin(2a)
(d = 거리, v = 초기 속도, g = 중력가속도, a는 각도(0도~90도))";
            PythonTest.instance.npc.input = "12/9.8";
            PythonTest.instance.npc.output = @"14
45";

            switches[11].bools = false;
        }
    }


}