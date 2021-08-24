using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInstantiator : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject badBallPrefab;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject longWallPrefab;
    [SerializeField] List<BoxCollider2D> gridAreas = new List<BoxCollider2D>();
    [SerializeField] GameObject blockBorderPrefab;
    [SerializeField] List<Transform> instantiationPoints;
    [SerializeField] List<Transform> wallInstantiationPoints;
    [SerializeField] List<Transform> bigWallInstantiationPoints;

    private int counter0,rand0,rand1,rand2,rand3,rand4;
    private BoxCollider2D tempCollider1,tempCollider2;
    private List<int> tempInstantiationPointNum = new List<int>();
    private List<int> tempBarInstantiationPointNum = new List<int>();

    public static bool startGame;

    private float inbetweenTimer,incrementTimer, incrementTimerCap, ballTimer,ballTimerCap,badBallTimer,badBallTimerCap,loadBarsTimer,loadBarsTimerCap;

    public static float moveSpeed0 = 5f, setSpeed = 5f;

    private bool beginCounting;

    void Awake() {
        startGame = false;
        incrementTimer = 0f;
        incrementTimerCap = Random.Range(25f,50f);
    }

    void Update() {
        if(GameManager.gameOver) {
            moveSpeed0 = 0f;
            return;
        }
        if(startGame) {
            startGame = false;
            counter0 = 0;
            badBallTimer = 0f;
            badBallTimerCap = Random.Range(10f,20f);
            ballTimer = 0f;
            ballTimerCap = Random.Range(10f,20f);
            StartCoroutine(LoadNewBlocks2());
            beginCounting = true;
        }
        ballTimer += Time.deltaTime;
        if(ballTimer > ballTimerCap && beginCounting) {
            ballTimer = 0f;
            ballTimerCap = Random.Range(10f,18f);
            InstantiateBall();
        }
        badBallTimer += Time.deltaTime;
        if(badBallTimer > badBallTimerCap && beginCounting) {
            badBallTimer = 0f;
            badBallTimerCap = Random.Range(10f,18f);
            InstantiateBadBall();
        }
        incrementTimer += Time.deltaTime;
        if(incrementTimer >= incrementTimerCap) {
            incrementTimer = 0f;
            incrementTimerCap = Random.Range(25f,50f);
            setSpeed += .1f;
            moveSpeed0 += .1f;
        }
    }

    private IEnumerator LoadNewBlocks2() {
        LoadNewBlocks();
        yield return new WaitForSeconds(3f);
        LoadNewBlocks();
        yield return new WaitForSeconds(3f);
        LoadNewBlocks();
    }

    private void LoadBars() {
        //decide how many bars to instantiate
        int rand9 = Mathf.RoundToInt(Random.Range(0f,5f));
        int rand5 = 0, rand6 = 0, rand7 = 0, rand8 = 0, rand10 = 0,rand11 = 0,rand12 = 0,rand13 = 0,rand14 = 0,rand15 = 0,rand16 = 0,rand17 = 0;
        //instantiate randomly
        switch(rand9) {
            case 0:
                break;
            case 1:
                rand10 = Mathf.RoundToInt(Random.Range(0f,3f));
                rand11 = Mathf.RoundToInt(Random.Range(0f,1f));
                if(rand11 == 0) {
                    GameObject wallInstance = Instantiate(wallPrefab,wallInstantiationPoints[rand10].position,Quaternion.identity) as GameObject;
                }
                else {
                    GameObject wallInstance = Instantiate(longWallPrefab,bigWallInstantiationPoints[rand10].position,Quaternion.identity) as GameObject;
                }
                break;
            case 2:
                tempBarInstantiationPointNum = new List<int>() {0,1,2,3};
                rand12 = Mathf.RoundToInt(Random.Range(0f,1f));
                rand13 = tempBarInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempBarInstantiationPointNum.Count - 1))];
                tempBarInstantiationPointNum.Remove(rand13);
                rand14 = Mathf.RoundToInt(Random.Range(0f,1f));
                rand15 = tempBarInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempBarInstantiationPointNum.Count - 1))];
                tempBarInstantiationPointNum.Remove(rand15);
                if(rand12 == 0) {
                    GameObject wallInstance = Instantiate(wallPrefab,wallInstantiationPoints[rand13].position,Quaternion.identity) as GameObject;
                }
                if(rand12 == 1) {
                    GameObject wallInstance = Instantiate(longWallPrefab,bigWallInstantiationPoints[rand13].position,Quaternion.identity) as GameObject;
                }
                if(rand14 == 0) {
                    GameObject wallInstance = Instantiate(wallPrefab,wallInstantiationPoints[rand15].position,Quaternion.identity) as GameObject;
                }
                if(rand14 == 1) {
                    GameObject wallInstance = Instantiate(longWallPrefab,bigWallInstantiationPoints[rand15].position,Quaternion.identity) as GameObject;
                }
                break;
            case 3:
                tempBarInstantiationPointNum = new List<int>() {0,1,2,3};
                rand12 = Mathf.RoundToInt(Random.Range(0f,1f));
                rand13 = tempBarInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempBarInstantiationPointNum.Count - 1))];
                tempBarInstantiationPointNum.Remove(rand13);
                rand14 = Mathf.RoundToInt(Random.Range(0f,1f));
                rand15 = tempBarInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempBarInstantiationPointNum.Count - 1))];
                tempBarInstantiationPointNum.Remove(rand15);
                rand16 = Mathf.RoundToInt(Random.Range(0f,1f));
                rand17 = tempBarInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempBarInstantiationPointNum.Count - 1))];
                tempBarInstantiationPointNum.Remove(rand17);
                if(rand12 == 0) {
                    GameObject wallInstance = Instantiate(wallPrefab,wallInstantiationPoints[rand13].position,Quaternion.identity) as GameObject;
                }
                if(rand12 == 1) {
                    GameObject wallInstance = Instantiate(longWallPrefab,bigWallInstantiationPoints[rand13].position,Quaternion.identity) as GameObject;
                }
                if(rand14 == 0) {
                    GameObject wallInstance = Instantiate(wallPrefab,wallInstantiationPoints[rand15].position,Quaternion.identity) as GameObject;
                }
                if(rand14 == 1) {
                    GameObject wallInstance = Instantiate(longWallPrefab,bigWallInstantiationPoints[rand15].position,Quaternion.identity) as GameObject;
                }
                if(rand16 == 0) {
                    GameObject wallInstance = Instantiate(wallPrefab,wallInstantiationPoints[rand17].position,Quaternion.identity) as GameObject;
                }
                if(rand16 == 1) {
                    GameObject wallInstance = Instantiate(longWallPrefab,bigWallInstantiationPoints[rand17].position,Quaternion.identity) as GameObject;
                }
                break;
            case 4:
                rand5 = Mathf.RoundToInt(Random.Range(0f,1f));
                rand6 = Mathf.RoundToInt(Random.Range(0f,1f));
                rand7 = Mathf.RoundToInt(Random.Range(0f,1f));
                rand8 = Mathf.RoundToInt(Random.Range(0f,1f));
                if(rand5 == 0) {
                    GameObject wallInstance = Instantiate(wallPrefab,wallInstantiationPoints[0].position,Quaternion.identity) as GameObject;
                }
                else if(rand5 == 1) {
                    GameObject wallInstance = Instantiate(longWallPrefab,bigWallInstantiationPoints[0].position,Quaternion.identity) as GameObject;
                }
                if(rand6 == 0) {
                    GameObject wallInstance1 = Instantiate(wallPrefab,wallInstantiationPoints[1].position,Quaternion.identity) as GameObject;
                }
                else if(rand6 == 1) {
                    GameObject wallInstance1 = Instantiate(longWallPrefab,bigWallInstantiationPoints[1].position,Quaternion.identity) as GameObject;
                }
                if(rand7 == 0) {
                    GameObject wallInstance2 = Instantiate(wallPrefab,wallInstantiationPoints[2].position,Quaternion.identity) as GameObject;
                }
                else if(rand7 == 1) {
                    GameObject wallInstance2 = Instantiate(longWallPrefab,bigWallInstantiationPoints[2].position,Quaternion.identity) as GameObject;
                }
                if(rand8 == 0) {
                    GameObject wallInstance3 = Instantiate(wallPrefab,wallInstantiationPoints[3].position,Quaternion.identity) as GameObject;
                }
                else if(rand8 == 1) {
                    GameObject wallInstance3 = Instantiate(longWallPrefab,bigWallInstantiationPoints[3].position,Quaternion.identity) as GameObject;
                }
                break;
            default:
                break;
        }
    }

    void InstantiateBall() {
        counter0++;
        int randomPos = Mathf.RoundToInt(Random.Range(0f,gridAreas.Count - 1));
        tempCollider2 = gridAreas[randomPos];
        Bounds bounds = tempCollider2.bounds;
        float x = Random.Range(bounds.min.x,bounds.max.x);
        float y = Random.Range(bounds.min.y,bounds.max.y);
        GameObject ballInstance = Instantiate(ballPrefab,new Vector3(x,y,0f),Quaternion.identity) as GameObject;
        ballInstance.GetComponent<Ball>().moveSpeed = moveSpeed0;
        ballInstance.GetComponent<ClampNameBall>().SetCounter(counter0);
    }

    void InstantiateBadBall() {
        counter0++;
        int randomPos = Mathf.RoundToInt(Random.Range(0f,gridAreas.Count - 1));
        tempCollider1 = gridAreas[randomPos];
        Bounds bounds = tempCollider1.bounds;
        float x = Random.Range(bounds.min.x,bounds.max.x);
        float y = Random.Range(bounds.min.y,bounds.max.y);
        GameObject ballInstance = Instantiate(badBallPrefab,new Vector3(x,y,0f),Quaternion.identity) as GameObject;
        ballInstance.GetComponent<BadBall>().moveSpeed = moveSpeed0;
        ballInstance.GetComponent<ClampNameBall>().SetCounter(counter0);
    }

    public void LoadNewBlocks() {
        LoadBars();
        int randX = Mathf.RoundToInt(Random.Range(0f,4f));
        switch(randX) {
            case 0:
                counter0++;
                int randZ = Mathf.RoundToInt(Random.Range(0,instantiationPoints.Count - 1));
                GameObject blockInstance = Instantiate(blockPrefab,instantiationPoints[randZ].position,Quaternion.identity) as GameObject;
                blockInstance.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance.GetComponent<ClampNameBox>().SetCounter(counter0);
                break;
            case 1:
                tempInstantiationPointNum = new List<int>() {0,1,2,3,4};
                rand0 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand0);
                rand1 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand1);
                counter0++;
                GameObject blockInstance1 = Instantiate(blockPrefab,instantiationPoints[rand0].position,Quaternion.identity) as GameObject;
                blockInstance1.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance1.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance2 = Instantiate(blockPrefab,instantiationPoints[rand1].position,Quaternion.identity) as GameObject;
                blockInstance2.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance2.GetComponent<ClampNameBox>().SetCounter(counter0);
                break;
            case 2:
                tempInstantiationPointNum = new List<int>() {0,1,2,3,4};
                rand0 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand0);
                rand1 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand1);
                rand2 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand2);
                counter0++;
                GameObject blockInstance3 = Instantiate(blockPrefab,instantiationPoints[rand1].position,Quaternion.identity) as GameObject;
                blockInstance3.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance3.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance4 = Instantiate(blockPrefab,instantiationPoints[rand2].position,Quaternion.identity) as GameObject;
                blockInstance4.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance4.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance5 = Instantiate(blockPrefab,instantiationPoints[rand0].position,Quaternion.identity) as GameObject;
                blockInstance5.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance5.GetComponent<ClampNameBox>().SetCounter(counter0);
                break;
            case 3:
                tempInstantiationPointNum = new List<int>() {0,1,2,3,4};
                rand0 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand0);
                rand1 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand1);
                rand2 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand2);
                rand3 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand3);
                counter0++;
                GameObject blockInstance6 = Instantiate(blockPrefab,instantiationPoints[rand0].position,Quaternion.identity) as GameObject;
                blockInstance6.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance6.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance7 = Instantiate(blockPrefab,instantiationPoints[rand1].position,Quaternion.identity) as GameObject;
                blockInstance7.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance7.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance8 = Instantiate(blockPrefab,instantiationPoints[rand2].position,Quaternion.identity) as GameObject;
                blockInstance8.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance8.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance9 = Instantiate(blockPrefab,instantiationPoints[rand3].position,Quaternion.identity) as GameObject;
                blockInstance9.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance9.GetComponent<ClampNameBox>().SetCounter(counter0);
                break;
            case 4:
                tempInstantiationPointNum = new List<int>() {0,1,2,3,4};
                rand0 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand0);
                rand1 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand1);
                rand2 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand2);
                rand3 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                tempInstantiationPointNum.Remove(rand3);
                rand4 = tempInstantiationPointNum[Mathf.RoundToInt(Random.Range(0,tempInstantiationPointNum.Count))];
                counter0++;
                GameObject blockInstance10 = Instantiate(blockPrefab,instantiationPoints[rand0].position,Quaternion.identity) as GameObject;
                blockInstance10.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance10.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance11 = Instantiate(blockPrefab,instantiationPoints[rand1].position,Quaternion.identity) as GameObject;
                blockInstance11.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance11.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance12 = Instantiate(blockPrefab,instantiationPoints[rand2].position,Quaternion.identity) as GameObject;
                blockInstance12.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance12.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance13 = Instantiate(blockPrefab,instantiationPoints[rand3].position,Quaternion.identity) as GameObject;
                blockInstance13.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance13.GetComponent<ClampNameBox>().SetCounter(counter0);
                counter0++;
                GameObject blockInstance14 = Instantiate(blockPrefab,instantiationPoints[rand4].position,Quaternion.identity) as GameObject;
                blockInstance14.GetComponent<Block>().moveSpeed = moveSpeed0;
                blockInstance14.GetComponent<ClampNameBox>().SetCounter(counter0);
                break;
        }
        GameObject blockBorderInstance = Instantiate(blockBorderPrefab,instantiationPoints[0].position,Quaternion.identity) as GameObject;
    }
}
