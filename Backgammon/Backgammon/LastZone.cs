using System;
using System.Collections.Generic;

namespace Backgammon
{
    public class LastZone
    {
        public static List<OneStep> giveAllTheSteps(Board board, Color.color currentColor, List<int> currentRoll)
        {
            int[] arr = currentRoll.ToArray();
            bool colorWhite = currentColor == Color.color.white;
            int boardSpot = colorWhite ? 5 : 18;
            int colorStep = colorWhite ? -1 : 1;
            List<OneStep> resultList = new List<OneStep>();
            Array.Sort(arr);
            Array.Reverse(arr);
            int boardSpotFinish = colorWhite ? arr[0] - 1 : 24 - arr[0];

            for (; boardSpot + colorStep * (arr[0])<24 && boardSpot + colorStep * (arr[0])>=0; boardSpot += colorStep)
            {
                if (board.SpotsOnBoard[boardSpot].color == currentColor)
                {
                    for(int i=0;i<arr.Length;i++)
                        if(checkIfWillAddToList(board,boardSpot, boardSpot + (arr[i] ) * colorStep))
                            resultList.Add(new OneStep(boardSpot, boardSpot + colorStep * (arr[i])));
                }
            }

            if (board.SpotsOnBoard[boardSpot].color == currentColor)
            {
                resultList.Add(new OneStep(boardSpot, 26));
                if(arr.Length > 1 && arr[0] != arr[1])
                    if (checkIfWillAddToList(board, boardSpot, boardSpot + (arr[1] ) * colorStep))
                        resultList.Add(new OneStep(boardSpot, boardSpot + colorStep * (arr[1] )));
            }

            boardSpot += colorStep;

            while (resultList.Count == 0 && boardSpot >= 0 && boardSpot<24)
            {
                if (board.SpotsOnBoard[boardSpot].color == currentColor)
                {
                    resultList.Add(new OneStep(boardSpot, 26));
                }
                boardSpot += colorStep;
                if (boardSpot > 24 || boardSpot < 0)
                    return resultList;
            }

            if (arr.Length == 1 || arr[0] == arr[1])
                return resultList;

            boardSpotFinish = colorWhite ? arr[1] - 1 : 24 - arr[1];

            for (; boardSpot + colorStep * (arr[1]) >=0 && boardSpot + colorStep * (arr[1])<24; boardSpot += colorStep)
            {
                if ((board.SpotsOnBoard[boardSpot].color == currentColor) && (checkIfWillAddToList(board, boardSpot, boardSpot + (arr[1] ) * colorStep)))
                    resultList.Add(new OneStep(boardSpot, boardSpot + colorStep * (arr[1] )));
            }

            if (boardSpot < 24 && boardSpot > -1 && board.SpotsOnBoard[boardSpot].color == currentColor )
            {
                resultList.Add(new OneStep(boardSpot, 26));
            }

            return resultList;

        }

        private static bool checkIfWillAddToList(Board board,int start, int finish)
        {
            return (board.SpotsOnBoard[start].color != (Color.color)(((int)(board.SpotsOnBoard[finish].color)) ^ 1) || (board.SpotsOnBoard[finish].numberOfTiles == 1)) ;
        }

        internal static void putTheTiles(int _from, Player currentPlayer, Board board)
        {
            if (--(board.SpotsOnBoard[_from].numberOfTiles) == 0)
            {
                board.SpotsOnBoard[_from].color = Color.color.empty;
            }
            currentPlayer.NumberOfTilesGotOut++;
        }
    }
}