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
        { 0, "�܂������̂���I���O�B" },
        { 1, "����9��������" },
        { 2, "\n�m�A��ł܂��w�Z�ɒN������Ǝv������A���O�������̂���"},
        { 3, "�h�����́A�������@���i�����Ƃ߁@�݂ȂƁj\n���̃N���X���C�g�ŁA�悭�����Ă���A�񃂃e�hM�j���h"},
        { 4, "�m�����A��ς������H"},
        { 5, "�����A��您�O"},
        { 6, "�m�����A��ς������H\n�����A��您�O" },
        { 7, "�́H\n�܂��Ƃ肠�����A���" },
        { 8, "��......�Y�ꕨ���s������ꏏ�ɗ���" },
        { 9, "���ɕt���Ă����I" },
        { 10, "�₾" },
        { 11, "�T�C�[�ŉ��h���邩��\n���肢�I" },
        { 12, "�T�C�[�ɉ��h�˂���" },
        { 13, "���O�Ђ������邩�炨�肢�I" },
        { 14, "�S���a���ȁI\n......���傤���Ȃ��ȁB����������" },
        { 15, "......" },
        { 16, "......���āA���ォ��I\n��������ɖY���񂾂�I" },
        { 17, "�t���C�Ԃ��ł�" },
        { 18, "�����A\n���≽�Ɏg�����񂾂�I" },
        { 19, "����������A�邼�B����A���d��\n......��......�J���Ȃ�......�܂��ŊJ���Ȃ�......" },
        { 20, "�J���ˁI�@�J�����I�@�J���h�A�I�@�Jk......" },
        { 21, "���O���J����̎�`����I�܂�����......\n���������ĕ����߂�ꂽ�H......����A����Ȃ킯�Ȃ����......" },
        { 22, "......����A����A�m�艉�o���" },
        { 23, "���Ɋ肢��" },
        { 24, "�q���g��T��" },
        { 25, "覐΍~���Ă��邩���߂Ƃ�����" },
        { 26, "�������ȁA������ƕӂ�����񂵂Ă݂悤��" },
        { 27, "���̋@������" },
        { 28, "���Ɋ肢��" },
        { 29, "���������΁A�������̎��̋@����[����Ă�̌����Ȃ�" },
        { 30, "���K���ɗ����ĂȂ�����" },
        { 999, "�Ō�̃Z���t" },
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
