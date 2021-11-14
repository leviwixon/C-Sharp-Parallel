using System;

namespace Sequential_Grip
{
    class Program
    {
        public static int userInputCols = 20;
        public static int userInputRows = 12;
        public static int NumRows = userInputRows + 2;
        public static int NumCols = userInputCols + 2;
        public int gen = 10;

        public static void Main(string[] args)
        {
            int seed = 12;
            int high = 20;
            int curGen = 0;
            //int newValue;
            int[,] genArray = new int[NumRows, NumCols];
            int[,] newGenArray = new int[NumRows, NumCols];
            fillGrid(genArray, seed, high);

            printf("1--\n");
            printGrid(genArray);

            while (curGen < gen - 1)
            {
                for (int i = 0; i < NumRows; ++i)
                {
                    for (int j = 0; j < NumCols; ++j)
                    {
                        if (i == 0 || i == NumRows - 1)
                        {
                            newGenArray[i][j] = 0;
                        }
                        else if (j == 0 || j == NumCols - 1)
                        {
                            newGenArray[i][j] = 0;
                        }
                        else
                        {
                            //newValue = checker(genArray, i                                                                                                                                                             , j);
                            newGenArray[i][j] = checker(genArray, i, j);
                        }
                    }
                }
                printf("%d--\n", curGen + 2);
                printGrid(newGenArray);

                for (int i = 0; i < NumRows; i++)
                {
                    for (int j = 0; j < NumCols; j++)
                    {
                        genArray[i][j] = newGenArray[i][j];
                    }
                }

                curGen++;
            }
            return 0;
        }

        public int checker(int arr[][], int x, int y)
        {
            int newValue;
            int target = arr[x][y];
            int sum = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    sum += arr[i][j];
                }
            }
            usleep(sum % 11 * 1500);
            if (sum % 10 == 0)
            {
                newValue = 0; ;
            }
            else if (sum < 50)
            {
                newValue = target + 3;
            }
            else if (sum > 50 && sum < 150)
            {
                if (target - 3 < 0)
                {
                    newValue = 0;
                }
                else
                {
                    newValue = (target - 3);
                }
            }
            else
            {
                newValue = 1;
            }
            return newValue;
        }

        void printGrid(int G[][NumCols])
        {
            for (int i = 1; i < NumRows - 1; i++)
            {
                for (int j = 1; j < NumCols - 1; j++)
                {
                    printf("%3d ", G[i][j]);
                }
                printf("\n");
            }
            printf("\n");
        }

        void fillGrid(int G[][NumCols], int seed, int high)
        {
            srand(seed);
            int i, j;
            // we only call this function to create the original, so we can seed sr                                                                                                                                                             and here without repeating.
            // create generation 0, the only random generation
            for (i = 0; i < NumRows; i++)
            {
                for (j = 0; j < NumCols; j++)
                {
                    if (i == 0 || i == (NumRows - 1))
                    { // if first or last row, set 0 b                                                                                                                                                             order
                        G[i][j] = 0;
                        printf("FILLING %d %d WITH %d\n", i, j, G[i][j]);
                    }
                    else if (j == 0 || j == (NumCols - 1))
                    { // if first or last colum                                                                                                                                                             n, set 0 border
                        G[i][j] = 0;
                        printf("FILLING %d %d WITH %d\n", i, j, G[i][j]);
                    }
                    else
                    {
                        G[i][j] = rand() % high;     // else random fill based on seed
                        printf("FILLING %d %d WITH %d\n", i, j, G[i][j]);
                    }
                }
            }
        }
    }
}
