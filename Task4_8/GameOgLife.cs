using System;
using System.Collections.Generic;

namespace Task4_8
{
    public class GameOgLife
    {
        private uint width, height;
        private bool[,] field;

        private List<bool[,]> fieldHistory;

        public GameOgLife(uint width = 10, uint height = 10)
        {

            this.width = width;
            this.height = height;

            this.field = new bool[height, width];
            this.fieldHistory = new List<bool[,]>();

            this.completeRandomField();

            bool isLive = true;
            int repeat = -1;
            int delay = 500;
            int step = 1;

            do
            {
                Console.Clear();
                Console.WriteLine($"Iteration {step++}");
                showField(this.field);
                System.Threading.Thread.Sleep(delay);
                isLive = nextGeneration();
                repeat = checkOnRepeatFieldHistory(this.field);
            } while (isLive && repeat < 0);

            Console.Clear();
            Console.WriteLine($"Iteration {step}");
            showField(this.field);
            if(!isLive) Console.WriteLine("All bio dead");
            if(repeat >= 0) Console.WriteLine($"Field configuration repeat with generation {repeat}");
        }

        private void completeRandomField()
        {
            Random generator = new Random((int)DateTime.Now.Ticks);
            for (int  i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    this.field[i, j] = generator.Next(4) == 0 ? true : false;
                }
            }
        }

        public void showField(bool[,] field)
        {
            int index = 0;
            foreach (bool value in field)
            {
                Console.Write(value ? "X" : "O");
                index++;
                if(index % this.width == 0) Console.WriteLine();
            }
        }

        private uint getSummAroundCell(int x, int y)
        {
            uint summ = 0;
            for (int  i = Math.Max(0, y - 1); i < Math.Min(height, y + 2);i++)
            {
                for (int j = Math.Max(0, x - 1); j < Math.Min(height, x + 2); j++)
                {
                    if ((x != j || y != i) && field[i, j]) summ++;
                }
            }
            return summ;
        }
        
        public bool nextGeneration()
        {
            bool[,] newField = new bool[height, width];
            uint countAliveCells = 0;
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (newField[i, j] = getNewCell(field[i, j], getSummAroundCell(j, i)))
                    {
                        countAliveCells++;
                    }
                }
            }
            
            this.field = newField;
            return countAliveCells > 0;
        }

        private int checkOnRepeatFieldHistory(bool[,] fieldForCheck)
        {
            for (int  i = 0; i < fieldHistory.Count; i++)
            {
                
                if (compareFields(fieldHistory[i],fieldForCheck))
                {
                    return i;
                }
            }

            fieldHistory.Add(fieldForCheck);
            return -1;
        }

        private bool compareFields(bool[,] field1, bool[,] field2)
        {
            for (int i = 0;i<field1.GetLength(0);i++)
            {
                for (int j = 0; j < field1.GetLength(1); j++)
                {
                    if (field1[i, j] != field2[i, j]) return false;
                }
                    
            }
            return true;
        }

        private bool getNewCell(bool cellState, uint countCellAround)
        {
            if (countCellAround == 3)
            {
                return true;
            }
            else if (cellState && countCellAround == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}