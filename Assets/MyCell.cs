using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Globals
//{
//    public static int[] diagonalaPrincipala = {0, 4, 8};
//    public static int[] diagonalaSecundara = {2, 4, 6};
//}

public class MyCell : MonoBehaviour
{
    MyBoard myboard;
    public Sprite spriteX;
    public Sprite sprite0;
    public int index;
    private static bool turn = false;
    private static bool win = false;
    private static int[] board = new int[9];
    private static int usedCells;

    private SpriteRenderer spriteRenderer;
    private bool isShowing = false;

    void Start()
    {
        myboard = FindObjectOfType<MyBoard>();
        // La initializare, iau componenta Sprite Renderer si o retin in acest obiect
        for(int i = 0; i < 9; i ++)
            board[i] = -1;
        usedCells = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Functie care functioneaza doar daca obiectul are atasat o componenta de tip Collider, cu Is Trigger activat
    void OnMouseDown()
    {
        if (isShowing == false  &&  !win)
        {
            isShowing = true;
            usedCells++;
            if (turn == false)
            {
                spriteRenderer.sprite = spriteX;
                board[index] = 0;
            }
            else
            {
                spriteRenderer.sprite = sprite0;
                board[index] = 1;
            }
            turn = !turn;
            spriteRenderer.enabled = true;

            //int line = index / 3;
            //int column = index % 3;

            if ((board[0] == board[1] && board[1] == board[2] && board[2] != -1) ||
               (board[3] == board[4] && board[4] == board[5] && board[5] != -1) ||
               (board[6] == board[7] && board[7] == board[8] && board[8] != -1) ||
               (board[0] == board[3] && board[3] == board[6] && board[6] != -1) ||
               (board[1] == board[4] && board[4] == board[7] && board[7] != -1) ||
               (board[2] == board[5] && board[5] == board[8] && board[8] != -1) ||
               (board[0] == board[4] && board[4] == board[8] && board[8] != -1) ||
               (board[7] == board[4] && board[4] == board[2] && board[2] != -1))
                win = true;
            if (win == true)
            {
                if (turn == false)
                    myboard.text = myboard.Text0;
                else
                    myboard.text = myboard.TextX;
                myboard.text.enabled = true;
            }
            if(usedCells == 9  &&  !win)
            {
                win = true;
                myboard.text = myboard.TextDraw;
                myboard.text.enabled = true;
            }
        }
    }
}
