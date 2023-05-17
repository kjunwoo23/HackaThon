using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using IronPython.Hosting;
using System.Threading;

public class NPC
{
    public string input = "1/2/3/4/5";
    public string output = @"2
4
6
8
10";
}

public class PythonTest : MonoBehaviour
{
    public static PythonTest instance;
    public InputField inputField;
    public Text text;
    public IEnumerator cor;
    private object lockObject = new object();

    public bool isEnd = false;
    public bool isError = false;

    string result;

    Thread thread;

    //UI
    public GameObject alert;
    public GameObject python;
    public GameObject problem;
    public GameObject errorResult;
    public RawImage accept;
    public RawImage wrongAnswer;

    public NPC npc = new NPC();

    public void Start()
    {
        instance = this;
    }


    public void Onclick()
    {
        thread = new Thread(() => Interpret(npc.input));
        thread.Start();
        StartCoroutine(EvaluateCode(npc.output, 7));
    }

    public IEnumerator EvaluateCode(string output, int time)
    {
        for (int i = 0; i < 2 * time; i++)
        {
            if (i % 4 == 0) text.text = "Checking.";
            else if (i % 4 == 1) text.text = "Checking..";
            else if (i % 4 == 2) text.text = "Checking...";
            else text.text = "Checking....";
            yield return new WaitForSeconds(0.5f);
            if (isEnd == true) break;
        }

        //for(int i = 0; i < outputList.Count; i++)
        //{
        //    Debug.Log("--" + outputList[i] + "--" + outputList[i].Length);
        //}
        //for(int i = 0; i < resultList.Count; i++)
        //{
        //    Debug.Log("--" + resultList[i] + "--");
        //}


        if (isEnd == false)
        {
            text.text = "TIME OVER";
            accept.enabled = false;
            wrongAnswer.enabled = true;
        }
        else
        {
            bool isSame = false;
            List<string> resultList = new List<string>(result.Split('\n', '\r'));
            List<string> outputList = new List<string>(output.Split('\n', '\r'));
            if (outputList.Count == 2 * resultList.Count - 3)
            {
                isSame = true;
                for (int i = 0; i < resultList.Count - 1; i++)
                {
                    bool isElementSame = false;
                    if (outputList[2 * i].Length == resultList[i].Length)
                    {
                        isElementSame = true;
                        for (int j = 0; j < outputList[2 * i].Length; j++)
                        {
                            //Debug.Log(i + " " + j + " " + outputList[2 * i][j] + " " + resultList[i][j]);
                            if (outputList[2 * i][j] != resultList[i][j])
                            {
                                isElementSame = false;
                                break;
                            }
                        }
                    }
                    if (isElementSame == false)
                    {
                        isSame = false;
                        break;
                    }
                }
            }
            if (isSame)
            {
                //result += "Correct";
                wrongAnswer.enabled = false;
                accept.enabled = true;
            }
            else
            {
                //result += "Incorrect";
                accept.enabled = false;
                wrongAnswer.enabled = true;
            }
            result = result.Replace("\n", ", ");
            if(isError == false && result.Length >= 2) result = result.Remove(result.Length - 2);
            text.text = result;
            isEnd = false;
            isError = false;
        }
        thread.Abort();
    }

    public void Stop()
    {
        thread.Abort();
        if (isEnd == false)
        {
            text.text = "ERROR";
        }
        else
        {
            isEnd = false;
        }
    }

    public void Interpret(string input)
    {
        lock (lockObject)
        {
            try
            {
                var engine = Python.CreateEngine();
                var scope = engine.CreateScope();

                result = "";

                string code = @"
import sys
sys.stdout = my
annyeonghaseyo = inputData
annyeonghaseyo = annyeonghaseyo.split('/')
index = 0

def input():
    global index
    if index < len(annyeonghaseyo):
        index += 1
        return annyeonghaseyo[index - 1]
    else:
        return ''

";
                code += inputField.text;
                var source = engine.CreateScriptSourceFromString(code);
                scope.SetVariable("my", this);
                scope.SetVariable("inputData", input);
                var actual = source.Execute(scope);
                result += actual;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                isError = true;
            }
            isEnd = true;
        }
    }

    public void write(string s)
    {
        result += s;
    }
    public void AlertOK()
    {
        alert.SetActive(false);
        python.SetActive(true);
        problem.SetActive(true);
        errorResult.SetActive(true);
    }
    public void PythonExit()
    {
        inputField.text = "";
        python.SetActive(false);

        problem.GetComponentInChildren<Text>().text = "";
        problem.SetActive(false);

        errorResult.GetComponentInChildren<Text>().text = "";
        errorResult.SetActive(false);

        accept.enabled = false;
        wrongAnswer.enabled = false;

        Player.instance.move = true;
    }
}
