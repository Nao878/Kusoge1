using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NovelWriter : MonoBehaviour
{
    [SerializeField] GameObject FirstDelete,Ore,Aibou,Textbox,Okuzyou,OkuzyouDoor,OkuzyouZihanki,OkuzyouZihankiOku,ZihankiHuta,Serih;
    public GameObject messagePanel,NextButtun;
    public Text text,serih1,serih2;
    public float writeSpeed = 0.2f;
    public bool isWriting, isHuta = false;
    public int key = 0;
    [SerializeField] float counter = 0;

    public void KaeruFn ()
    {
        FirstDelete.SetActive(false);
        Textbox.SetActive(true);
    }

    static Dictionary<int, string> message = new Dictionary<int, string> ()
    {
        { 0, "まだ居たのかよ！お前。" },
        { 1, "もう9時半だぞ" },
        { 2, "\n塾帰りでまだ学校に誰か居ると思ったら、お前だったのかよ"},
        { 3, "”こいつは、早乙女　湊（さおとめ　みなと）\n俺のクラスメイトで、よく喋ってくる、非モテドM男だ”"},
        { 4, "塾お疲れ、大変だった？"},
        { 5, "早く帰れよお前"},
        { 6, "塾お疲れ、大変だった？\n早く帰れよお前" },
        { 7, "は？\nまあとりあえず帰るわ" },
        { 8, "あ......忘れ物取り行くから一緒に来て" },
        { 9, "俺に付いてこい！" },
        { 10, "やだ" },
        { 11, "サイゼで塩辛奢るから\nお願い！" },
        { 12, "サイゼに塩辛ねえよ" },
        { 13, "松前漬けも奢るからお願い！" },
        { 14, "全部渋いな！\n......しょうがないな。早くいくぞ" },
        { 15, "......" },
        { 16, "......って、屋上かよ！\n何を屋上に忘れるんだよ！" },
        { 17, "フライ返しです" },
        { 18, "あぁ、\nいや何に使ったんだよ！" },
        { 19, "もういいよ帰るぞ。あれ、扉重っ\n......え......開かない......まじで開かない......" },
        { 20, "開け戸！　開け扉！　開けドア！　開k......" },
        { 21, "お前も開けるの手伝えよ！まじかよ......\nもしかして閉じ込められた？......いや、そんなわけないよな......" },
        { 22, "......いや、これ、確定演出やん" },
        { 23, "星に願いを" },
        { 24, "ヒントを探す" },
        { 25, "隕石降ってくるからやめとけって" },
        { 26, "そうだな、ちょっと辺りを見回してみようぜ" },
        { 27, "自販機を見る" },
        { 28, "星に願いを" },
        { 29, "そういえば、今日この自販機が補充されてるの見たなぁ" },
        { 30, "小銭下に落ちてないかな" },
        { 999, "最後のセリフ" },
    };

    public void OnClick ()
    {
        if (isWriting)
        {
            writeSpeed = 0f;
        }
        else
        {
            switch (key)
            {
                case 0:
                    Ore.SetActive(false);
                    Write(message[key]);
                    ++key;
                    break;
                case 1:
                    Aibou.SetActive(true);
                    Write(message[key]);
                    ++key;
                    break;
                case 3:
                    AibouTalk();
                    break;
                case 4:
                    SerihHyouzi();
                    break;
                case 6:
                    OreTalk();
                    break;
                case 7:
                    AibouTalk();
                    //key = 999;//Write(message[key]);
                    break;
                case 8:
                    OreTalk();
                    break;
                case 10:
                    AibouTalk();
                    break;
                case 11:
                    OreTalk();
                    break;
                case 12:
                    AibouTalk();
                    break;
                case 13:
                    OreTalk();
                    break;
                case 14:
                    AibouTalk();
                    break;
                case 15:
                    Okuzyou.SetActive(true);
                    Aibou.SetActive(false);
                    Clean();
                    Write(message[key]);
                    ++key;
                    break;
                case 16:
                    AibouTalk();
                    break;
                case 17:
                    OreTalk();
                    break;
                case 18:
                    AibouTalk();
                    break;
                case 19:
                    AibouTalk();
                    break;
                case 20:
                    OreTalk();
                    break;
                case 21:
                    AibouTalk();
                    break;
                case 22:
                    AibouTalk();
                    OkuzyouDoor.SetActive(true);
                    break;
                case 23:
                    SerihHyouzi();
                    break;
                case 27:
                    SerihHyouzi();
                    break;
                case 30:
                    AibouTalk();
                    break;
                case 31:
                    SceneManager.LoadScene("gakkou5");
                    break;
                case 999:
                    messagePanel.SetActive (false);
                    break;
                default:
                    Write(message[key]);
                    ++key;
                    break;
            }
        }
    }

    public void SerihHyouzi()
    {
        Clean();
        Aibou.SetActive(false);
        Ore.SetActive(true);
        Serih.SetActive(true);
        serih1.text = message[key];
        ++key;
        serih2.text = message[key];
        ++key;
        NextButtun.SetActive(false);
    }
    public void Serih1Click()
    {
        switch (key)
        {
            case 6:
                NextButtunHyouzi();
                Write(message[key]);
                ++key;
                break;
            case 25:
                NextButtunHyouzi();
                Aibou.SetActive(true);
                Ore.SetActive(false);
                Write(message[key]);
                key -= 2;
                break;
            case 29:
                NextButtunHyouzi();
                OkuzyouZihanki.SetActive(true);
                OkuzyouZihankiOku.SetActive(true);
                Aibou.SetActive(true);
                Ore.SetActive(false);
                Write(message[key]);
                ++key;
                isHuta = true;
                break;
        }
    }
    void Update()
    {
        if(isHuta)
        {
            counter += Time.deltaTime;
            if(counter > 0.5)
            {
                if (!ZihankiHuta.activeSelf)
                {
                    ZihankiHuta.SetActive(true);
                }
                else
                {
                    ZihankiHuta.SetActive(false);
                }
                counter = 0;
            }
        }
    }
    public void Serih2Click()
    {
        switch (key)
        {
            case 6:
                NextButtunHyouzi();
                Write(message[key]);
                ++key;
                break;
            case 25:
                NextButtunHyouzi();
                Aibou.SetActive(true);
                Ore.SetActive(false);
                ++key;
                Write(message[key]);
                ++key;
                break;
            case 29:
                SceneManager.LoadScene("Meteo");
                break;
        }
    }

    private void OreTalk()
    {
        Aibou.SetActive(false);
        Ore.SetActive(true);
        Clean();
        Write (message[key]);
        ++key;
    }
    private void AibouTalk()
    {
        Aibou.SetActive(true);
        Ore.SetActive(false);
        Clean();
        Write(message[key]);
        ++key;
    }
    private void NextButtunHyouzi()
    {
        NextButtun.SetActive(true);
        Serih.SetActive(false);
    }

    public void Write(string s)
    {
        writeSpeed = 0.1f;
        StartCoroutine(IEWrite(s));
    }

    public void Clean()
    {
        text.text = "";
    }

    IEnumerator IEWrite (string s)
    {
        isWriting = true;
        for (int i = 0; i < s.Length; i++)
        {
            text.text += s.Substring (i,1);
            yield return new WaitForSeconds (writeSpeed);
        }
        isWriting = false;
    }

    void Start()
    {
        Clean ();
    }
}
